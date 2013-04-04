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
  public partial class ProductCollection : CommonDtoBaseCollection<Product>
  {
      public ProductCollection(){}
      public ProductCollection(IEnumerable<Product> collection): base(collection ?? new List<Product>()){}
      public ProductCollection(List<Product> list): base(list ?? new List<Product>()){}
  }

  public partial class Product : CommonDtoBase<Product>
  {
    public Product()
    {
      this.OrderDetails = new OrderDetailCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Product' (includes only required properties)</summary>
    /// <param name="productId">The initial value for the field 'ProductId'</param>  
    /// <param name="productName">The initial value for the field 'ProductName'</param>  
    /// <param name="discontinued">The initial value for the field 'Discontinued'</param>  
    public static Product Create(System.Int32 productId, System.String productName, System.Boolean discontinued)
    {
      var entity = new Product();
      entity.ProductId = productId;
      entity.ProductName = productName;
      entity.Discontinued = discontinued;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Product' (includes optional properties)</summary>
    /// <param name="productId">The initial value for the field 'ProductId'</param>  
    /// <param name="productName">The initial value for the field 'ProductName'</param>  
    /// <param name="supplierId">The initial value for the field 'SupplierId'</param>  
    /// <param name="categoryId">The initial value for the field 'CategoryId'</param>  
    /// <param name="quantityPerUnit">The initial value for the field 'QuantityPerUnit'</param>  
    /// <param name="unitPrice">The initial value for the field 'UnitPrice'</param>  
    /// <param name="unitsInStock">The initial value for the field 'UnitsInStock'</param>  
    /// <param name="unitsOnOrder">The initial value for the field 'UnitsOnOrder'</param>  
    /// <param name="reorderLevel">The initial value for the field 'ReorderLevel'</param>  
    /// <param name="discontinued">The initial value for the field 'Discontinued'</param>  
    public static Product Create(System.Int32 productId, System.String productName, Nullable<System.Int32> supplierId, Nullable<System.Int32> categoryId, System.String quantityPerUnit, Nullable<System.Decimal> unitPrice, Nullable<System.Int16> unitsInStock, Nullable<System.Int16> unitsOnOrder, Nullable<System.Int16> reorderLevel, System.Boolean discontinued)
    {
      var entity = new Product();
      entity.ProductId = productId;
      entity.ProductName = productName;
      entity.SupplierId = supplierId;
      entity.CategoryId = categoryId;
      entity.QuantityPerUnit = quantityPerUnit;
      entity.UnitPrice = unitPrice;
      entity.UnitsInStock = unitsInStock;
      entity.UnitsOnOrder = unitsOnOrder;
      entity.ReorderLevel = reorderLevel;
      entity.Discontinued = discontinued;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the ProductId field. </summary>
    public virtual System.Int32 ProductId  { get; set; }

    /// <summary>Gets or sets the ProductName field. </summary>
    public virtual System.String ProductName  { get; set; }

    /// <summary>Gets or sets the SupplierId field. </summary>
    public virtual Nullable<System.Int32> SupplierId { get; set; }  

    /// <summary>Gets or sets the CategoryId field. </summary>
    public virtual Nullable<System.Int32> CategoryId { get; set; }  

    /// <summary>Gets or sets the QuantityPerUnit field. </summary>
    public virtual System.String QuantityPerUnit  { get; set; }

    /// <summary>Gets or sets the UnitPrice field. </summary>
    public virtual Nullable<System.Decimal> UnitPrice  { get; set; }

    /// <summary>Gets or sets the UnitsInStock field. </summary>
    public virtual Nullable<System.Int16> UnitsInStock  { get; set; }

    /// <summary>Gets or sets the UnitsOnOrder field. </summary>
    public virtual Nullable<System.Int16> UnitsOnOrder  { get; set; }

    /// <summary>Gets or sets the ReorderLevel field. </summary>
    public virtual Nullable<System.Int16> ReorderLevel  { get; set; }

    /// <summary>Gets or sets the Discontinued field. </summary>
    public virtual System.Boolean Discontinued  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Product.Category - Category.Products (m:1)'</summary>
    [Browsable(false)]
    public virtual Category Category { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'OrderDetail.Product - Product.OrderDetails (m:1)'</summary>
    public virtual OrderDetailCollection OrderDetails { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Product.Supplier - Supplier.Products (m:1)'</summary>
    [Browsable(false)]
    public virtual Supplier Supplier { get; set; } 

    #endregion

  }
}
