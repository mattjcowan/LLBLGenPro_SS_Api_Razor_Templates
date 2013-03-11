using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.EntityClasses;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using Northwind.Data.Helpers;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceRepositories
{
    public abstract class EntityServiceRepositoryBase<TDto, TEntity, TEntityFactory, TEntityFieldIndexEnum> : IEntityServiceRepository<TDto>
        where TDto : CommonDtoBase
        where TEntity: CommonEntityBase, new() 
        where TEntityFactory : EntityFactoryBase2<TEntity>, new() 
        where TEntityFieldIndexEnum : struct, IConvertible
    {
        public ICacheClient CacheClient { get; set; }
        public abstract IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected abstract EntityType EntityType { get; }
        
        public EntityMetaDetailsResponse GetEntityMetaDetails(ServiceStack.ServiceInterface.Service service)
        {
            // The entity meta details don't change per entity type, so cache these for performance
            var cacheKey = string.Format("{0}-meta-details", EntityType.ToString().ToLower());
            var metaDetails = CacheClient.Get<EntityMetaDetailsResponse>(cacheKey);
            if (metaDetails != null)
                return metaDetails;
                
            var request = service.RequestContext.Get<IHttpRequest>();
            var appUri = request.GetApplicationUrl().TrimEnd('/');
            var baseServiceUri = appUri + request.PathInfo.Replace("/meta", "");
            var queryString = request.QueryString["format"] != null ? "&format=" + request.QueryString["format"] : "";
            var pkCount = FieldMap.Count(pk => pk.Value.IsPrimaryKey);
            var fields = new List<Link>();
            foreach (var f in FieldMap)
            {
                var isUnique = false;
                var ucs = UniqueConstraintMap.Where(uc => uc.Value.Any(x => x.Name.Equals(f.Key, StringComparison.InvariantCultureIgnoreCase))).ToArray();
                var link = Link.Create(
                  f.Key.ToCamelCase(), f.Value.DataType.Name, "field",
                  string.Format("{0}?select={1}{2}", baseServiceUri, f.Key.ToLowerInvariant(), queryString),
                  string.Format("The {0} field for the {1} resource.", f.Value.Name, typeof (TDto).Name),
                  new Dictionary<string, string>()
                );
                var props = new SortedDictionary<string, string>();
                props.Add("index", f.Value.FieldIndex.ToString(CultureInfo.InvariantCulture));
                if (f.Value.IsPrimaryKey)
                {
                    props.Add("isPrimaryKey", f.Value.IsPrimaryKey.ToString().ToLower());
                    if (pkCount == 1) isUnique = true;
                }
                if (f.Value.IsForeignKey)
                    props.Add("isForeignKey", "true");

                var ucNames = new List<string>();
                foreach (var uc in ucs)
                {
                    if (uc.Value.Count() == 1) isUnique = true;
                    ucNames.Add(uc.Key.ToLower());
                }
                if (ucNames.Any())
                    props.Add("partOfUniqueConstraints", string.Join(",", ucNames.ToArray()));
                if (isUnique)
                    props.Add("isUnique", "true");
                if (f.Value.IsOfEnumDataType)
                    props.Add("isOfEnumDataType", "true");
                if (f.Value.IsReadOnly)
                    props.Add("isReadOnly", "true");
                if (f.Value.IsNullable)
                    props.Add("isNullable", "true");
                if (f.Value.IsOfEnumDataType)
                    props.Add("isEnumType", "true");
                if (f.Value.MaxLength > 0)
                    props.Add("maxLength", f.Value.MaxLength.ToString(CultureInfo.InvariantCulture));
                if (f.Value.Precision > 0)
                    props.Add("precision", f.Value.Precision.ToString(CultureInfo.InvariantCulture));
                if (f.Value.Scale > 0)
                    props.Add("scale", f.Value.Scale.ToString(CultureInfo.InvariantCulture));
                link.Properties = new Dictionary<string, string>(props);
                fields.Add(link);
            }

            var includes = new List<Link>();
            foreach (var f in IncludeMap)
            {
                var relationType = "";
                switch (f.Value.TypeOfRelation)
                {
                    case RelationType.ManyToMany:
                        relationType = "n:n";
                        break;
                    case RelationType.ManyToOne:
                        relationType = "n:1";
                        break;
                    case RelationType.OneToMany:
                        relationType = "1:n";
                        break;
                    case RelationType.OneToOne:
                        relationType = "1:1";
                        break;
                }
                var relatedDtoContainerName =
                    (Enum.GetName(typeof (EntityType), f.Value.ToFetchEntityType) ?? "").Replace("Entity", "");
                var link = Link.Create(
                    f.Key.ToCamelCase(),
                    (relationType.EndsWith("n") ? relatedDtoContainerName + "Collection" : relatedDtoContainerName),
                    "include",
                    string.Format("{0}?include={1}{2}", baseServiceUri, f.Key.ToLowerInvariant(), queryString),
                    string.Format(
                        "The {0} field for the {1} resource to include in the results returned by a query.",
                        f.Value.PropertyName,
                        typeof (TDto).Name),
                    new Dictionary<string, string>
                        {
                            {"field", f.Value.PropertyName.ToCamelCase()},
                            {
                                "relatedType",
                                (Enum.GetName(typeof (EntityType), f.Value.ToFetchEntityType) ?? "").Replace("Entity", "")
                            },
                            {"relationType", relationType}
                        });
                includes.Add(link);
            }

            var relations = new List<Link>();
            foreach (var f in RelationMap)
            {
                var isPkSide = f.Value.StartEntityIsPkSide;
                var isFkSide = !f.Value.StartEntityIsPkSide;
                var pkFieldCore = f.Value.GetAllPKEntityFieldCoreObjects().FirstOrDefault();
                var fkFieldCore = f.Value.GetAllFKEntityFieldCoreObjects().FirstOrDefault();
                var thisField = isPkSide
                                    ? (pkFieldCore == null ? "" : pkFieldCore.Name)
                                    : (fkFieldCore == null ? "" : fkFieldCore.Name);
                var relatedField = isFkSide
                                    ? (pkFieldCore == null ? "" : pkFieldCore.Name)
                                    : (fkFieldCore == null ? "" : fkFieldCore.Name);
                var thisEntityAlias = isPkSide
                                    ? (pkFieldCore == null ? "": pkFieldCore.ActualContainingObjectName.Replace("Entity", ""))
                                    : (fkFieldCore == null ? "": fkFieldCore.ActualContainingObjectName.Replace("Entity", ""));
                var relatedEntityAlias = isFkSide
                                    ? (pkFieldCore == null ? "": pkFieldCore.ActualContainingObjectName.Replace("Entity", ""))
                                    : (fkFieldCore == null ? "": fkFieldCore.ActualContainingObjectName.Replace("Entity", ""));
                var relationType = "";
                switch (f.Value.TypeOfRelation)
                {
                    case RelationType.ManyToMany:
                        relationType = "n:n";
                        break;
                    case RelationType.ManyToOne:
                        relationType = "n:1";
                        break;
                    case RelationType.OneToMany:
                        relationType = "1:n";
                        break;
                    case RelationType.OneToOne:
                        relationType = "1:1";
                        break;
                }
                var link = Link.Create(
                  f.Key.ToCamelCase(),
                  relationType.EndsWith("n") ? relatedEntityAlias + "Collection" : relatedEntityAlias, "relation",
                  string.Format("{0}?relations={1}{2}", baseServiceUri, f.Key.ToLowerInvariant(), queryString),
                  string.Format(
                    "The relation '{0}' for the {1} resource between a {2} (PK) and a {3} (FK) resource.",
                    f.Value.MappedFieldName,
                    typeof (TDto).Name, f.Value.AliasStartEntity.Replace("Entity", ""),
                    f.Value.AliasEndEntity.Replace("Entity", "")),
                  new Dictionary<string, string>
                  {
                    {"field", f.Value.MappedFieldName.ToCamelCase()},
                    {"joinHint", f.Value.JoinType.ToString().ToLower()},
                    {"relationType", relationType},
                    {"isPkSide", isPkSide.ToString().ToLower()},
                    {"isFkSide", isFkSide.ToString().ToLower()},
                    {"isWeakRelation", f.Value.IsWeak.ToString().ToLower()},
                    {"pkTypeName", isPkSide ? thisEntityAlias : relatedEntityAlias},
                    {
                      "pkTypeField",
                      isPkSide ? thisField.ToCamelCase() : relatedField.ToCamelCase()
                    },
                    {"fkTypeName", isFkSide ? thisEntityAlias : relatedEntityAlias},
                    {
                      "fkTypeField",
                      isFkSide ? thisField.ToCamelCase() : relatedField.ToCamelCase()
                    },
                  });
                relations.Add(link);
                // add relation to fields list as well
                fields.Add(Link.Create(
                  f.Value.MappedFieldName.ToCamelCase(),
                  relationType.EndsWith("n") ? relatedEntityAlias + "Collection": relatedEntityAlias,
                  "field", null,
                  string.Format("The {0} field for the {1} resource.", f.Value.MappedFieldName,
                        typeof (TDto).Name), new Dictionary<string, string>
                          {
                            {"relation", f.Value.MappedFieldName.ToCamelCase()},
                            {"relationType", relationType},
                            {"isPkSide", isPkSide.ToString().ToLower()},
                            {"isFkSide", isFkSide.ToString().ToLower()},
                          }));
            }

            metaDetails = new EntityMetaDetailsResponse()
                {
                    Fields = fields.ToArray(),
                    Includes = includes.ToArray(),
                    Relations = relations.ToArray()
                };
            CacheClient.Set(cacheKey, metaDetails);
            return metaDetails;
        }

        internal virtual IDictionary< string, IEntityField2[] > UniqueConstraintMap
        {
            get { return new Dictionary< string, IEntityField2[] >(); }
            set { }
        }

        internal virtual IDictionary<string, IEntityField2> FieldMap
        {
            get { return EntityFieldsFactory.CreateEntityFieldsObject(EntityType).ToDictionary(k => k.Name, v => (IEntityField2)v); }
            set { }
        }

        internal virtual IDictionary<string, IPrefetchPathElement2> IncludeMap
        {
            get { return ((CommonEntityBase)GeneralEntityFactory.Create(EntityType)).PrefetchPaths.ToDictionary(k => k.PropertyName, v => v); }
            set { }
        }

        internal virtual IDictionary<string, IEntityRelation> RelationMap
        {
            get { return ((CommonEntityBase)GeneralEntityFactory.Create(EntityType)).EntityRelations.ToDictionary(k => k.MappedFieldName, v => v); }
            set { }
        }

        internal EntityCollection<TEntity> Fetch(string sortExpression, string includeExpressions, string filterExpression, string relationExpression, string selectExpression, int pageNumber, int pageSize, out int totalItemCount)
        {
            var entitySortExpression = ConvertStringToSortExpression(sortExpression);
            var prefetchPath = ConvertStringToPrefetchPath(EntityType, includeExpressions);
            var predicateBucket = ConvertStringToRelationPredicateBucket(filterExpression, relationExpression);
            var excludedIncludedFields = ConvertStringToExcludedIncludedFields(selectExpression);

            var entities = new EntityCollection<TEntity>(new TEntityFactory());
            using (var adapter = DataAccessAdapterFactory.NewDataAccessAdapter())
            {
                totalItemCount = adapter.GetDbCount(entities, predicateBucket);
                adapter.FetchEntityCollection(entities, predicateBucket, 0, entitySortExpression, prefetchPath, excludedIncludedFields, pageNumber, pageSize);
            }
            return entities;
        }

        #region Conversion Methods

        internal virtual IEntityField2 GetField(string fieldName, bool throwIfDoesNotExist)
        {
            if (!typeof(TEntityFieldIndexEnum).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            TEntityFieldIndexEnum t;
            if (!Enum.TryParse(fieldName, true, out t))
            {
                if (throwIfDoesNotExist)
                    throw new ArgumentException(string.Format("Requested value '{0}' was not found in {1}.", fieldName,
                                                              typeof(TEntityFieldIndexEnum)));
                return null;
            }

            return EntityFieldFactory.Create((Enum) (object) t);
        }

        internal virtual SortExpression ConvertStringToSortExpression(string sortStr)
        {
            var sortExpression = new SortExpression();
            if (!string.IsNullOrEmpty(sortStr))
            {
                var sortClauses = sortStr.Split(new[] {';', ','}, StringSplitOptions.None);
                foreach (var sortClause in sortClauses)
                {
                    var sortClauseElements = sortClause.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                    var sortField = GetField(sortClauseElements[0], false);
                    if (sortField == null)
                        continue;

                    sortExpression.Add(new SortClause(
                                           sortField, null,
                                           sortClauseElements.Length > 1 &&
                                           sortClauseElements[1].Equals("desc",
                                                                        StringComparison.OrdinalIgnoreCase)
                                               ? SortOperator.Descending
                                               : SortOperator.Ascending
                                           ));
                }
            }
            return sortExpression;
        }
        
        internal ExcludeIncludeFieldsList ConvertStringToExcludedIncludedFields(string selectStr)
        {
            if (string.IsNullOrWhiteSpace(selectStr))
                return null;

            var fields = new IncludeFieldsList();
            var selectStrs = selectStr.Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var r in selectStrs)
            {
                var field = GetField(r, false);
                if(field != null)
                    fields.Add(field);
            }
            return fields.Count > 0 ? fields : null;
        }

        internal virtual IPrefetchPath2 ConvertStringToPrefetchPath(EntityType rootEntityType, string prefetchStr)
        {
            if (string.IsNullOrWhiteSpace(prefetchStr))
                return null;

            var prefetch = new PrefetchPath2(rootEntityType);
            var prefetchStrs = prefetchStr.Split(new[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var r in prefetchStrs)
            {
                var rr = IncludeMap.FirstOrDefault(rm => rm.Key.Equals(r, StringComparison.InvariantCultureIgnoreCase));
                if (!rr.Equals(default(KeyValuePair<string, IPrefetchPathElement2>)))
                    prefetch.Add(rr.Value);
            }
            return prefetch.Count > 0 ? prefetch : null;
        }

        internal virtual IRelationPredicateBucket ConvertStringToRelationPredicateBucket(string filterStr,
                                                                                         string relationStr)
        {
            var predicateBucket = new RelationPredicateBucket();

            var relations = ConvertStringToRelations(relationStr);
            if (relations != null && relations.Count > 0)
                predicateBucket.Relations.AddRange(relations.ToArray());

            var predicate = ConvertStringToPredicate(filterStr);
            if (predicate != null)
                predicateBucket.PredicateExpression.Add(predicate);
            return predicateBucket;
        }

        private ICollection<IRelation> ConvertStringToRelations(string relationStr)
        {
            if (string.IsNullOrWhiteSpace(relationStr))
                return null;

            var relationStrs = relationStr.Split(new[]{':', ','}, StringSplitOptions.RemoveEmptyEntries);
            var relations = new List<IRelation>();
            foreach (var r in relationStrs)
            {
                var rr = RelationMap.FirstOrDefault(rm => rm.Key.Equals(r, StringComparison.InvariantCultureIgnoreCase));
                if (!rr.Equals(default(KeyValuePair<string, IEntityRelation>)))
                    relations.Add(rr.Value);
            }
            return relations.Count > 0 ? relations.ToArray() : null;
        }


        private IPredicate ConvertStringToPredicate(string filterStr)
        {
            var filterNode = FilterParser.Parse(filterStr);
            var predicate = BuildPredicateTree(filterNode);
            return predicate;
        }

        private IPredicate BuildPredicateTree(FilterNode filterNode, PredicateExpression parentPredicateExpression = null)
        {
            if (filterNode.NodeCount > 0)
            {
                if (filterNode.NodeType == FilterNodeType.Root && filterNode.Nodes.Count > 0)
                {
                    if (filterNode.NodeCount == 1)
                        return BuildPredicateTree(filterNode.Nodes[0]);

                    var predicate = new PredicateExpression();
                    foreach (var childNode in filterNode.Nodes)
                    {
                        var newPredicate = BuildPredicateTree(childNode);
                        if (newPredicate != null)
                            predicate.AddWithAnd(newPredicate);
                    }
                    return predicate;
                }
                else if (filterNode.NodeType == FilterNodeType.AndExpression ||
                    filterNode.NodeType == FilterNodeType.OrExpression)
                {
                    var predicate = new PredicateExpression();
                    foreach (var childNode in filterNode.Nodes)
                    {
                        var newPredicate = BuildPredicateTree(childNode);
                        if (newPredicate != null)
                        {
                            if (filterNode.NodeType == FilterNodeType.OrExpression)
                                predicate.AddWithOr(newPredicate);
                            else
                                predicate.AddWithAnd(newPredicate);
                        }
                    }
                    return predicate;
                }
            }
            else if (filterNode.ElementCount > 0)
            {
                // convert elements to IPredicate
                var nodePredicate = BuildPredicateFromClauseNode(filterNode);
                if(nodePredicate != null)
                    return nodePredicate;
            }
            return null;
        }

        /*
            -> eq (equals any) 
            -> neq (not equals any) 
            -> eqc (equals any, case insensitive [on a case sensitive database]) 
            -> neqc (not equals any, case insensitive [on a case sensitive database]) 
            -> in (same as eq) 
            -> nin (same as ne) 
            -> lk (like) 
            -> nlk (not like) 
            -> nl (null)
            -> nnl (not null)
            -> gt (greater than) 
            -> gte (greater than or equal to) 
            -> lt (less than) 
            -> lte (less than or equal to) 
            -> ct (full text contains) 
            -> ft (full text free text) 
            -> bt (between)
            -> nbt (not between)
         */
        private IPredicate BuildPredicateFromClauseNode(FilterNode filterNode)
        {
            // there are always at least 2 elements
            if (filterNode.ElementCount < 2)
                return null;

            var elements = filterNode.Elements;
            var field = GetField(elements[0], true);
            var comparisonOperatorStr = elements[1].ToLowerInvariant();

            var valueElements = elements.Skip(2).ToArray();
            var objElements = new object[valueElements.Length];

            Action<string> throwINEEx = (s) =>
                {
                    throw new ArgumentException(string.Format("Invalid number of elements in '{0}' filter clause", s));
                };

            string objAlias;
            IPredicate predicate;
            switch (comparisonOperatorStr)
            {
                case("bt"): //between
                case("nbt"): //not between
                    if (valueElements.Length < 2) throwINEEx(comparisonOperatorStr);
                    objElements[0] = ConvertStringToFieldValue(field, valueElements[0]);
                    objElements[1] = ConvertStringToFieldValue(field, valueElements[1]);
                    objAlias = valueElements.Length == 3 ? valueElements[2] : null;
                    predicate = new FieldBetweenPredicate(field, null, objElements[0], objElements[1], objAlias, comparisonOperatorStr == "nbt"); 
                    break;
                case ("in"): //same as eq
                case ("nin"): //same as ne
                case ("eq"): //equals any
                case ("neq"): //not equals any
                case ("eqc"): //equals any, case insensitive [on a case sensitive database] - only 1 element per clause with this option
                case ("neqc"): //not equals any, case insensitive [on a case sensitive database] - only 1 element per clause with this option
                    if (valueElements.Length < 1) throwINEEx(comparisonOperatorStr);
                    for(int i=0;i< valueElements.Length;i++)
                        objElements[i] = ConvertStringToFieldValue(field, valueElements[i]);
                    if (objElements.Length == 1 || comparisonOperatorStr == "eqci" || comparisonOperatorStr == "neci")
                    {
                        predicate = new FieldCompareValuePredicate(field, null, comparisonOperatorStr.StartsWith("n")
                                                                                    ? ComparisonOperator.NotEqual
                                                                                    : ComparisonOperator.Equal,
                                                                   objElements[0])
                            {
                                CaseSensitiveCollation =
                                    comparisonOperatorStr == "eqci" || comparisonOperatorStr == "neci"
                            };
                    }
                    else
                    {
                        if (comparisonOperatorStr.StartsWith("n"))
                            predicate = (EntityField2) field != objElements;
                        else
                            predicate = (EntityField2) field == objElements;
                    }
                    break;
                case("lk"): //like
                case("nlk"): //not like
                    if (valueElements.Length < 1) throwINEEx(comparisonOperatorStr);
                    objElements[0] = ConvertStringToFieldValue(field, valueElements[0].Replace('*', '%'));
                    objAlias = valueElements.Length == 2 ? valueElements[1] : null;
                    predicate = new FieldLikePredicate(field, null, objAlias, (string)objElements[0], comparisonOperatorStr == "nlk");
                    break;
                case("nl"): //null
                case("nnl"): //not null
                    predicate = new FieldCompareNullPredicate(field, null, null, comparisonOperatorStr == "nnl");
                    break;
                case("gt"): //greater than) 
                case("gte"): //greater than or equal to
                case("lt"): //less than
                case("lte"): //less than or equal to
                    if (valueElements.Length < 1) throwINEEx(comparisonOperatorStr);
                    objElements[0] = ConvertStringToFieldValue(field, valueElements[0]);
                    objAlias = valueElements.Length == 2 ? valueElements[1] : null;
                    var comparisonOperator = ComparisonOperator.GreaterThan;
                    if(comparisonOperatorStr == "gte") comparisonOperator = ComparisonOperator.GreaterEqual;
                    else if(comparisonOperatorStr == "lt") comparisonOperator = ComparisonOperator.LesserThan;
                    else if(comparisonOperatorStr == "lte") comparisonOperator = ComparisonOperator.LessEqual;
                    predicate = new FieldCompareValuePredicate(field, null, comparisonOperator, objElements[0], objAlias);
                    break;
                case("ct"): //full text contains
                case("ft"): //full text free text
                    if (valueElements.Length < 1) throwINEEx(comparisonOperatorStr);
                    objElements[0] = valueElements[0];
                    objAlias = valueElements.Length == 2 ? valueElements[1] : null;
                    predicate = new FieldFullTextSearchPredicate(field, null, comparisonOperatorStr == "ct" ? FullTextSearchOperator.Contains : FullTextSearchOperator.Freetext, (string)objElements[0], objAlias);
                    break;
                default:
                    return null;
            }
            return predicate;
        }

        private object ConvertStringToFieldValue(IEntityField2 field, string fieldValueStr)
        {
            var dataValueStr = fieldValueStr.Trim('\'', '\"');
            var dataType = field.DataType;
            if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (string.IsNullOrEmpty(fieldValueStr))
                    return null; // it's ok to return null for nullable types

                dataType = dataType.GenericTypeArguments[0];
            }
            object dataValue = null;
            var cannotConvert = true;
            if (CanChangeType(fieldValueStr, dataType))
            {
                try
                {
                    dataValue = Convert.ChangeType(dataValueStr, dataType);
                    cannotConvert = false;
                }
                catch
                {
                }
            }
            if (cannotConvert)
                throw new ArgumentException(string.Format("Value '{0}' cannot be converted to type {1}.", dataValueStr, dataType));
            return dataValue;
        }

        private static bool CanChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                return false;
            }

            if (value == null)
            {
                return false;
            }

            var convertible = value as IConvertible;
            if (convertible == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}

