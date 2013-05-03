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
  public partial class CustomerDemographicCollection : CommonDtoBaseCollection<CustomerDemographic>
  {
      public CustomerDemographicCollection(){}
      public CustomerDemographicCollection(IEnumerable<CustomerDemographic> collection): base(collection ?? new List<CustomerDemographic>()){}
      public CustomerDemographicCollection(List<CustomerDemographic> list): base(list ?? new List<CustomerDemographic>()){}
  }

  public partial class CustomerDemographic : CommonDtoBase<CustomerDemographic>
  {
    public CustomerDemographic()
    {
      this.CustomerCustomerDemos = new CustomerCustomerDemoCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'CustomerDemographic' (includes only required properties)</summary>
    /// <param name="customerTypeId">The initial value for the field 'CustomerTypeId'</param>  
    public static CustomerDemographic Create(System.String customerTypeId)
    {
      var entity = new CustomerDemographic();
      entity.CustomerTypeId = customerTypeId;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'CustomerDemographic' (includes optional properties)</summary>
    /// <param name="customerTypeId">The initial value for the field 'CustomerTypeId'</param>  
    /// <param name="customerDesc">The initial value for the field 'CustomerDesc'</param>  
    public static CustomerDemographic Create(System.String customerTypeId, System.String customerDesc)
    {
      var entity = new CustomerDemographic();
      entity.CustomerTypeId = customerTypeId;
      entity.CustomerDesc = customerDesc;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the CustomerTypeId field. </summary>
    public virtual System.String CustomerTypeId  { get; set; }

    /// <summary>Gets or sets the CustomerDesc field. </summary>
    public virtual System.String CustomerDesc  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'CustomerCustomerDemo.CustomerDemographic - CustomerDemographic.CustomerCustomerDemos (m:1)'</summary>
    public virtual CustomerCustomerDemoCollection CustomerCustomerDemos { get; set; }

    #endregion

  }
}
