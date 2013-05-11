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
using Northwind.Data.Dtos.TypedListDtos;
using Northwind.Data.EntityClasses;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using Northwind.Data.Helpers;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceRepositories.TypedListServiceRepositories
{
    public abstract class TypedListServiceRepositoryBase<TDto> : ITypedListServiceRepository<TDto>
        where TDto : CommonTypedListDtoBase
    {
        public ICacheClient CacheClient { get; set; }
        public abstract IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected abstract TypedListType TypedListType { get; }

        internal virtual IDictionary<string, IEntityField2> FieldMap
        {
            get { return GetFieldMap(TypedListType); }
            set { }
        }

        #region Fetch Methods

        public TypedListMetaDetailsResponse GetTypedListMetaDetails(ServiceStack.ServiceInterface.Service service)
        {
            // The entity meta details don't change per type, so cache these for performance
            var cacheKey = string.Format("{0}-typedlist-meta-details", TypedListType.ToString().ToLower());
            var metaDetails = CacheClient.Get<TypedListMetaDetailsResponse>(cacheKey);
            if (metaDetails != null)
                return metaDetails;

            var request = service.RequestContext.Get<IHttpRequest>();
            var appUri = request.GetApplicationUrl().TrimEnd('/');
            var baseServiceUri = appUri + request.PathInfo.Replace("/meta", "");
            var queryString = request.QueryString["format"] != null ? "&format=" + request.QueryString["format"] : "";
            var pkCount = FieldMap.Count(pk => pk.Value.IsPrimaryKey);
            var fields = new List<Link>();
            var fieldIndex = -1;
            foreach (var f in FieldMap)
            {
                fieldIndex++;
                var isUnique = false;
                var link = Link.Create(
                  f.Key.ToCamelCase(), f.Value.DataType.Name, "field",
                  string.Format("{0}?select={1}{2}", baseServiceUri, f.Key.ToLowerInvariant(), queryString),
                  string.Format("The {0} field for the {1} resource.", f.Value.Name, typeof(TDto).Name),
                  new Dictionary<string, string>()
                );
                var props = new SortedDictionary<string, string>();
                props.Add("index", fieldIndex.ToString() /*WRONG: f.Value.FieldIndex.ToString(CultureInfo.InvariantCulture)*/);
                if (f.Value.IsPrimaryKey)
                {
                    props.Add("isPrimaryKey", f.Value.IsPrimaryKey.ToString().ToLower());
                    if (pkCount == 1) isUnique = true;
                }
                if (f.Value.IsForeignKey)
                    props.Add("isForeignKey", "true");

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

            metaDetails = new TypedListMetaDetailsResponse()
            {
                Fields = fields.ToArray(),
            };
            CacheClient.Set(cacheKey, metaDetails);
            return metaDetails;
        }
        
        internal void FixupLimitAndPagingOnRequest(GetTypedListCollectionRequest request)
        {
            if (request.PageNumber > 0 || request.PageSize > 0)
                request.Limit = 0; // override the limit, paging takes precedence if specified

            if (request.PageNumber < 1) request.PageNumber = 1;
            if (request.PageSize < 1) request.PageSize = 10;
        }

        #endregion

        #region Static Helper Methods

        private static IDictionary<string, IEntityField2> GetFieldMap(TypedListType typedListType)
        {
            return EntityFieldsFactory.CreateTypedListEntityFieldsObject(typedListType)
                                      .ToDictionary(k => k.Alias, v => (IEntityField2) v);
        }

        #endregion
    }
}

