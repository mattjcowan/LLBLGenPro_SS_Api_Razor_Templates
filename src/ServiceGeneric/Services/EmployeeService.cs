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
    public partial class EmployeeService : ServiceBase<Employee, IEmployeeServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(EmployeeMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(EmployeeDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public EmployeeCollectionResponse Get(EmployeeQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }



        //Pk request
        public EmployeeResponse Get(EmployeePkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public EmployeeResponse Any(EmployeeAddRequest request)
        {
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
            return Repository.Create(request);
        }

        [Authenticate]
        public EmployeeResponse Any(EmployeeUpdateRequest request)
        {
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
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(EmployeeDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("employees/meta", Verbs = "GET")] // unique constraint filter
    public partial class EmployeeMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("employees/datatable", Verbs = "POST")] // general query
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
        public int iSortCol_4 { get; set; }
        public string sSortDir_4 { get; set; }
        public string bSortable_4 { get; set; } 
        public string mDataProp_4 { get; set; } 
        public string bRegex_4 { get; set; }
        public string bSearchable_4 { get; set; }
        public int iSortCol_5 { get; set; }
        public string sSortDir_5 { get; set; }
        public string bSortable_5 { get; set; } 
        public string mDataProp_5 { get; set; } 
        public string bRegex_5 { get; set; }
        public string bSearchable_5 { get; set; }
        public int iSortCol_6 { get; set; }
        public string sSortDir_6 { get; set; }
        public string bSortable_6 { get; set; } 
        public string mDataProp_6 { get; set; } 
        public string bRegex_6 { get; set; }
        public string bSearchable_6 { get; set; }
        public int iSortCol_7 { get; set; }
        public string sSortDir_7 { get; set; }
        public string bSortable_7 { get; set; } 
        public string mDataProp_7 { get; set; } 
        public string bRegex_7 { get; set; }
        public string bSearchable_7 { get; set; }
        public int iSortCol_8 { get; set; }
        public string sSortDir_8 { get; set; }
        public string bSortable_8 { get; set; } 
        public string mDataProp_8 { get; set; } 
        public string bRegex_8 { get; set; }
        public string bSearchable_8 { get; set; }
        public int iSortCol_9 { get; set; }
        public string sSortDir_9 { get; set; }
        public string bSortable_9 { get; set; } 
        public string mDataProp_9 { get; set; } 
        public string bRegex_9 { get; set; }
        public string bSearchable_9 { get; set; }
        public int iSortCol_10 { get; set; }
        public string sSortDir_10 { get; set; }
        public string bSortable_10 { get; set; } 
        public string mDataProp_10 { get; set; } 
        public string bRegex_10 { get; set; }
        public string bSearchable_10 { get; set; }
        public int iSortCol_11 { get; set; }
        public string sSortDir_11 { get; set; }
        public string bSortable_11 { get; set; } 
        public string mDataProp_11 { get; set; } 
        public string bRegex_11 { get; set; }
        public string bSearchable_11 { get; set; }
        public int iSortCol_12 { get; set; }
        public string sSortDir_12 { get; set; }
        public string bSortable_12 { get; set; } 
        public string mDataProp_12 { get; set; } 
        public string bRegex_12 { get; set; }
        public string bSearchable_12 { get; set; }
        public int iSortCol_13 { get; set; }
        public string sSortDir_13 { get; set; }
        public string bSortable_13 { get; set; } 
        public string mDataProp_13 { get; set; } 
        public string bRegex_13 { get; set; }
        public string bSearchable_13 { get; set; }
        public int iSortCol_14 { get; set; }
        public string sSortDir_14 { get; set; }
        public string bSortable_14 { get; set; } 
        public string mDataProp_14 { get; set; } 
        public string bRegex_14 { get; set; }
        public string bSearchable_14 { get; set; }
        public int iSortCol_15 { get; set; }
        public string sSortDir_15 { get; set; }
        public string bSortable_15 { get; set; } 
        public string mDataProp_15 { get; set; } 
        public string bRegex_15 { get; set; }
        public string bSearchable_15 { get; set; }
        public int iSortCol_16 { get; set; }
        public string sSortDir_16 { get; set; }
        public string bSortable_16 { get; set; } 
        public string mDataProp_16 { get; set; } 
        public string bRegex_16 { get; set; }
        public string bSearchable_16 { get; set; }
        public int iSortCol_17 { get; set; }
        public string sSortDir_17 { get; set; }
        public string bSortable_17 { get; set; } 
        public string mDataProp_17 { get; set; } 
        public string bRegex_17 { get; set; }
        public string bSearchable_17 { get; set; }

    }



    [Route("employees/{EmployeeId}", Verbs = "GET")] // primary key filter
    public partial class EmployeePkRequest: GetRequest<Employee, EmployeeResponse>
    {
        public System.Int32 EmployeeId { get; set; }

    }

    [Route("employees", Verbs = "GET")] // general query
    [DefaultView("EmployeeView")]
    public partial class EmployeeQueryCollectionRequest : GetCollectionRequest<Employee, EmployeeCollectionResponse>
    {
    }

    [Route("employees", Verbs = "POST")] // add item
    public partial class EmployeeAddRequest : Employee, IReturn<EmployeeResponse>
    {
        public string PhotoSrcPath { get; set; }

    }

    [Route("employees/{EmployeeId}", Verbs = "PUT")] // update item
    [Route("employees/{EmployeeId}/update", Verbs = "POST")] // delete item
    public partial class EmployeeUpdateRequest : Employee, IReturn<EmployeeResponse>
    {
        public string PhotoSrcPath { get; set; }

    }

    [Route("employees/{EmployeeId}", Verbs = "DELETE")] // delete item
    [Route("employees/{EmployeeId}/delete", Verbs = "POST")] // delete item
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
    }

    public partial class EmployeeCollectionResponse : GetCollectionResponse<Employee>
    {
        public EmployeeCollectionResponse(): base(){}
        public EmployeeCollectionResponse(IEnumerable<Employee> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
