///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Saturday, March 09, 2013 5:47:55 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using Northwind.Data.EntityClasses;
using Northwind.Data.HelperClasses;
using Northwind.Data.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;


namespace Northwind.Data.TypedListClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Typed datatable for the list 'EmployeesByRegionAndTerritory'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class EmployeesByRegionAndTerritoryTypedList : TypedListBase2<EmployeesByRegionAndTerritoryRow>, ITypedListLgp2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesList
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnRegionId;
		private DataColumn _columnRegionDescription;
		private DataColumn _columnTerritoryId;
		private DataColumn _columnTerritoryDescription;
		private DataColumn _columnEmployeeId;
		private DataColumn _columnEmployeeFirstName;
		private DataColumn _columnEmployeeLastName;
		private DataColumn _columnEmployeeCity;
		private DataColumn _columnEmployeeCountry;
		private DataColumn _columnEmployeeRegion;
		private ResultsetFields _fields;
		private IRelationPredicateBucket _filterBucket;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		/// <summary>The amount of fields in the resultset.</summary>
		private const int AmountOfFields = 10;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static EmployeesByRegionAndTerritoryTypedList()
		{
			SetupCustomPropertyHashtables();
		}
		
		/// <summary>CTor</summary>
		public EmployeesByRegionAndTerritoryTypedList():base("EmployeesByRegionAndTerritory")
		{
			InitClass(false);
		}
				
		/// <summary>CTor</summary>
		/// <param name="obeyWeakRelations">The flag to signal the collection what kind of join statements to generate in the query statement. </param>
		public EmployeesByRegionAndTerritoryTypedList(bool obeyWeakRelations):base("EmployeesByRegionAndTerritory")
		{
			InitClass(obeyWeakRelations);
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EmployeesByRegionAndTerritoryTypedList(SerializationInfo info, StreamingContext context):base(info, context)
		{
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{
				InitMembers();
				BuildResultset();
			}
		}
#endif		
		/// <summary>Gets the IEntityFields2 collection of fields of this typed list. </summary>
		/// <returns>Ready to use IEntityFields2 collection object.</returns>
		public virtual IEntityFields2 GetFieldsInfo()
		{
			return _fields;
		}

		/// <summary>Gets the IRelationPredicateBucket object which contains the relation information for this Typed List. </summary>
		/// <returns>Ready to use IRelationPredicateBucket object.</returns>
		public virtual IRelationPredicateBucket GetRelationInfo()
		{
			_filterBucket = new RelationPredicateBucket();
			BuildRelationSet();
			return _filterBucket;
		}

		/// <summary>Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.</summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new EmployeesByRegionAndTerritoryRow(rowBuilder);
		}

		/// <summary>Initializes the hashtables for the typed list type and typed list field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("RegionId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("RegionDescription", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("TerritoryId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("TerritoryDescription", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeFirstName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeLastName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeCity", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeCountry", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeRegion", fieldHashtable);
		}


		/// <summary>Builds the relation set for this typed list, inside the filterBucket object.</summary>
		private void BuildRelationSet()
		{
			_filterBucket.Relations.ObeyWeakRelations = base.ObeyWeakRelations;
			_filterBucket.Relations.Add(EmployeeTerritoryEntity.Relations.EmployeeEntityUsingEmployeeId, "", "", JoinHint.Inner);
			_filterBucket.Relations.Add(TerritoryEntity.Relations.EmployeeTerritoryEntityUsingTerritoryId, "", "", JoinHint.Inner);
			_filterBucket.Relations.Add(RegionEntity.Relations.TerritoryEntityUsingRegionId, "", "", JoinHint.Inner);
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalRelations
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnRelationSetBuilt(_filterBucket.Relations);
		}

		/// <summary>Builds the resultset fields, stored in the private _fields object</summary>
		private void BuildResultset()
		{
			_fields = new ResultsetFields(AmountOfFields);
			_fields.DefineField(RegionFields.RegionId, 0, "RegionId", "", AggregateFunction.None);
			_fields.DefineField(RegionFields.RegionDescription, 1, "RegionDescription", "", AggregateFunction.None);
			_fields.DefineField(TerritoryFields.TerritoryId, 2, "TerritoryId", "", AggregateFunction.None);
			_fields.DefineField(TerritoryFields.TerritoryDescription, 3, "TerritoryDescription", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.EmployeeId, 4, "EmployeeId", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.FirstName, 5, "EmployeeFirstName", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.LastName, 6, "EmployeeLastName", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.City, 7, "EmployeeCity", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.Country, 8, "EmployeeCountry", "", AggregateFunction.None);
			_fields.DefineField(EmployeeFields.Region, 9, "EmployeeRegion", "", AggregateFunction.None);
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnResultsetBuilt(_fields);
		}

		/// <summary>Initialize the datastructures.</summary>
		/// <param name="obeyWeakRelations">flag for the internal used relations object</param>
		protected override void InitClass(bool obeyWeakRelations)
		{
			TableName = "EmployeesByRegionAndTerritory";		
			this.ObeyWeakRelations = obeyWeakRelations;
			_columnRegionId = GeneralUtils.CreateTypedDataTableColumn("RegionId", @"Region Id", typeof(System.Int32), this.Columns);
			_columnRegionDescription = GeneralUtils.CreateTypedDataTableColumn("RegionDescription", @"Region Description", typeof(System.String), this.Columns);
			_columnTerritoryId = GeneralUtils.CreateTypedDataTableColumn("TerritoryId", @"Territory Id", typeof(System.String), this.Columns);
			_columnTerritoryDescription = GeneralUtils.CreateTypedDataTableColumn("TerritoryDescription", @"Territory Description", typeof(System.String), this.Columns);
			_columnEmployeeId = GeneralUtils.CreateTypedDataTableColumn("EmployeeId", @"Employee Id", typeof(System.Int32), this.Columns);
			_columnEmployeeFirstName = GeneralUtils.CreateTypedDataTableColumn("EmployeeFirstName", @"Employee First Name", typeof(System.String), this.Columns);
			_columnEmployeeLastName = GeneralUtils.CreateTypedDataTableColumn("EmployeeLastName", @"Employee Last Name", typeof(System.String), this.Columns);
			_columnEmployeeCity = GeneralUtils.CreateTypedDataTableColumn("EmployeeCity", @"Employee City", typeof(System.String), this.Columns);
			_columnEmployeeCountry = GeneralUtils.CreateTypedDataTableColumn("EmployeeCountry", @"Employee Country", typeof(System.String), this.Columns);
			_columnEmployeeRegion = GeneralUtils.CreateTypedDataTableColumn("EmployeeRegion", @"Employee Region", typeof(System.String), this.Columns);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
			BuildResultset();
			_filterBucket = new RelationPredicateBucket();
			BuildRelationSet();
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnRegionId = this.Columns["RegionId"];
			_columnRegionDescription = this.Columns["RegionDescription"];
			_columnTerritoryId = this.Columns["TerritoryId"];
			_columnTerritoryDescription = this.Columns["TerritoryDescription"];
			_columnEmployeeId = this.Columns["EmployeeId"];
			_columnEmployeeFirstName = this.Columns["EmployeeFirstName"];
			_columnEmployeeLastName = this.Columns["EmployeeLastName"];
			_columnEmployeeCity = this.Columns["EmployeeCity"];
			_columnEmployeeCountry = this.Columns["EmployeeCountry"];
			_columnEmployeeRegion = this.Columns["EmployeeRegion"];
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			EmployeesByRegionAndTerritoryTypedList cloneToReturn = ((EmployeesByRegionAndTerritoryTypedList)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new EmployeesByRegionAndTerritoryTypedList();
		}
#endif

		#region Class Property Declarations
		/// <summary>The custom properties for this TypedList type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary>The custom properties for the type of this TypedList instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return EmployeesByRegionAndTerritoryTypedList.CustomProperties;}
		}

		/// <summary>The custom properties for the fields of this TypedList type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary>The custom properties for the fields of the type of this TypedList instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return EmployeesByRegionAndTerritoryTypedList.FieldsCustomProperties;}
		}


		/// <summary>Returns the column object belonging to the TypedList field RegionId</summary>
		internal DataColumn RegionIdColumn 
		{
			get { return _columnRegionId; }
		}

		/// <summary>Returns the column object belonging to the TypedList field RegionDescription</summary>
		internal DataColumn RegionDescriptionColumn 
		{
			get { return _columnRegionDescription; }
		}

		/// <summary>Returns the column object belonging to the TypedList field TerritoryId</summary>
		internal DataColumn TerritoryIdColumn 
		{
			get { return _columnTerritoryId; }
		}

		/// <summary>Returns the column object belonging to the TypedList field TerritoryDescription</summary>
		internal DataColumn TerritoryDescriptionColumn 
		{
			get { return _columnTerritoryDescription; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeId</summary>
		internal DataColumn EmployeeIdColumn 
		{
			get { return _columnEmployeeId; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeFirstName</summary>
		internal DataColumn EmployeeFirstNameColumn 
		{
			get { return _columnEmployeeFirstName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeLastName</summary>
		internal DataColumn EmployeeLastNameColumn 
		{
			get { return _columnEmployeeLastName; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeCity</summary>
		internal DataColumn EmployeeCityColumn 
		{
			get { return _columnEmployeeCity; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeCountry</summary>
		internal DataColumn EmployeeCountryColumn 
		{
			get { return _columnEmployeeCountry; }
		}

		/// <summary>Returns the column object belonging to the TypedList field EmployeeRegion</summary>
		internal DataColumn EmployeeRegionColumn 
		{
			get { return _columnEmployeeRegion; }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalColumnProperties
		// __LLBLGENPRO_USER_CODE_REGION_END
 		#endregion

		#region Custom TypedList code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedListCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}

	/// <summary>Typed datarow for the typed datatable EmployeesByRegionAndTerritory</summary>
	public partial class EmployeesByRegionAndTerritoryRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EmployeesByRegionAndTerritoryTypedList	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal EmployeesByRegionAndTerritoryRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((EmployeesByRegionAndTerritoryTypedList)(this.Table));
		}

		#region Class Property Declarations
		/// <summary>Gets / sets the value of the TypedList field RegionId<br/><br/></summary>
		/// <remarks>Mapped on: Region.RegionId</remarks>
		public System.Int32 RegionId 
		{
			get { return IsRegionIdNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.RegionIdColumn]; }
			set { this[_parent.RegionIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field RegionId is NULL, false otherwise.</summary>
		public bool IsRegionIdNull() 
		{
			return IsNull(_parent.RegionIdColumn);
		}

		/// <summary>Sets the TypedList field RegionId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetRegionIdNull() 
		{
			this[_parent.RegionIdColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field RegionDescription<br/><br/></summary>
		/// <remarks>Mapped on: Region.RegionDescription</remarks>
		public System.String RegionDescription 
		{
			get { return IsRegionDescriptionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.RegionDescriptionColumn]; }
			set { this[_parent.RegionDescriptionColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field RegionDescription is NULL, false otherwise.</summary>
		public bool IsRegionDescriptionNull() 
		{
			return IsNull(_parent.RegionDescriptionColumn);
		}

		/// <summary>Sets the TypedList field RegionDescription to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetRegionDescriptionNull() 
		{
			this[_parent.RegionDescriptionColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field TerritoryId<br/><br/></summary>
		/// <remarks>Mapped on: Territory.TerritoryId</remarks>
		public System.String TerritoryId 
		{
			get { return IsTerritoryIdNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.TerritoryIdColumn]; }
			set { this[_parent.TerritoryIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field TerritoryId is NULL, false otherwise.</summary>
		public bool IsTerritoryIdNull() 
		{
			return IsNull(_parent.TerritoryIdColumn);
		}

		/// <summary>Sets the TypedList field TerritoryId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetTerritoryIdNull() 
		{
			this[_parent.TerritoryIdColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field TerritoryDescription<br/><br/></summary>
		/// <remarks>Mapped on: Territory.TerritoryDescription</remarks>
		public System.String TerritoryDescription 
		{
			get { return IsTerritoryDescriptionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.TerritoryDescriptionColumn]; }
			set { this[_parent.TerritoryDescriptionColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field TerritoryDescription is NULL, false otherwise.</summary>
		public bool IsTerritoryDescriptionNull() 
		{
			return IsNull(_parent.TerritoryDescriptionColumn);
		}

		/// <summary>Sets the TypedList field TerritoryDescription to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetTerritoryDescriptionNull() 
		{
			this[_parent.TerritoryDescriptionColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeId<br/><br/></summary>
		/// <remarks>Mapped on: Employee.EmployeeId</remarks>
		public System.Int32 EmployeeId 
		{
			get { return IsEmployeeIdNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.EmployeeIdColumn]; }
			set { this[_parent.EmployeeIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeId is NULL, false otherwise.</summary>
		public bool IsEmployeeIdNull() 
		{
			return IsNull(_parent.EmployeeIdColumn);
		}

		/// <summary>Sets the TypedList field EmployeeId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeIdNull() 
		{
			this[_parent.EmployeeIdColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeFirstName<br/><br/></summary>
		/// <remarks>Mapped on: Employee.FirstName</remarks>
		public System.String EmployeeFirstName 
		{
			get { return IsEmployeeFirstNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmployeeFirstNameColumn]; }
			set { this[_parent.EmployeeFirstNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeFirstName is NULL, false otherwise.</summary>
		public bool IsEmployeeFirstNameNull() 
		{
			return IsNull(_parent.EmployeeFirstNameColumn);
		}

		/// <summary>Sets the TypedList field EmployeeFirstName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeFirstNameNull() 
		{
			this[_parent.EmployeeFirstNameColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeLastName<br/><br/></summary>
		/// <remarks>Mapped on: Employee.LastName</remarks>
		public System.String EmployeeLastName 
		{
			get { return IsEmployeeLastNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmployeeLastNameColumn]; }
			set { this[_parent.EmployeeLastNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeLastName is NULL, false otherwise.</summary>
		public bool IsEmployeeLastNameNull() 
		{
			return IsNull(_parent.EmployeeLastNameColumn);
		}

		/// <summary>Sets the TypedList field EmployeeLastName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeLastNameNull() 
		{
			this[_parent.EmployeeLastNameColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeCity<br/><br/></summary>
		/// <remarks>Mapped on: Employee.City</remarks>
		public System.String EmployeeCity 
		{
			get { return IsEmployeeCityNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmployeeCityColumn]; }
			set { this[_parent.EmployeeCityColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeCity is NULL, false otherwise.</summary>
		public bool IsEmployeeCityNull() 
		{
			return IsNull(_parent.EmployeeCityColumn);
		}

		/// <summary>Sets the TypedList field EmployeeCity to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeCityNull() 
		{
			this[_parent.EmployeeCityColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeCountry<br/><br/></summary>
		/// <remarks>Mapped on: Employee.Country</remarks>
		public System.String EmployeeCountry 
		{
			get { return IsEmployeeCountryNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmployeeCountryColumn]; }
			set { this[_parent.EmployeeCountryColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeCountry is NULL, false otherwise.</summary>
		public bool IsEmployeeCountryNull() 
		{
			return IsNull(_parent.EmployeeCountryColumn);
		}

		/// <summary>Sets the TypedList field EmployeeCountry to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeCountryNull() 
		{
			this[_parent.EmployeeCountryColumn] = System.Convert.DBNull;
		}
		/// <summary>Gets / sets the value of the TypedList field EmployeeRegion<br/><br/></summary>
		/// <remarks>Mapped on: Employee.Region</remarks>
		public System.String EmployeeRegion 
		{
			get { return IsEmployeeRegionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.EmployeeRegionColumn]; }
			set { this[_parent.EmployeeRegionColumn] = value; }
		}

		/// <summary>Returns true if the TypedList field EmployeeRegion is NULL, false otherwise.</summary>
		public bool IsEmployeeRegionNull() 
		{
			return IsNull(_parent.EmployeeRegionColumn);
		}

		/// <summary>Sets the TypedList field EmployeeRegion to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeRegionNull() 
		{
			this[_parent.EmployeeRegionColumn] = System.Convert.DBNull;
		}

		#endregion

		#region Custom Typed List Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedListRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Row Code

		#endregion	
	}
}
