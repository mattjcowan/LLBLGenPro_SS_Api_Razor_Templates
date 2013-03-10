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
  public partial class TerritoryCollection : CommonDtoBaseCollection<Territory>
  {
      public TerritoryCollection(){}
      public TerritoryCollection(IEnumerable<Territory> collection): base(collection ?? new List<Territory>()){}
      public TerritoryCollection(List<Territory> list): base(list ?? new List<Territory>()){}
  }

  [Serializable]
  public partial class Territory : CommonDtoBase<Territory>
  {
    public Territory()
    {
      this.EmployeeTerritories = new EmployeeTerritoryCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Territory' (includes only required properties)</summary>
    /// <param name="territoryId">The initial value for the field 'TerritoryId'</param>  
    /// <param name="territoryDescription">The initial value for the field 'TerritoryDescription'</param>  
    /// <param name="regionId">The initial value for the field 'RegionId'</param>  
    public static Territory Create(System.String territoryId, System.String territoryDescription, System.Int32 regionId)
    {
      var entity = new Territory();
      entity.TerritoryId = territoryId;
      entity.TerritoryDescription = territoryDescription;
      entity.RegionId = regionId;
      return entity;
    }


    #region Class Property Declarations
	
    /// <summary>Gets or sets the TerritoryId field. </summary>
    public virtual System.String TerritoryId  { get; set; }

    /// <summary>Gets or sets the TerritoryDescription field. </summary>
    public virtual System.String TerritoryDescription  { get; set; }

    /// <summary>Gets or sets the RegionId field. </summary>
    public virtual System.Int32 RegionId { get; set; }  

    /// <summary>Represents the navigator which is mapped onto the association 'EmployeeTerritory.Territory - Territory.EmployeeTerritories (m:1)'</summary>
    public virtual EmployeeTerritoryCollection EmployeeTerritories { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Territory.Region - Region.Territories (m:1)'</summary>
    [Browsable(false)]
    public virtual Region Region { get; set; } 

    #endregion

  }
}
