///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Thursday, April 04, 2013 7:01:38 PM
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
	
	/// <summary>Typed datatable for the view 'OrderDetailsExtended'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class OrderDetailsExtendedTypedView : TypedViewBase<OrderDetailsExtendedRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnOrderId;
		private DataColumn _columnProductId;
		private DataColumn _columnProductName;
		private DataColumn _columnUnitPrice;
		private DataColumn _columnQuantity;
		private DataColumn _columnDiscount;
		private DataColumn _columnExtendedPrice;
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
		private const int AmountOfFields = 7;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static OrderDetailsExtendedTypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrderDetailsExtendedTypedView():base("OrderDetailsExtended")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrderDetailsExtendedTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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
			return new OrderDetailsExtendedRow(rowBuilder);
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
			_fieldsCustomProperties.Add("ProductId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ProductName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("UnitPrice", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Quantity", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Discount", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ExtendedPrice", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "OrderDetailsExtended";		
			_columnOrderId = GeneralUtils.CreateTypedDataTableColumn("OrderId", @"OrderId", typeof(System.Int32), this.Columns);
			_columnProductId = GeneralUtils.CreateTypedDataTableColumn("ProductId", @"ProductId", typeof(System.Int32), this.Columns);
			_columnProductName = GeneralUtils.CreateTypedDataTableColumn("ProductName", @"ProductName", typeof(System.String), this.Columns);
			_columnUnitPrice = GeneralUtils.CreateTypedDataTableColumn("UnitPrice", @"UnitPrice", typeof(System.Decimal), this.Columns);
			_columnQuantity = GeneralUtils.CreateTypedDataTableColumn("Quantity", @"Quantity", typeof(System.Int16), this.Columns);
			_columnDiscount = GeneralUtils.CreateTypedDataTableColumn("Discount", @"Discount", typeof(System.Single), this.Columns);
			_columnExtendedPrice = GeneralUtils.CreateTypedDataTableColumn("ExtendedPrice", @"ExtendedPrice", typeof(System.Decimal), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.OrderDetailsExtendedTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnOrderId = this.Columns["OrderId"];
			_columnProductId = this.Columns["ProductId"];
			_columnProductName = this.Columns["ProductName"];
			_columnUnitPrice = this.Columns["UnitPrice"];
			_columnQuantity = this.Columns["Quantity"];
			_columnDiscount = this.Columns["Discount"];
			_columnExtendedPrice = this.Columns["ExtendedPrice"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.OrderDetailsExtendedTypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			OrderDetailsExtendedTypedView cloneToReturn = ((OrderDetailsExtendedTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new OrderDetailsExtendedTypedView();
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
			get { return OrderDetailsExtendedTypedView.CustomProperties;}
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
			get { return OrderDetailsExtendedTypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field OrderId</summary>
		internal DataColumn OrderIdColumn 
		{
			get { return _columnOrderId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ProductId</summary>
		internal DataColumn ProductIdColumn 
		{
			get { return _columnProductId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ProductName</summary>
		internal DataColumn ProductNameColumn 
		{
			get { return _columnProductName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field UnitPrice</summary>
		internal DataColumn UnitPriceColumn 
		{
			get { return _columnUnitPrice; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Quantity</summary>
		internal DataColumn QuantityColumn 
		{
			get { return _columnQuantity; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Discount</summary>
		internal DataColumn DiscountColumn 
		{
			get { return _columnDiscount; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ExtendedPrice</summary>
		internal DataColumn ExtendedPriceColumn 
		{
			get { return _columnExtendedPrice; }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalColumnProperties
		// __LLBLGENPRO_USER_CODE_REGION_END
 		#endregion

		#region Custom TypedView code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included Code

		#endregion
	}

	/// <summary>Typed datarow for the typed datatable OrderDetailsExtended</summary>
	public partial class OrderDetailsExtendedRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private OrderDetailsExtendedTypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal OrderDetailsExtendedRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((OrderDetailsExtendedTypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field OrderId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."OrderID"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field ProductId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."ProductID"<br/>
		/// View field characteristics (type, precision, scale, length): Int, 10, 0, 0</remarks>
		public System.Int32 ProductId 
		{
			get { return IsProductIdNull() ? (System.Int32)TypeDefaultValue.GetDefaultValue(typeof(System.Int32)) : (System.Int32)this[_parent.ProductIdColumn]; }
			set { this[_parent.ProductIdColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ProductId is NULL, false otherwise.</summary>
		public bool IsProductIdNull() 
		{
			return IsNull(_parent.ProductIdColumn);
		}

		/// <summary>Sets the TypedView field ProductId to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetProductIdNull() 
		{
			this[_parent.ProductIdColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ProductName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."ProductName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 40</remarks>
		public System.String ProductName 
		{
			get { return IsProductNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.ProductNameColumn]; }
			set { this[_parent.ProductNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ProductName is NULL, false otherwise.</summary>
		public bool IsProductNameNull() 
		{
			return IsNull(_parent.ProductNameColumn);
		}

		/// <summary>Sets the TypedView field ProductName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetProductNameNull() 
		{
			this[_parent.ProductNameColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field UnitPrice<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."UnitPrice"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0</remarks>
		public System.Decimal UnitPrice 
		{
			get { return IsUnitPriceNull() ? (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)) : (System.Decimal)this[_parent.UnitPriceColumn]; }
			set { this[_parent.UnitPriceColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field UnitPrice is NULL, false otherwise.</summary>
		public bool IsUnitPriceNull() 
		{
			return IsNull(_parent.UnitPriceColumn);
		}

		/// <summary>Sets the TypedView field UnitPrice to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetUnitPriceNull() 
		{
			this[_parent.UnitPriceColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Quantity<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."Quantity"<br/>
		/// View field characteristics (type, precision, scale, length): SmallInt, 5, 0, 0</remarks>
		public System.Int16 Quantity 
		{
			get { return IsQuantityNull() ? (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16)) : (System.Int16)this[_parent.QuantityColumn]; }
			set { this[_parent.QuantityColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Quantity is NULL, false otherwise.</summary>
		public bool IsQuantityNull() 
		{
			return IsNull(_parent.QuantityColumn);
		}

		/// <summary>Sets the TypedView field Quantity to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetQuantityNull() 
		{
			this[_parent.QuantityColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Discount<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."Discount"<br/>
		/// View field characteristics (type, precision, scale, length): Real, 24, 0, 0</remarks>
		public System.Single Discount 
		{
			get { return IsDiscountNull() ? (System.Single)TypeDefaultValue.GetDefaultValue(typeof(System.Single)) : (System.Single)this[_parent.DiscountColumn]; }
			set { this[_parent.DiscountColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Discount is NULL, false otherwise.</summary>
		public bool IsDiscountNull() 
		{
			return IsNull(_parent.DiscountColumn);
		}

		/// <summary>Sets the TypedView field Discount to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetDiscountNull() 
		{
			this[_parent.DiscountColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ExtendedPrice<br/><br/></summary>
		/// <remarks>Mapped on view field: "Order Details Extended"."ExtendedPrice"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0</remarks>
		public System.Decimal ExtendedPrice 
		{
			get { return IsExtendedPriceNull() ? (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)) : (System.Decimal)this[_parent.ExtendedPriceColumn]; }
			set { this[_parent.ExtendedPriceColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field ExtendedPrice is NULL, false otherwise.</summary>
		public bool IsExtendedPriceNull() 
		{
			return IsNull(_parent.ExtendedPriceColumn);
		}

		/// <summary>Sets the TypedView field ExtendedPrice to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetExtendedPriceNull() 
		{
			this[_parent.ExtendedPriceColumn] = System.Convert.DBNull;
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
