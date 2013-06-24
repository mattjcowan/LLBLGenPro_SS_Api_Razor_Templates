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
    /// <summary>Service class for the entity 'Employee'.</summary>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END            
    public partial class EmployeeService : ServiceBase<Employee, IEmployeeServiceRepository>
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        #region Class Extensibility Methods
        partial void OnCreateService();
        partial void OnBeforeGetEmployeeMetaRequest(EmployeeMetaRequest request);
        partial void OnAfterGetEmployeeMetaRequest(EmployeeMetaRequest request, EntityMetaDetailsResponse response);
        partial void OnBeforePostEmployeeDataTableRequest(EmployeeDataTableRequest request);
        partial void OnAfterPostEmployeeDataTableRequest(EmployeeDataTableRequest request, DataTableResponse response);
        partial void OnBeforeGetEmployeeQueryCollectionRequest(EmployeeQueryCollectionRequest request);
        partial void OnAfterGetEmployeeQueryCollectionRequest(EmployeeQueryCollectionRequest request, EmployeeCollectionResponse response);
        partial void OnBeforeGetEmployeePkRequest(EmployeePkRequest request);
        partial void OnAfterGetEmployeePkRequest(EmployeePkRequest request, EmployeeResponse response);

        partial void OnBeforeEmployeeAddRequest(EmployeeAddRequest request);
        partial void OnAfterEmployeeAddRequest(EmployeeAddRequest request, EmployeeResponse response);
        partial void OnBeforeEmployeeUpdateRequest(EmployeeUpdateRequest request);
        partial void OnAfterEmployeeUpdateRequest(EmployeeUpdateRequest request, EmployeeResponse response);
        partial void OnBeforeEmployeeDeleteRequest(EmployeeDeleteRequest request);
        partial void OnAfterEmployeeDeleteRequest(EmployeeDeleteRequest request, SimpleResponse<bool> deleted);

        #endregion
    
        
        public IValidator<Employee> Validator { get; set; }
    
        public EmployeeService()
        {
            OnCreateService();
        }
        
        /// <summary>Gets meta data information for the entity 'Employee' including field metadata and relation metadata.</summary>
        public EntityMetaDetailsResponse Get(EmployeeMetaRequest request)
        {
            OnBeforeGetEmployeeMetaRequest(request);
            var output = Repository.GetEntityMetaDetails(this);
            OnAfterGetEmployeeMetaRequest(request, output);
            return output;
        }

        /// <summary>Fetches 'Employee' entities matching the request formatted specifically for the datatables.net jquery plugin.</summary>
        public DataTableResponse Post(EmployeeDataTableRequest request)
        {
            OnBeforePostEmployeeDataTableRequest(request);
            var output = Repository.GetDataTableResponse(request);
            OnAfterPostEmployeeDataTableRequest(request, output);
            return output;
        }

        /// <summary>Queries 'Employee' entities using sorting, filtering, eager-loading, paging and more.</summary>
        public EmployeeCollectionResponse Get(EmployeeQueryCollectionRequest request)
        {
            OnBeforeGetEmployeeQueryCollectionRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetEmployeeQueryCollectionRequest(request, output);
            return output;
        }



        /// <summary>Gets a specific 'Employee' based on it's primary key.</summary>
        public EmployeeResponse Get(EmployeePkRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Employee { EmployeeId = request.EmployeeId }, "PkRequest");

            OnBeforeGetEmployeePkRequest(request);
            var output = Repository.Fetch(request);
            OnAfterGetEmployeePkRequest(request, output);
            if (output.Result == null)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Employee matching [EmployeeId = {0}]  does not exist".Fmt(request.EmployeeId));
            return output;
        }

        [Authenticate]
        public EmployeeResponse Any(EmployeeAddRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Post);
                
            OnBeforeEmployeeAddRequest(request);
            var filesInBytes = base.GetFilesInBytes();
            var filesUploaded = filesInBytes.Count;
            var fidx = 0;
      
            if(filesUploaded > 0)
            {
              if(!string.IsNullOrEmpty(request.PhotoSrcPath))
              {
                request.Photo = filesInBytes[fidx];
                fidx++;
              }
            }

            var output = Repository.Create(request);
            OnAfterEmployeeAddRequest(request, output);
            return output;
        }

        [Authenticate]
        public EmployeeResponse Any(EmployeeUpdateRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(request, ApplyTo.Put);
                
            OnBeforeEmployeeUpdateRequest(request);
            var filesInBytes = base.GetFilesInBytes();
            var filesUploaded = filesInBytes.Count;
            var fidx = 0;
      
            if(filesUploaded > 0)
            {
              if(!string.IsNullOrEmpty(request.PhotoSrcPath))
              {
                request.Photo = filesInBytes[fidx];
                fidx++;
              }
            }

            var output = Repository.Update(request);
            OnAfterEmployeeUpdateRequest(request, output);
            return output;
        }

        [Authenticate]
        public SimpleResponse<bool> Any(EmployeeDeleteRequest request)
        {
            if (Validator != null)
                Validator.ValidateAndThrow(new Employee { EmployeeId = request.EmployeeId }, ApplyTo.Delete);
                
            OnBeforeEmployeeDeleteRequest(request);
            var output = Repository.Delete(request);
            OnAfterEmployeeDeleteRequest(request, output);
            if (!output.Result)
                throw new HttpError(HttpStatusCode.NotFound, "NullReferenceException", "Employee matching [EmployeeId = {0}]  does not exist".Fmt(request.EmployeeId));
            return output;
        }


	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END 

    }
    #endregion

    #region Requests
    [Route("/employees/meta", Verbs = "GET")]
    public partial class EmployeeMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("/employees/datatable", Verbs = "POST")] // general query
    public partial class EmployeeDataTableRequest : GetCollectionRequest<Employee, EmployeeCollectionResponse>
    {
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public bool bEscapeRegex { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public string sEcho { get; set; }
        public string bRegex { get; set; }
        public int[] iSelectColumns { get; set; }

        public int iSortCol_0 { get; set; } //Field: EmployeeId
        public string sSortDir_0 { get; set; }
        public string bSortable_0 { get; set; } 
        public string mDataProp_0 { get; set; } 
        public string bRegex_0 { get; set; }
        public string bSearchable_0 { get; set; }
        public int iSortCol_1 { get; set; } //Field: LastName
        public string sSortDir_1 { get; set; }
        public string bSortable_1 { get; set; } 
        public string mDataProp_1 { get; set; } 
        public string bRegex_1 { get; set; }
        public string bSearchable_1 { get; set; }
        public int iSortCol_2 { get; set; } //Field: FirstName
        public string sSortDir_2 { get; set; }
        public string bSortable_2 { get; set; } 
        public string mDataProp_2 { get; set; } 
        public string bRegex_2 { get; set; }
        public string bSearchable_2 { get; set; }
        public int iSortCol_3 { get; set; } //Field: Title
        public string sSortDir_3 { get; set; }
        public string bSortable_3 { get; set; } 
        public string mDataProp_3 { get; set; } 
        public string bRegex_3 { get; set; }
        public string bSearchable_3 { get; set; }
        public int iSortCol_4 { get; set; } //Field: TitleOfCourtesy
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; } //Field: BirthDate
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; } //Field: HireDate
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; } //Field: Address
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; } //Field: City
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; } //Field: Region
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }
        public int iSortCol_10 { get; set; } //Field: PostalCode
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }
        public int iSortCol_11 { get; set; } //Field: Country
        public string sSortDir_11 { get; set; }
        public string bSortable_11 { get; set; } 
        public string mDataProp_11 { get; set; } 
        public string bRegex_11 { get; set; }
        public string bSearchable_11 { get; set; }
        public int iSortCol_12 { get; set; } //Field: HomePhone
        public string sSortDir_12 { get; set; }
        public string bSortable_12 { get; set; } 
        public string mDataProp_12 { get; set; } 
        public string bRegex_12 { get; set; }
        public string bSearchable_12 { get; set; }
        public int iSortCol_13 { get; set; } //Field: Extension
        public string sSortDir_13 { get; set; }
        public string bSortable_13 { get; set; } 
        public string mDataProp_13 { get; set; } 
        public string bRegex_13 { get; set; }
        public string bSearchable_13 { get; set; }
        public int iSortCol_14 { get; set; } //Field: Photo
        public string sSortDir_14 { get; set; }
        public string bSortable_14 { get; set; } 
        public string mDataProp_14 { get; set; } 
        public string bRegex_14 { get; set; }
        public string bSearchable_14 { get; set; }
        public int iSortCol_15 { get; set; } //Field: Notes
        public string sSortDir_15 { get; set; }
        public string bSortable_15 { get; set; } 
        public string mDataProp_15 { get; set; } 
        public string bRegex_15 { get; set; }
        public string bSearchable_15 { get; set; }
        public int iSortCol_16 { get; set; } //Field: ReportsToId
        public string sSortDir_16 { get; set; }
        public string bSortable_16 { get; set; } 
        public string mDataProp_16 { get; set; } 
        public string bRegex_16 { get; set; }
        public string bSearchable_16 { get; set; }
        public int iSortCol_17 { get; set; } //Field: PhotoPath
        public string sSortDir_17 { get; set; }
        public string bSortable_17 { get; set; } 
        public string mDataProp_17 { get; set; } 
        public string bRegex_17 { get; set; }
        public string bSearchable_17 { get; set; }

    }



    [Route("/employees/{EmployeeId}", Verbs = "GET")] // primary key filter
    public partial class EmployeePkRequest: GetRequest<Employee, EmployeeResponse>
    {
        public System.Int32 EmployeeId { get; set; }

    }

    [Route("/employees", Verbs = "GET")] // general query
    [DefaultView("EmployeeView")]
    public partial class EmployeeQueryCollectionRequest : GetCollectionRequest<Employee, EmployeeCollectionResponse>
    {
    }

    [Route("/employees", Verbs = "POST")] // add item
    public partial class EmployeeAddRequest : Employee, IReturn<EmployeeResponse>
    {
        public string PhotoSrcPath { get; set; }

    }

    [Route("/employees/{EmployeeId}", Verbs = "PUT")] // update item
    [Route("/employees/{EmployeeId}/update", Verbs = "POST")] // delete item
    public partial class EmployeeUpdateRequest : Employee, IReturn<EmployeeResponse>
    {
        public string PhotoSrcPath { get; set; }

    }

    [Route("/employees/{EmployeeId}", Verbs = "DELETE")] // delete item
    [Route("/employees/{EmployeeId}/delete", Verbs = "POST")] // delete item
    public partial class EmployeeDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 EmployeeId { get; set; }

    }
    #endregion

    #region Responses
    public partial class EmployeeResponse : GetResponse<Employee>
    {
        public EmployeeResponse() : base() { }
        public EmployeeResponse(Employee category) : base(category) { }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }

    public partial class EmployeeCollectionResponse : GetCollectionResponse<Employee>
    {
        public EmployeeCollectionResponse(): base(){}
        public EmployeeCollectionResponse(IEnumerable<Employee> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcCollectionResponseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       
    }
    #endregion
}
