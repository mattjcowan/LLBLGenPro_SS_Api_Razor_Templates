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
  public partial class EmployeeTerritoryCollection : CommonDtoBaseCollection<EmployeeTerritory>
  {
      public EmployeeTerritoryCollection(){}
      public EmployeeTerritoryCollection(IEnumerable<EmployeeTerritory> collection): base(collection ?? new List<EmployeeTerritory>()){}
      public EmployeeTerritoryCollection(List<EmployeeTerritory> list): base(list ?? new List<EmployeeTerritory>()){}
  }

  //[Serializable]
  public partial class EmployeeTerritory : CommonDtoBase<EmployeeTerritory>
  {
    public EmployeeTerritory()
    {
    }

    /// <summary>Factory method to create a new instance of the type 'EmployeeTerritory' (includes only required properties)</summary>
    /// <param name="employeeId">The initial value for the field 'EmployeeId'</param>  
    /// <param name="territoryId">The initial value for the field 'TerritoryId'</param>  
    public static EmployeeTerritory Create(System.Int32 employeeId, System.String territoryId)
    {
      var entity = new EmployeeTerritory();
      entity.EmployeeId = employeeId;
      entity.TerritoryId = territoryId;
      return entity;
    }


    #region Class Property Declarations
  
    /// <summary>Gets or sets the EmployeeId field. </summary>
    public virtual System.Int32 EmployeeId { get; set; }  

    /// <summary>Gets or sets the TerritoryId field. </summary>
    public virtual System.String TerritoryId { get; set; }  

    /// <summary>Represents the navigator which is mapped onto the association 'EmployeeTerritory.Employee - Employee.EmployeeTerritories (m:1)'</summary>
    [Browsable(false)]
    public virtual Employee Employee { get; set; } 

    /// <summary>Represents the navigator which is mapped onto the association 'EmployeeTerritory.Territory - Territory.EmployeeTerritories (m:1)'</summary>
    [Browsable(false)]
    public virtual Territory Territory { get; set; } 

    #endregion

  }
}
