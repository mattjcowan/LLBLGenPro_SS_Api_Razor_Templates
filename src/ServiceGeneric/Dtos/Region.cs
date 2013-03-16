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
  public partial class RegionCollection : CommonDtoBaseCollection<Region>
  {
      public RegionCollection(){}
      public RegionCollection(IEnumerable<Region> collection): base(collection ?? new List<Region>()){}
      public RegionCollection(List<Region> list): base(list ?? new List<Region>()){}
  }

  //[Serializable]
  public partial class Region : CommonDtoBase<Region>
  {
    public Region()
    {
      this.Territories = new TerritoryCollection();
    }

    /// <summary>Factory method to create a new instance of the type 'Region' (includes only required properties)</summary>
    /// <param name="regionId">The initial value for the field 'RegionId'</param>  
    /// <param name="regionDescription">The initial value for the field 'RegionDescription'</param>  
    public static Region Create(System.Int32 regionId, System.String regionDescription)
    {
      var entity = new Region();
      entity.RegionId = regionId;
      entity.RegionDescription = regionDescription;
      return entity;
    }


    #region Class Property Declarations
  
    /// <summary>Gets or sets the RegionId field. </summary>
    public virtual System.Int32 RegionId  { get; set; }

    /// <summary>Gets or sets the RegionDescription field. </summary>
    public virtual System.String RegionDescription  { get; set; }

    /// <summary>Represents the navigator which is mapped onto the association 'Territory.Region - Region.Territories (m:1)'</summary>
    public virtual TerritoryCollection Territories { get; set; }

    #endregion

  }
}
