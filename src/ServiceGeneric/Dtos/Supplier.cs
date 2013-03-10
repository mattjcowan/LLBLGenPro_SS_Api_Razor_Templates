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
  [Serializable]
  public partial class SupplierCollection : CommonDtoBaseCollection<Supplier>
  {
      public SupplierCollection(){}
      public SupplierCollection(IEnumerable<Supplier> collection): base(collection ?? new List<Supplier>()){}
      public SupplierCollection(List<Supplier> list): base(list ?? new List<Supplier>()){}
  }

  [Serializable]
  public partial class Supplier : CommonDtoBase<Supplier>
  {
    public Supplier()
    {
      this.Products = new ProductCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Supplier' (includes only required properties)</summary>
    /// <param name="supplierId">The initial value for the field 'SupplierId'</param>  
    /// <param name="companyName">The initial value for the field 'CompanyName'</param>  
    public static Supplier Create(System.Int32 supplierId, System.String companyName)
    {
      var entity = new Supplier();
      entity.SupplierId = supplierId;
      entity.CompanyName = companyName;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Supplier' (includes optional properties)</summary>
    /// <param name="supplierId">The initial value for the field 'SupplierId'</param>  
    /// <param name="companyName">The initial value for the field 'CompanyName'</param>  
    /// <param name="contactName">The initial value for the field 'ContactName'</param>  
    /// <param name="contactTitle">The initial value for the field 'ContactTitle'</param>  
    /// <param name="address">The initial value for the field 'Address'</param>  
    /// <param name="city">The initial value for the field 'City'</param>  
    /// <param name="region">The initial value for the field 'Region'</param>  
    /// <param name="postalCode">The initial value for the field 'PostalCode'</param>  
    /// <param name="country">The initial value for the field 'Country'</param>  
    /// <param name="phone">The initial value for the field 'Phone'</param>  
    /// <param name="fax">The initial value for the field 'Fax'</param>  
    /// <param name="homePage">The initial value for the field 'HomePage'</param>  
    public static Supplier Create(System.Int32 supplierId, System.String companyName, System.String contactName, System.String contactTitle, System.String address, System.String city, System.String region, System.String postalCode, System.String country, System.String phone, System.String fax, System.String homePage)
    {
      var entity = new Supplier();
      entity.SupplierId = supplierId;
      entity.CompanyName = companyName;
      entity.ContactName = contactName;
      entity.ContactTitle = contactTitle;
      entity.Address = address;
      entity.City = city;
      entity.Region = region;
      entity.PostalCode = postalCode;
      entity.Country = country;
      entity.Phone = phone;
      entity.Fax = fax;
      entity.HomePage = homePage;
      return entity;
    }

    #region Class Property Declarations
	
    /// <summary>Gets or sets the SupplierId field. </summary>
    public virtual System.Int32 SupplierId  { get; set; }

    /// <summary>Gets or sets the CompanyName field. </summary>
    public virtual System.String CompanyName  { get; set; }

    /// <summary>Gets or sets the ContactName field. </summary>
    public virtual System.String ContactName  { get; set; }

    /// <summary>Gets or sets the ContactTitle field. </summary>
    public virtual System.String ContactTitle  { get; set; }

    /// <summary>Gets or sets the Address field. </summary>
    public virtual System.String Address  { get; set; }

    /// <summary>Gets or sets the City field. </summary>
    public virtual System.String City  { get; set; }

    /// <summary>Gets or sets the Region field. </summary>
    public virtual System.String Region  { get; set; }

    /// <summary>Gets or sets the PostalCode field. </summary>
    public virtual System.String PostalCode  { get; set; }

    /// <summary>Gets or sets the Country field. </summary>
    public virtual System.String Country  { get; set; }

    /// <summary>Gets or sets the Phone field. </summary>
    public virtual System.String Phone  { get; set; }

    /// <summary>Gets or sets the Fax field. </summary>
    public virtual System.String Fax  { get; set; }

    /// <summary>Gets or sets the HomePage field. </summary>
    public virtual System.String HomePage  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Product.Supplier - Supplier.Products (m:1)'</summary>
    public virtual ProductCollection Products { get; set; }

    #endregion

  }
}
