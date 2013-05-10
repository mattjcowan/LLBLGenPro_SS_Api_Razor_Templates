using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;

namespace Northwind.Data.Dtos.TypedListDtos
{
    #region Get Request/Response

    public abstract partial class GetTypedListCollectionRequest
    {
        protected GetTypedListCollectionRequest()
        {
            PageNumber = 0;
            PageSize = 0;
            Limit = 0;
            Sort = string.Empty;
            Select = string.Empty;
            Filter = string.Empty;
        }
        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Limit { get; set; }
        public string Sort { get; set; }
        public string Select { get; set; }
        public string Filter { get; set; }
    }

    public abstract partial class GetTypedListCollectionRequest<TDto, TResponse> : GetTypedListCollectionRequest, IReturn<TResponse>
        where TResponse: GetTypedListCollectionResponse<TDto>
    {
        protected GetTypedListCollectionRequest()
            : base()
        {
        }
    }
    
    public abstract partial class GetTypedListCollectionResponse<TDto>
    {
        protected GetTypedListCollectionResponse()
        {
        }

        protected GetTypedListCollectionResponse(IEnumerable<TDto> collection, int pageNumber, int pageSize, int totalItemCount): this()
        {            
            var pagedList = new StaticPagedList<TDto>(collection, pageNumber, pageSize, totalItemCount);
            Result = pagedList.Subset;
            Paging = new PagingDetails(pagedList);
        }

        public List<TDto> Result { get; set; }

        public PagingDetails Paging { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
  
    #endregion

    #region Miscellaneous
  
    public partial class TypedListMetaDetailsResponse
    {
        public Link[] Fields { get; set; }
    }
  
    #endregion
}
