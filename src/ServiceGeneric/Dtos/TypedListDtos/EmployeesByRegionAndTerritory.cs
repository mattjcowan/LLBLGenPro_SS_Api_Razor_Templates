using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;

namespace Northwind.Data.Dtos.TypedListDtos
{ 
    public partial class EmployeesByRegionAndTerritoryCollection : CommonTypedListDtoBaseCollection<EmployeesByRegionAndTerritory>
    {
        public EmployeesByRegionAndTerritoryCollection(){}
        public EmployeesByRegionAndTerritoryCollection(IEnumerable<EmployeesByRegionAndTerritory> collection): base(collection ?? new List<EmployeesByRegionAndTerritory>()){}
        public EmployeesByRegionAndTerritoryCollection(List<EmployeesByRegionAndTerritory> list): base(list ?? new List<EmployeesByRegionAndTerritory>()){}
    }

    public partial class EmployeesByRegionAndTerritory: CommonTypedListDtoBase<EmployeesByRegionAndTerritory>
    {
      /// <summary>Gets or sets the RegionId field. </summary>
        public virtual System.Int32 RegionId { get; set; }
      /// <summary>Gets or sets the RegionDescription field. </summary>
        public virtual System.String RegionDescription { get; set; }
      /// <summary>Gets or sets the TerritoryId field. </summary>
        public virtual System.String TerritoryId { get; set; }
      /// <summary>Gets or sets the TerritoryDescription field. </summary>
        public virtual System.String TerritoryDescription { get; set; }
      /// <summary>Gets or sets the EmployeeId field. </summary>
        public virtual System.Int32 EmployeeId { get; set; }
      /// <summary>Gets or sets the EmployeeFirstName field. </summary>
        public virtual System.String EmployeeFirstName { get; set; }
      /// <summary>Gets or sets the EmployeeLastName field. </summary>
        public virtual System.String EmployeeLastName { get; set; }
      /// <summary>Gets or sets the EmployeeCity field. </summary>
        public virtual System.String EmployeeCity { get; set; }
      /// <summary>Gets or sets the EmployeeCountry field. </summary>
        public virtual System.String EmployeeCountry { get; set; }
      /// <summary>Gets or sets the EmployeeRegion field. </summary>
        public virtual System.String EmployeeRegion { get; set; }

    }
}
