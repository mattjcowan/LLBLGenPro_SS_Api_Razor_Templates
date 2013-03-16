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
  public partial class EmployeeCollection : CommonDtoBaseCollection<Employee>
  {
      public EmployeeCollection(){}
      public EmployeeCollection(IEnumerable<Employee> collection): base(collection ?? new List<Employee>()){}
      public EmployeeCollection(List<Employee> list): base(list ?? new List<Employee>()){}
  }

  //[Serializable]
  public partial class Employee : CommonDtoBase<Employee>
  {
    public Employee()
    {
      this.Employees = new EmployeeCollection();
      this.EmployeeTerritories = new EmployeeTerritoryCollection();
      this.Orders = new OrderCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Employee' (includes only required properties)</summary>
    /// <param name="employeeId">The initial value for the field 'EmployeeId'</param>  
    /// <param name="lastName">The initial value for the field 'LastName'</param>  
    /// <param name="firstName">The initial value for the field 'FirstName'</param>  
    public static Employee Create(System.Int32 employeeId, System.String lastName, System.String firstName)
    {
      var entity = new Employee();
      entity.EmployeeId = employeeId;
      entity.LastName = lastName;
      entity.FirstName = firstName;
      return entity;
    }

    /// <summary>Factory method to create a new instance of the type 'Employee' (includes optional properties)</summary>
    /// <param name="employeeId">The initial value for the field 'EmployeeId'</param>  
    /// <param name="lastName">The initial value for the field 'LastName'</param>  
    /// <param name="firstName">The initial value for the field 'FirstName'</param>  
    /// <param name="title">The initial value for the field 'Title'</param>  
    /// <param name="titleOfCourtesy">The initial value for the field 'TitleOfCourtesy'</param>  
    /// <param name="birthDate">The initial value for the field 'BirthDate'</param>  
    /// <param name="hireDate">The initial value for the field 'HireDate'</param>  
    /// <param name="address">The initial value for the field 'Address'</param>  
    /// <param name="city">The initial value for the field 'City'</param>  
    /// <param name="region">The initial value for the field 'Region'</param>  
    /// <param name="postalCode">The initial value for the field 'PostalCode'</param>  
    /// <param name="country">The initial value for the field 'Country'</param>  
    /// <param name="homePhone">The initial value for the field 'HomePhone'</param>  
    /// <param name="extension">The initial value for the field 'Extension'</param>  
    /// <param name="photo">The initial value for the field 'Photo'</param>  
    /// <param name="notes">The initial value for the field 'Notes'</param>  
    /// <param name="reportsToId">The initial value for the field 'ReportsToId'</param>  
    /// <param name="photoPath">The initial value for the field 'PhotoPath'</param>  
    public static Employee Create(System.Int32 employeeId, System.String lastName, System.String firstName, System.String title, System.String titleOfCourtesy, Nullable<System.DateTime> birthDate, Nullable<System.DateTime> hireDate, System.String address, System.String city, System.String region, System.String postalCode, System.String country, System.String homePhone, System.String extension, System.Byte[] photo, System.String notes, Nullable<System.Int32> reportsToId, System.String photoPath)
    {
      var entity = new Employee();
      entity.EmployeeId = employeeId;
      entity.LastName = lastName;
      entity.FirstName = firstName;
      entity.Title = title;
      entity.TitleOfCourtesy = titleOfCourtesy;
      entity.BirthDate = birthDate;
      entity.HireDate = hireDate;
      entity.Address = address;
      entity.City = city;
      entity.Region = region;
      entity.PostalCode = postalCode;
      entity.Country = country;
      entity.HomePhone = homePhone;
      entity.Extension = extension;
      entity.Photo = photo;
      entity.Notes = notes;
      entity.ReportsToId = reportsToId;
      entity.PhotoPath = photoPath;
      return entity;
    }

    #region Class Property Declarations
  
    /// <summary>Gets or sets the EmployeeId field. </summary>
    public virtual System.Int32 EmployeeId  { get; set; }

    /// <summary>Gets or sets the LastName field. </summary>
    public virtual System.String LastName  { get; set; }

    /// <summary>Gets or sets the FirstName field. </summary>
    public virtual System.String FirstName  { get; set; }

    /// <summary>Gets or sets the Title field. </summary>
    public virtual System.String Title  { get; set; }

    /// <summary>Gets or sets the TitleOfCourtesy field. </summary>
    public virtual System.String TitleOfCourtesy  { get; set; }

    /// <summary>Gets or sets the BirthDate field. </summary>
    public virtual Nullable<System.DateTime> BirthDate  { get; set; }

    /// <summary>Gets or sets the HireDate field. </summary>
    public virtual Nullable<System.DateTime> HireDate  { get; set; }

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

    /// <summary>Gets or sets the HomePhone field. </summary>
    public virtual System.String HomePhone  { get; set; }

    /// <summary>Gets or sets the Extension field. </summary>
    public virtual System.String Extension  { get; set; }

    /// <summary>Gets or sets the Photo field. </summary>
    public virtual System.Byte[] Photo  { get; set; }

    /// <summary>Gets or sets the Notes field. </summary>
    public virtual System.String Notes  { get; set; }

    /// <summary>Gets or sets the ReportsToId field. </summary>
    public virtual Nullable<System.Int32> ReportsToId { get; set; }  

    /// <summary>Gets or sets the PhotoPath field. </summary>
    public virtual System.String PhotoPath  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Employee.ReportsTo - Employee.Employees (m:1)'</summary>
    [Browsable(false)]
    public virtual Employee ReportsTo { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'Employee.ReportsTo - Employee.Employees (m:1)'</summary>
    public virtual EmployeeCollection Employees { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'EmployeeTerritory.Employee - Employee.EmployeeTerritories (m:1)'</summary>
    public virtual EmployeeTerritoryCollection EmployeeTerritories { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Order.Employee - Employee.Orders (m:1)'</summary>
    public virtual OrderCollection Orders { get; set; }

    #endregion

  }
}
