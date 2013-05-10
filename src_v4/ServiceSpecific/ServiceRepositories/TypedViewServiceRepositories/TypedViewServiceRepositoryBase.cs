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
using Northwind.Data.Dtos.TypedViewDtos;
using Northwind.Data.EntityClasses;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using Northwind.Data.Helpers;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedViewServiceInterfaces;
using Northwind.Data.Services;

namespace Northwind.Data.ServiceRepositories.TypedViewServiceRepositories
{
    public abstract class TypedViewServiceRepositoryBase<TDto> : ITypedViewServiceRepository<TDto>
        where TDto : CommonTypedViewDtoBase
    {
        public ICacheClient CacheClient { get; set; }
        public abstract IDataAccessAdapterFactory DataAccessAdapterFactory { get; set; }
        protected abstract TypedViewType TypedViewType { get; }

        internal virtual IDictionary<string, IEntityField2> FieldMap
        {
            get { return GetFieldMap(TypedViewType); }
            set { }
        }

        #region Fetch Methods

        public TypedViewMetaDetailsResponse GetTypedViewMetaDetails(ServiceStack.ServiceInterface.Service service)
        {
            // The entity meta details don't change per type, so cache these for performance
            var cacheKey = string.Format("{0}-typedview-meta-details", TypedViewType.ToString().ToLower());
            var metaDetails = CacheClient.Get<TypedViewMetaDetailsResponse>(cacheKey);
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
                var link = Link.Create(
                  f.Key.ToCamelCase(), f.Value.DataType.Name, "field",
                  string.Format("{0}?select={1}{2}", baseServiceUri, f.Key.ToLowerInvariant(), queryString),
                  string.Format("The {0} field for the {1} resource.", f.Value.Name, typeof(TDto).Name),
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

            metaDetails = new TypedViewMetaDetailsResponse()
            {
                Fields = fields.ToArray(),
            };
            CacheClient.Set(cacheKey, metaDetails);
            return metaDetails;
        }
        
        internal void FixupLimitAndPagingOnRequest(GetTypedViewCollectionRequest request)
        {
            if (request.PageNumber > 0 || request.PageSize > 0)
                request.Limit = 0; // override the limit, paging takes precedence if specified

            if (request.PageNumber < 1) request.PageNumber = 1;
            if (request.PageSize < 1) request.PageSize = 10;
        }

        #endregion

        #region Static Helper Methods

        private static IDictionary<string, IEntityField2> GetFieldMap(TypedViewType typedViewType)
        {
            return EntityFieldsFactory.CreateTypedViewEntityFieldsObject(typedViewType)
                                      .ToDictionary(k => k.Name, v => (IEntityField2) v);
        }

        #endregion
    }
}

