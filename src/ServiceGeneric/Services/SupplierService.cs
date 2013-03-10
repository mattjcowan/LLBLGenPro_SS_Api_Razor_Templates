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
    public partial class SupplierService : ServiceBase<Supplier, ISupplierServiceRepository>
    {
        //Meta request
        public EntityMetaDetailsResponse Get(SupplierMetaRequest request)
        {
            return Repository.GetEntityMetaDetails(this);
        }

        //DataTable request
        public DataTableResponse Post(SupplierDataTableRequest request)
        {
            return Repository.GetDataTableResponse(request);
        }

        //Collection/query request
        public SupplierCollectionResponse Get(SupplierQueryCollectionRequest request)
        {
            return Repository.Fetch(request);
        }


        //Unique constraint request go first (the order matters in service stack)
        //If the PK constraint was first, it could be used by ServiceStack instead
        //of the UC route (this is how Route order is controlled)
        public SupplierResponse Get(SupplierUcSupplierNameRequest request)
        {
            return Repository.Fetch(request);
        }


        //Pk request
        public SupplierResponse Get(SupplierPkRequest request)
        {
            return Repository.Fetch(request);
        }

        [Authenticate]
        public SupplierResponse Any(SupplierAddRequest request)
        {
            return Repository.Create(request);
        }

        [Authenticate]
        public SupplierResponse Any(SupplierUpdateRequest request)
        {
            return Repository.Update(request);
        }

        [Authenticate]
        public bool Any(SupplierDeleteRequest request)
        {
            return Repository.Delete(request);
        }
    }
    #endregion

    #region Requests
    [Route("suppliers/meta", Verbs = "GET")] // unique constraint filter
    public partial class SupplierMetaRequest : IReturn<EntityMetaDetailsResponse>
    {
    }

    [Route("suppliers/datatable", Verbs = "POST")] // general query
    public partial class SupplierDataTableRequest : GetCollectionRequest<Supplier, SupplierCollectionResponse>
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

    }

    [Route("suppliers/uc/suppliername/{CompanyName}", Verbs = "GET")] // unique constraint filter
    public partial class SupplierUcSupplierNameRequest : GetRequest<Supplier, SupplierResponse>
    {
        // unique constraint fields (that are not also primary key fields)
        public System.String CompanyName { get; set; }

    }


    [Route("suppliers/{SupplierId}", Verbs = "GET")] // primary key filter
    public partial class SupplierPkRequest: GetRequest<Supplier, SupplierResponse>
    {
        public System.Int32 SupplierId { get; set; }

    }

    [Route("suppliers", Verbs = "GET")] // general query
    [DefaultView("SupplierView")]
    public partial class SupplierQueryCollectionRequest : GetCollectionRequest<Supplier, SupplierCollectionResponse>
    {
    }

    [Route("suppliers", Verbs = "POST")] // add item
    public partial class SupplierAddRequest : Supplier, IReturn<SupplierResponse>
    {

    }

    [Route("suppliers/{SupplierId}", Verbs = "PUT")] // update item
    [Route("suppliers/{SupplierId}/update", Verbs = "POST")] // delete item
    public partial class SupplierUpdateRequest : Supplier, IReturn<SupplierResponse>
    {

    }

    [Route("suppliers/{SupplierId}", Verbs = "DELETE")] // delete item
    [Route("suppliers/{SupplierId}/delete", Verbs = "POST")] // delete item
    public partial class SupplierDeleteRequest: SimpleRequest<bool>
    {
        public System.Int32 SupplierId { get; set; }

    }
    #endregion

    #region Responses
    public partial class SupplierResponse : GetResponse<Supplier>
    {
        public SupplierResponse() : base() { }
        public SupplierResponse(Supplier category) : base(category) { }
    }

    public partial class SupplierCollectionResponse : GetCollectionResponse<Supplier>
    {
        public SupplierCollectionResponse(): base(){}
        public SupplierCollectionResponse(IEnumerable<Supplier> collection, int pageNumber, int pageSize, int totalItemCount) : 
            base(collection, pageNumber, pageSize, totalItemCount){}
    }
    #endregion
}
