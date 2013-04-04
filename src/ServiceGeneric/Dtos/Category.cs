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
  public partial class CategoryCollection : CommonDtoBaseCollection<Category>
  {
      public CategoryCollection(){}
      public CategoryCollection(IEnumerable<Category> collection): base(collection ?? new List<Category>()){}
      public CategoryCollection(List<Category> list): base(list ?? new List<Category>()){}
  }

  public partial class Category : CommonDtoBase<Category>
  {
    public Category()
    {
      this.Products = new ProductCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Category' (includes only required properties)</summary>
    /// <param name="categoryId">The initial value for the field 'CategoryId'</param>  
    /// <param name="categoryName">The initial value for the field 'CategoryName'</param>  
    public static Category Create(System.Int32 categoryId, System.String categoryName)
    {
      var entity = new Category();
      entity.CategoryId = categoryId;
      entity.CategoryName = categoryName;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Category' (includes optional properties)</summary>
    /// <param name="categoryId">The initial value for the field 'CategoryId'</param>  
    /// <param name="categoryName">The initial value for the field 'CategoryName'</param>  
    /// <param name="description">The initial value for the field 'Description'</param>  
    /// <param name="picture">The initial value for the field 'Picture'</param>  
    public static Category Create(System.Int32 categoryId, System.String categoryName, System.String description, System.Byte[] picture)
    {
      var entity = new Category();
      entity.CategoryId = categoryId;
      entity.CategoryName = categoryName;
      entity.Description = description;
      entity.Picture = picture;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the CategoryId field. </summary>
    public virtual System.Int32 CategoryId  { get; set; }

    /// <summary>Gets or sets the CategoryName field. </summary>
    public virtual System.String CategoryName  { get; set; }

    /// <summary>Gets or sets the Description field. </summary>
    public virtual System.String Description  { get; set; }

    /// <summary>Gets or sets the Picture field. </summary>
    public virtual System.Byte[] Picture  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Product.Category - Category.Products (m:1)'</summary>
    public virtual ProductCollection Products { get; set; }

    #endregion

  }
}
