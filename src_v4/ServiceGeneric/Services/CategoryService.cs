using System;
using System.Collections.Generic;
using System.Net;
using ServiceStack.Common.Web;
using ServiceStack.FluentValidation;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.ServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services
{
    #region Service
    /// <summary>Service class for the entity 'Category'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END  
    public partial class CategoryService : ServiceBase<Category, ICategoryServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetCategoryMetaRequest(CategoryMetaRequest request);
        partial void OnAfterGetCategoryMetaRequest(CategoryMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostCategoryDataTableRequest(CategoryDataTableRequest request);
        partial void OnAfterPostCategoryDataTableRequest(CategoryDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetCategoryQueryCollectionRequest(CategoryQueryCollectionRequest request);
        partial void OnAfterGetCategoryQueryCollectionRequest(CategoryQueryCollectionRequest request, CategoryCollectionResponse response);
        partial void OnBeforeGetCategoryUcCategoryNameRequest(CategoryUcCategoryNameRequest request);
        partial void OnAfterGetCategoryUcCategoryNameRequest(CategoryUcCategoryNameRequest request, CategoryResponse response);
        partial void OnBeforeGetCategoryPkRequest(CategoryPkRequest request);
        partial void OnAfterGetCategoryPkRequest(CategoryPkRequest request, CategoryResponse response);
        partial void OnBeforeCategoryAddRequest(CategoryAddRequest request);
        partial void OnAfterCategoryAddRequest(CategoryAddRequest request, CategoryResponse response);
        partial void OnBeforeCategoryUpdateRequest(CategoryUpdateRequest request);
        partial void OnAfterCategoryUpdateRequest(CategoryUpdateRequest request, CategoryResponse response);
        partial void OnBeforeCategoryDeleteRequest(CategoryDeleteRequest request);
        partial void OnAfterCategoryDeleteRequest(CategoryDeleteRequest request, SimpleResponse<bool> deleted);
        #endregion
    
        
        public IValidator<Category> Validator { get; set; }
    
        public CategoryService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Category' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(CategoryMetaRequest request)
        {
            OnBeforeGetCategoryMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetCategoryMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Category' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(CategoryDataTableRequest request)
        {
            OnBeforePostCategoryDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostCategoryDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Category' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public CategoryCollectionResponse Get(CategoryQueryCollectionRequest request)
        {
            OnBeforeGetCategoryQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCategoryQueryCollectionRequest(request, output);
            return output;
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        /// <summary>Gets a specific 'Category' based on the 'UcCategoryName' unique constraint.</summary>
        public CategoryResponse Get(CategoryUcCategoryNameRequest request)
        {
            if(Validator != null)
                Validator.ValidateAndThrow(new Category { CategoryName = request.CategoryName }, "UcCategoryName");
                
            OnBeforeGetCategoryUcCategoryNameRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCategoryUcCategoryNameRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Category matching [CategoryName = {0}]  does not exist".Fmt(request.CategoryName));
            return output;
        }


        /// <summary>Gets a specific 'Category' based on it's primary key.</summary>
        public CategoryResponse Get(CategoryPkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Category { CategoryId = request.CategoryId }, "PkRequest");

            OnBeforeGetCategoryPkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetCategoryPkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Category matching [CategoryId = {0}]  does not exist".Fmt(request.CategoryId));
            return output;
        }

        [Authenticate]
        public CategoryResponse Any(CategoryAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeCategoryAddRequest(request);
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

            var output = Repository.Create(request);
            OnAfterCategoryAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public CategoryResponse Any(CategoryUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeCategoryUpdateRequest(request);
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

            var output = Repository.Update(request);
            OnAfterCategoryUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(CategoryDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Category { CategoryId = request.CategoryId }, ApplyTo.Delete);
                
            OnBeforeCategoryDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterCategoryDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Category matching [CategoryId = {0}]  does not exist".Fmt(request.CategoryId));
            return output;
        }

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/categories/meta", Verbs = "GET")]
    public partial class CategoryMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/categories/datatable", Verbs = "POST")] // general query
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

    [Route("/categories/uc/categoryname/{CategoryName}", Verbs = "GET")] // unique constraint filter
    public partial class CategoryUcCategoryNameRequest : GetRequest<Category, CategoryResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CategoryName { get; set; }

    }


    [Route("/categories/{CategoryId}", Verbs = "GET")] // primary key filter
    public partial class CategoryPkRequest: GetRequest<Category, CategoryResponse>
    {
        public System.Int32 CategoryId { get; set; }

    }

    [Route("/categories", Verbs = "GET")] // general query
    [DefaultView("CategoryView")]
    public partial class CategoryQueryCollectionRequest : GetCollectionRequest<Category, CategoryCollectionResponse>
    {
    }

    [Route("/categories", Verbs = "POST")] // add item
    public partial class CategoryAddRequest : Category, IReturn<CategoryResponse>
    {
        public string PictureSrcPath { get; set; }

    }

    [Route("/categories/{CategoryId}", Verbs = "PUT")] // update item
    [Route("/categories/{CategoryId}/update", Verbs = "POST")] // delete item
    public partial class CategoryUpdateRequest : Category, IReturn<CategoryResponse>
    {
        public string PictureSrcPath { get; set; }

    }

    [Route("/categories/{CategoryId}", Verbs = "DELETE")] // delete item
    [Route("/categories/{CategoryId}/delete", Verbs = "POST")] // delete item
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
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }

    public partial class CategoryCollectionResponse : GetCollectionResponse<Category>
    {
        public CategoryCollectionResponse(): base(){}
        public CategoryCollectionResponse(IEnumerable<Category> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END   
    }
    #endregion
}
