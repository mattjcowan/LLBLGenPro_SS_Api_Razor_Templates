using System;
using System.Collections.Generic;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;

namespace Northwind.Data.Services
{
    #region Service
    public partial class CategoryService : ServiceBase<Category, ICategoryServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(CategoryMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(CategoryDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public CategoryCollectionResponse Get(CategoryQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public CategoryResponse Get(CategoryUcCategoryNameRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public CategoryResponse Get(CategoryPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public CategoryResponse Any(CategoryAddRequest request)
        {
            var filesInBytes = base.GetFilesInBytes();
            var filesUploaded = filesInBytes.Count;
            var fidx = 0;
      
            if(filesUploaded > 0)
            {
              if(!string.IsNullOrEmpty(request.PictureSrcPath))
              {
                request.Picture = filesInBytes[fidx];
                fidx++;
              }
            }
            return Repository.Create(request);
        }

        [Authenticate]
        public CategoryResponse Any(CategoryUpdateRequest request)
        {
            var filesInBytes = base.GetFilesInBytes();
            var filesUploaded = filesInBytes.Count;
            var fidx = 0;
      
            if(filesUploaded > 0)
            {
              if(!string.IsNullOrEmpty(request.PictureSrcPath))
              {
                request.Picture = filesInBytes[fidx];
                fidx++;
              }
            }
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(CategoryDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("categories/meta", Verbs = "GET")] // unique constraint filter
    public partial class CategoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("categories/datatable", Verbs = "POST")] // general query
    public partial class CategoryDataTableRequest : GetCollectionRequest<Category, CategoryCollectionResponse>
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public bool bEscapeRegex { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public string sEcho { get; set; }
        public string bRegex { get; set; }

        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; }
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; }
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; }
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }

    }

    [Route("categories/uc/categoryname/{CategoryName}", Verbs = "GET")] // unique constraint filter
    public partial class CategoryUcCategoryNameRequest : GetRequest<Category, CategoryResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CategoryName { get; set; }

    }


    [Route("categories/{CategoryId}", Verbs = "GET")] // primary key filter
    public partial class CategoryPkRequest: GetRequest<Category, CategoryResponse>
    {
        public System.Int32 CategoryId { get; set; }

    }

    [Route("categories", Verbs = "GET")] // general query
    [DefaultView("CategoryView")]
    public partial class CategoryQueryCollectionRequest : GetCollectionRequest<Category, CategoryCollectionResponse>
    {
    }

    [Route("categories", Verbs = "POST")] // add item
    public partial class CategoryAddRequest : Category, IReturn<CategoryResponse>
    {
        public string PictureSrcPath { get; set; }

    }

    [Route("categories/{CategoryId}", Verbs = "PUT")] // update item
    [Route("categories/{CategoryId}/update", Verbs = "POST")] // delete item
    public partial class CategoryUpdateRequest : Category, IReturn<CategoryResponse>
    {
        public string PictureSrcPath { get; set; }

    }

    [Route("categories/{CategoryId}", Verbs = "DELETE")] // delete item
    [Route("categories/{CategoryId}/delete", Verbs = "POST")] // delete item
    public partial class CategoryDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 CategoryId { get; set; }

    }
    #endregion

    #region Responses
    public partial class CategoryResponse : GetResponse<Category>
    {
        public CategoryResponse() : base() { }
        public CategoryResponse(Category category) : base(category) { }
    }

    public partial class CategoryCollectionResponse : GetCollectionResponse<Category>
    {
        public CategoryCollectionResponse(): base(){}
        public CategoryCollectionResponse(IEnumerable<Category> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
