using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;

namespace Northwind.Data.Dtos
{ 
  //[Serializable]
  public partial class CustomerCustomerDemoCollection : CommonDtoBaseCollection<CustomerCustomerDemo>
  {
      public CustomerCustomerDemoCollection(){}
      public CustomerCustomerDemoCollection(IEnumerable<CustomerCustomerDemo> collection): base(collection ?? new List<CustomerCustomerDemo>()){}
      public CustomerCustomerDemoCollection(List<CustomerCustomerDemo> list): base(list ?? new List<CustomerCustomerDemo>()){}
  }

  //[Serializable]
  public partial class CustomerCustomerDemo : CommonDtoBase<CustomerCustomerDemo>
  {
    public CustomerCustomerDemo()
    {
    }

    /// <summary>Factory method to create a new instance of the type 'CustomerCustomerDemo' (includes only required properties)</summary>
    /// <param name="customerId">The initial value for the field 'CustomerId'</param>  
    /// <param name="customerTypeId">The initial value for the field 'CustomerTypeId'</param>  
    public static CustomerCustomerDemo Create(System.String customerId, System.String customerTypeId)
    {
      var entity = new CustomerCustomerDemo();
      entity.CustomerId = customerId;
      entity.CustomerTypeId = customerTypeId;
      return entity;
    }


    #region Class Property Declarations
  
    /// <summary>Gets or sets the CustomerId field. </summary>
    public virtual System.String CustomerId { get; set; }  

    /// <summary>Gets or sets the CustomerTypeId field. </summary>
    public virtual System.String CustomerTypeId { get; set; }  

    /// <summary>Represents the navigator which is mapped onto the association 'CustomerCustomerDemo.Customer - Customer.CustomerCustomerDemos (m:1)'</summary>
    [Browsable(false)]
    public virtual Customer Customer { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'CustomerCustomerDemo.CustomerDemographic - CustomerDemographic.CustomerCustomerDemos (m:1)'</summary>
    [Browsable(false)]
    public virtual CustomerDemographic CustomerDemographic { get; set; } 

    #endregion

  }
}
