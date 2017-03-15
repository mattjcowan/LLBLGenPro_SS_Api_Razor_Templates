///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using Northwind.Data;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;


namespace Northwind.Data.TypedViewClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Typed datatable for the view 'CustomerAndSuppliersByCity'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class CustomerAndSuppliersByCityTypedView : TypedViewBase<CustomerAndSuppliersByCityRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnCity;
		private DataColumn _columnCompanyName;
		private DataColumn _columnContactName;
		private DataColumn _columnRelationship;
		private IEntityFields2	_fields;
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static Hashtable	_customProperties;
		private static Hashtable	_fieldsCustomProperties;
		#endregion

		#region Class Constants
		/// <summary>
		/// The amount of fields in the resultset.
		/// </summary>
		private const int AmountOfFields = 4;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static CustomerAndSuppliersByCityTypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CustomerAndSuppliersByCityTypedView():base("CustomerAndSuppliersByCity")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CustomerAndSuppliersByCityTypedView(SerializationInfo info, StreamingContext context):base(info, context)
		{
			if (SerializationHelper.Optimization == SerializationOptimization.None)
			{
				InitMembers();
			}
		}
#endif
		/// <summary>Gets the IEntityFields2 collection of fields of this typed view. </summary>
		/// <returns>Ready to use IEntityFields2 collection object.</returns>
		public virtual IEntityFields2 GetFieldsInfo()
		{
			return _fields;
		}

		/// <summary>Creates a new typed row during the build of the datatable during a Fill session by a dataadapter.</summary>
		/// <param name="rowBuilder">supplied row builder to pass to the typed row</param>
		/// <returns>the new typed datarow</returns>
		protected override DataRow NewRowFromBuilder(DataRowBuilder rowBuilder) 
		{
			return new CustomerAndSuppliersByCityRow(rowBuilder);
		}

		/// <summary>Initializes the hashtables for the typed view type and typed view field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("CompanyName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ContactName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Relationship", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "CustomerAndSuppliersByCity";		
			_columnCity = GeneralUtils.CreateTypedDataTableColumn("City", @"City", typeof(System.String), this.Columns);
			_columnCompanyName = GeneralUtils.CreateTypedDataTableColumn("CompanyName", @"CompanyName", typeof(System.String), this.Columns);
			_columnContactName = GeneralUtils.CreateTypedDataTableColumn("ContactName", @"ContactName", typeof(System.String), this.Columns);
			_columnRelationship = GeneralUtils.CreateTypedDataTableColumn("Relationship", @"Relationship", typeof(System.String), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerAndSuppliersByCityTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnCity = this.Columns["City"];
			_columnCompanyName = this.Columns["CompanyName"];
			_columnContactName = this.Columns["ContactName"];
			_columnRelationship = this.Columns["Relationship"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CustomerAndSuppliersByCityTypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			CustomerAndSuppliersByCityTypedView cloneToReturn = ((CustomerAndSuppliersByCityTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new CustomerAndSuppliersByCityTypedView();
		}
#endif

		#region Class Property Declarations
		/// <summary>The custom properties for this TypedView type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary>The custom properties for the type of this TypedView instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable CustomPropertiesOfType
		{
			get { return CustomerAndSuppliersByCityTypedView.CustomProperties;}
		}

		/// <summary>The custom properties for the fields of this TypedView type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public static Hashtable FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary>The custom properties for the fields of the type of this TypedView instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[System.ComponentModel.Browsable(false)]
		public virtual Hashtable FieldsCustomPropertiesOfType
		{
			get { return CustomerAndSuppliersByCityTypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field City</summary>
		internal DataColumn CityColumn 
		{
			get { return _columnCity; }
		}

		/// <summary>Returns the column object belonging to the TypedView field CompanyName</summary>
		internal DataColumn CompanyNameColumn 
		{
			get { return _columnCompanyName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ContactName</summary>
		internal DataColumn ContactNameColumn 
		{
			get { return _columnContactName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Relationship</summary>
		internal DataColumn RelationshipColumn 
		{
			get { return _columnRelationship; }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalColumnProperties
		// __LLBLGENPRO_USER_CODE_REGION_END
 		#endregion

		#region Custom TypedView code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code
    /// <summary>Returns the TypedViewType enum value for this typed view.</summary>
    [Browsable(false), System.Xml.Serialization.XmlIgnore]
    public TypedViewType TypedViewType 
    {
        get { return TypedViewType.CustomerAndSuppliersByCityTypedView; }
    } 
		#endregion
	}

	/// <summary>Typed datarow for the typed datatable CustomerAndSuppliersByCity</summary>
	public partial class CustomerAndSuppliersByCityRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CustomerAndSuppliersByCityTypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal CustomerAndSuppliersByCityRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((CustomerAndSuppliersByCityTypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field City<br/><br/></summary>
		/// <remarks>Mapped on view field: "Customer and Suppliers by City"."City"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String City 
		{
			get { return IsCityNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.CityColumn]; }
			set { this[_parent.CityColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field City is NULL, false otherwise.</summary>
		public bool IsCityNull() 
		{
			return IsNull(_parent.CityColumn);
		}

		/// <summary>Sets the TypedView field City to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCityNull() 
		{
			this[_parent.CityColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field CompanyName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Customer and Suppliers by City"."CompanyName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 40</remarks>
		public System.String CompanyName 
		{
			get { return IsCompanyNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.CompanyNameColumn]; }
			set { this[_parent.CompanyNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field CompanyName is NULL, false otherwise.</summary>
		public bool IsCompanyNameNull() 
		{
			return IsNull(_parent.CompanyNameColumn);
		}

		/// <summary>Sets the TypedView field CompanyName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCompanyNameNull() 
		{
			this[_parent.CompanyNameColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ContactName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Customer and Suppliers by City"."ContactName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 30</remarks>
		public System.String ContactName 
		{
			get { return IsContactNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ContactNameColumn]; }
			set { this[_parent.ContactNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ContactName is NULL, false otherwise.</summary>
		public bool IsContactNameNull() 
		{
			return IsNull(_parent.ContactNameColumn);
		}

		/// <summary>Sets the TypedView field ContactName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetContactNameNull() 
		{
			this[_parent.ContactNameColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Relationship<br/><br/></summary>
		/// <remarks>Mapped on view field: "Customer and Suppliers by City"."Relationship"<br/>
		/// View field characteristics (type, precision, scale, length): VarChar, 0, 0, 9</remarks>
		public System.String Relationship 
		{
			get { return IsRelationshipNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.RelationshipColumn]; }
			set { this[_parent.RelationshipColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Relationship is NULL, false otherwise.</summary>
		public bool IsRelationshipNull() 
		{
			return IsNull(_parent.RelationshipColumn);
		}

		/// <summary>Sets the TypedView field Relationship to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetRelationshipNull() 
		{
			this[_parent.RelationshipColumn] = System.Convert.DBNull;
		}
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Row Code

		#endregion	
	}
}
