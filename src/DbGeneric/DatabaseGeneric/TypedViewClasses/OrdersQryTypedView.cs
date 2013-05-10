///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Friday, May 10, 2013 1:09:46 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
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
	
	/// <summary>Typed datatable for the view 'OrdersQry'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class OrdersQryTypedView : TypedViewBase<OrdersQryRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnOrderId;
		private DataColumn _columnCustomerId;
		private DataColumn _columnEmployeeId;
		private DataColumn _columnOrderDate;
		private DataColumn _columnRequiredDate;
		private DataColumn _columnShippedDate;
		private DataColumn _columnShipVia;
		private DataColumn _columnFreight;
		private DataColumn _columnShipName;
		private DataColumn _columnShipAddress;
		private DataColumn _columnShipCity;
		private DataColumn _columnShipRegion;
		private DataColumn _columnShipPostalCode;
		private DataColumn _columnShipCountry;
		private DataColumn _columnCompanyName;
		private DataColumn _columnAddress;
		private DataColumn _columnCity;
		private DataColumn _columnRegion;
		private DataColumn _columnPostalCode;
		private DataColumn _columnCountry;
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
		private const int AmountOfFields = 20;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static OrdersQryTypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrdersQryTypedView():base("OrdersQry")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrdersQryTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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
			return new OrdersQryRow(rowBuilder);
		}

		/// <summary>Initializes the hashtables for the typed view type and typed view field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("EmployeeId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("OrderDate", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("RequiredDate", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShippedDate", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipVia", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Freight", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipAddress", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipCity", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipRegion", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipPostalCode", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShipCountry", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("CompanyName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Address", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Region", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("PostalCode", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Country", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "OrdersQry";		
			_columnOrderId = GeneralUtils.CreateTypedDataTableColumn("OrderId", @"OrderId", typeof(System.Int32), this.Columns);
			_columnCustomerId = GeneralUtils.CreateTypedDataTableColumn("CustomerId", @"CustomerId", typeof(System.String), this.Columns);
			_columnEmployeeId = GeneralUtils.CreateTypedDataTableColumn("EmployeeId", @"EmployeeId", typeof(System.Int32), this.Columns);
			_columnOrderDate = GeneralUtils.CreateTypedDataTableColumn("OrderDate", @"OrderDate", typeof(System.DateTime), this.Columns);
			_columnRequiredDate = GeneralUtils.CreateTypedDataTableColumn("RequiredDate", @"RequiredDate", typeof(System.DateTime), this.Columns);
			_columnShippedDate = GeneralUtils.CreateTypedDataTableColumn("ShippedDate", @"ShippedDate", typeof(System.DateTime), this.Columns);
			_columnShipVia = GeneralUtils.CreateTypedDataTableColumn("ShipVia", @"ShipVia", typeof(System.Int32), this.Columns);
			_columnFreight = GeneralUtils.CreateTypedDataTableColumn("Freight", @"Freight", typeof(System.Decimal), this.Columns);
			_columnShipName = GeneralUtils.CreateTypedDataTableColumn("ShipName", @"ShipName", typeof(System.String), this.Columns);
			_columnShipAddress = GeneralUtils.CreateTypedDataTableColumn("ShipAddress", @"ShipAddress", typeof(System.String), this.Columns);
			_columnShipCity = GeneralUtils.CreateTypedDataTableColumn("ShipCity", @"ShipCity", typeof(System.String), this.Columns);
			_columnShipRegion = GeneralUtils.CreateTypedDataTableColumn("ShipRegion", @"ShipRegion", typeof(System.String), this.Columns);
			_columnShipPostalCode = GeneralUtils.CreateTypedDataTableColumn("ShipPostalCode", @"ShipPostalCode", typeof(System.String), this.Columns);
			_columnShipCountry = GeneralUtils.CreateTypedDataTableColumn("ShipCountry", @"ShipCountry", typeof(System.String), this.Columns);
			_columnCompanyName = GeneralUtils.CreateTypedDataTableColumn("CompanyName", @"CompanyName", typeof(System.String), this.Columns);
			_columnAddress = GeneralUtils.CreateTypedDataTableColumn("Address", @"Address", typeof(System.String), this.Columns);
			_columnCity = GeneralUtils.CreateTypedDataTableColumn("City", @"City", typeof(System.String), this.Columns);
			_columnRegion = GeneralUtils.CreateTypedDataTableColumn("Region", @"Region", typeof(System.String), this.Columns);
			_columnPostalCode = GeneralUtils.CreateTypedDataTableColumn("PostalCode", @"PostalCode", typeof(System.String), this.Columns);
			_columnCountry = GeneralUtils.CreateTypedDataTableColumn("Country", @"Country", typeof(System.String), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.OrdersQryTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnOrderId = this.Columns["OrderId"];
			_columnCustomerId = this.Columns["CustomerId"];
			_columnEmployeeId = this.Columns["EmployeeId"];
			_columnOrderDate = this.Columns["OrderDate"];
			_columnRequiredDate = this.Columns["RequiredDate"];
			_columnShippedDate = this.Columns["ShippedDate"];
			_columnShipVia = this.Columns["ShipVia"];
			_columnFreight = this.Columns["Freight"];
			_columnShipName = this.Columns["ShipName"];
			_columnShipAddress = this.Columns["ShipAddress"];
			_columnShipCity = this.Columns["ShipCity"];
			_columnShipRegion = this.Columns["ShipRegion"];
			_columnShipPostalCode = this.Columns["ShipPostalCode"];
			_columnShipCountry = this.Columns["ShipCountry"];
			_columnCompanyName = this.Columns["CompanyName"];
			_columnAddress = this.Columns["Address"];
			_columnCity = this.Columns["City"];
			_columnRegion = this.Columns["Region"];
			_columnPostalCode = this.Columns["PostalCode"];
			_columnCountry = this.Columns["Country"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.OrdersQryTypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			OrdersQryTypedView cloneToReturn = ((OrdersQryTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new OrdersQryTypedView();
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
			get { return OrdersQryTypedView.CustomProperties;}
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
			get { return OrdersQryTypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field OrderId</summary>
		internal DataColumn OrderIdColumn 
		{
			get { return _columnOrderId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field CustomerId</summary>
		internal DataColumn CustomerIdColumn 
		{
			get { return _columnCustomerId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field EmployeeId</summary>
		internal DataColumn EmployeeIdColumn 
		{
			get { return _columnEmployeeId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field OrderDate</summary>
		internal DataColumn OrderDateColumn 
		{
			get { return _columnOrderDate; }
		}

		/// <summary>Returns the column object belonging to the TypedView field RequiredDate</summary>
		internal DataColumn RequiredDateColumn 
		{
			get { return _columnRequiredDate; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShippedDate</summary>
		internal DataColumn ShippedDateColumn 
		{
			get { return _columnShippedDate; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipVia</summary>
		internal DataColumn ShipViaColumn 
		{
			get { return _columnShipVia; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Freight</summary>
		internal DataColumn FreightColumn 
		{
			get { return _columnFreight; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipName</summary>
		internal DataColumn ShipNameColumn 
		{
			get { return _columnShipName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipAddress</summary>
		internal DataColumn ShipAddressColumn 
		{
			get { return _columnShipAddress; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipCity</summary>
		internal DataColumn ShipCityColumn 
		{
			get { return _columnShipCity; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipRegion</summary>
		internal DataColumn ShipRegionColumn 
		{
			get { return _columnShipRegion; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipPostalCode</summary>
		internal DataColumn ShipPostalCodeColumn 
		{
			get { return _columnShipPostalCode; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShipCountry</summary>
		internal DataColumn ShipCountryColumn 
		{
			get { return _columnShipCountry; }
		}

		/// <summary>Returns the column object belonging to the TypedView field CompanyName</summary>
		internal DataColumn CompanyNameColumn 
		{
			get { return _columnCompanyName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Address</summary>
		internal DataColumn AddressColumn 
		{
			get { return _columnAddress; }
		}

		/// <summary>Returns the column object belonging to the TypedView field City</summary>
		internal DataColumn CityColumn 
		{
			get { return _columnCity; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Region</summary>
		internal DataColumn RegionColumn 
		{
			get { return _columnRegion; }
		}

		/// <summary>Returns the column object belonging to the TypedView field PostalCode</summary>
		internal DataColumn PostalCodeColumn 
		{
			get { return _columnPostalCode; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Country</summary>
		internal DataColumn CountryColumn 
		{
			get { return _columnCountry; }
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
        get { return TypedViewType.OrdersQryTypedView; }
    } 
		#endregion
	}

	/// <summary>Typed datarow for the typed datatable OrdersQry</summary>
	public partial class OrdersQryRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private OrdersQryTypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal OrdersQryRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((OrdersQryTypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field OrderId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."OrderID"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0</remarks>
		public System.Int32 OrderId 
		{
			get { return IsOrderIdNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.OrderIdColumn]; }
			set { this[_parent.OrderIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field OrderId is NULL, false otherwise.</summary>
		public bool IsOrderIdNull() 
		{
			return IsNull(_parent.OrderIdColumn);
		}

		/// <summary>Sets the TypedView field OrderId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetOrderIdNull() 
		{
			this[_parent.OrderIdColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field CustomerId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."CustomerID"<br/>
		/// View field characteristics (type, precision, scale, length): NChar, 0, 0, 5</remarks>
		public System.String CustomerId 
		{
			get { return IsCustomerIdNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.CustomerIdColumn]; }
			set { this[_parent.CustomerIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field CustomerId is NULL, false otherwise.</summary>
		public bool IsCustomerIdNull() 
		{
			return IsNull(_parent.CustomerIdColumn);
		}

		/// <summary>Sets the TypedView field CustomerId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCustomerIdNull() 
		{
			this[_parent.CustomerIdColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field EmployeeId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."EmployeeID"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0</remarks>
		public System.Int32 EmployeeId 
		{
			get { return IsEmployeeIdNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.EmployeeIdColumn]; }
			set { this[_parent.EmployeeIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field EmployeeId is NULL, false otherwise.</summary>
		public bool IsEmployeeIdNull() 
		{
			return IsNull(_parent.EmployeeIdColumn);
		}

		/// <summary>Sets the TypedView field EmployeeId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetEmployeeIdNull() 
		{
			this[_parent.EmployeeIdColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field OrderDate<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."OrderDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0</remarks>
		public System.DateTime OrderDate 
		{
			get { return IsOrderDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.OrderDateColumn]; }
			set { this[_parent.OrderDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field OrderDate is NULL, false otherwise.</summary>
		public bool IsOrderDateNull() 
		{
			return IsNull(_parent.OrderDateColumn);
		}

		/// <summary>Sets the TypedView field OrderDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetOrderDateNull() 
		{
			this[_parent.OrderDateColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field RequiredDate<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."RequiredDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0</remarks>
		public System.DateTime RequiredDate 
		{
			get { return IsRequiredDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.RequiredDateColumn]; }
			set { this[_parent.RequiredDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field RequiredDate is NULL, false otherwise.</summary>
		public bool IsRequiredDateNull() 
		{
			return IsNull(_parent.RequiredDateColumn);
		}

		/// <summary>Sets the TypedView field RequiredDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetRequiredDateNull() 
		{
			this[_parent.RequiredDateColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShippedDate<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShippedDate"<br/>
		/// View field characteristics (type, precision, scale, length): DateTime, 0, 0, 0</remarks>
		public System.DateTime ShippedDate 
		{
			get { return IsShippedDateNull() ? (System.DateTime)TypeDefaultValue.GetDefaultValue(typeof(System.DateTime)) : (System.DateTime)this[_parent.ShippedDateColumn]; }
			set { this[_parent.ShippedDateColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShippedDate is NULL, false otherwise.</summary>
		public bool IsShippedDateNull() 
		{
			return IsNull(_parent.ShippedDateColumn);
		}

		/// <summary>Sets the TypedView field ShippedDate to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShippedDateNull() 
		{
			this[_parent.ShippedDateColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipVia<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipVia"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0</remarks>
		public System.Int32 ShipVia 
		{
			get { return IsShipViaNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.ShipViaColumn]; }
			set { this[_parent.ShipViaColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipVia is NULL, false otherwise.</summary>
		public bool IsShipViaNull() 
		{
			return IsNull(_parent.ShipViaColumn);
		}

		/// <summary>Sets the TypedView field ShipVia to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipViaNull() 
		{
			this[_parent.ShipViaColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Freight<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."Freight"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0</remarks>
		public System.Decimal Freight 
		{
			get { return IsFreightNull() ? (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)) : (System.Decimal)this[_parent.FreightColumn]; }
			set { this[_parent.FreightColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Freight is NULL, false otherwise.</summary>
		public bool IsFreightNull() 
		{
			return IsNull(_parent.FreightColumn);
		}

		/// <summary>Sets the TypedView field Freight to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetFreightNull() 
		{
			this[_parent.FreightColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 40</remarks>
		public System.String ShipName 
		{
			get { return IsShipNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipNameColumn]; }
			set { this[_parent.ShipNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipName is NULL, false otherwise.</summary>
		public bool IsShipNameNull() 
		{
			return IsNull(_parent.ShipNameColumn);
		}

		/// <summary>Sets the TypedView field ShipName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipNameNull() 
		{
			this[_parent.ShipNameColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipAddress<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipAddress"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 60</remarks>
		public System.String ShipAddress 
		{
			get { return IsShipAddressNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipAddressColumn]; }
			set { this[_parent.ShipAddressColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipAddress is NULL, false otherwise.</summary>
		public bool IsShipAddressNull() 
		{
			return IsNull(_parent.ShipAddressColumn);
		}

		/// <summary>Sets the TypedView field ShipAddress to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipAddressNull() 
		{
			this[_parent.ShipAddressColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipCity<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipCity"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String ShipCity 
		{
			get { return IsShipCityNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipCityColumn]; }
			set { this[_parent.ShipCityColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipCity is NULL, false otherwise.</summary>
		public bool IsShipCityNull() 
		{
			return IsNull(_parent.ShipCityColumn);
		}

		/// <summary>Sets the TypedView field ShipCity to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipCityNull() 
		{
			this[_parent.ShipCityColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipRegion<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipRegion"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String ShipRegion 
		{
			get { return IsShipRegionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipRegionColumn]; }
			set { this[_parent.ShipRegionColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipRegion is NULL, false otherwise.</summary>
		public bool IsShipRegionNull() 
		{
			return IsNull(_parent.ShipRegionColumn);
		}

		/// <summary>Sets the TypedView field ShipRegion to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipRegionNull() 
		{
			this[_parent.ShipRegionColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipPostalCode<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipPostalCode"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 10</remarks>
		public System.String ShipPostalCode 
		{
			get { return IsShipPostalCodeNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipPostalCodeColumn]; }
			set { this[_parent.ShipPostalCodeColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipPostalCode is NULL, false otherwise.</summary>
		public bool IsShipPostalCodeNull() 
		{
			return IsNull(_parent.ShipPostalCodeColumn);
		}

		/// <summary>Sets the TypedView field ShipPostalCode to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipPostalCodeNull() 
		{
			this[_parent.ShipPostalCodeColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ShipCountry<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."ShipCountry"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String ShipCountry 
		{
			get { return IsShipCountryNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ShipCountryColumn]; }
			set { this[_parent.ShipCountryColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ShipCountry is NULL, false otherwise.</summary>
		public bool IsShipCountryNull() 
		{
			return IsNull(_parent.ShipCountryColumn);
		}

		/// <summary>Sets the TypedView field ShipCountry to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetShipCountryNull() 
		{
			this[_parent.ShipCountryColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field CompanyName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."CompanyName"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field Address<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."Address"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 60</remarks>
		public System.String Address 
		{
			get { return IsAddressNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.AddressColumn]; }
			set { this[_parent.AddressColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Address is NULL, false otherwise.</summary>
		public bool IsAddressNull() 
		{
			return IsNull(_parent.AddressColumn);
		}

		/// <summary>Sets the TypedView field Address to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetAddressNull() 
		{
			this[_parent.AddressColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field City<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."City"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field Region<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."Region"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String Region 
		{
			get { return IsRegionNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.RegionColumn]; }
			set { this[_parent.RegionColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Region is NULL, false otherwise.</summary>
		public bool IsRegionNull() 
		{
			return IsNull(_parent.RegionColumn);
		}

		/// <summary>Sets the TypedView field Region to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetRegionNull() 
		{
			this[_parent.RegionColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field PostalCode<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."PostalCode"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 10</remarks>
		public System.String PostalCode 
		{
			get { return IsPostalCodeNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.PostalCodeColumn]; }
			set { this[_parent.PostalCodeColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field PostalCode is NULL, false otherwise.</summary>
		public bool IsPostalCodeNull() 
		{
			return IsNull(_parent.PostalCodeColumn);
		}

		/// <summary>Sets the TypedView field PostalCode to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetPostalCodeNull() 
		{
			this[_parent.PostalCodeColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Country<br/><br/></summary>
		/// <remarks>Mapped on view field: "Orders Qry"."Country"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String Country 
		{
			get { return IsCountryNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.CountryColumn]; }
			set { this[_parent.CountryColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Country is NULL, false otherwise.</summary>
		public bool IsCountryNull() 
		{
			return IsNull(_parent.CountryColumn);
		}

		/// <summary>Sets the TypedView field Country to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCountryNull() 
		{
			this[_parent.CountryColumn] = System.Convert.DBNull;
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
