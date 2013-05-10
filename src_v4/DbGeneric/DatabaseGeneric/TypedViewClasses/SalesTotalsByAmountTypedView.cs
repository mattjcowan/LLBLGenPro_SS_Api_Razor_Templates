///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Friday, May 10, 2013 1:17:03 AM
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
	
	/// <summary>Typed datatable for the view 'SalesTotalsByAmount'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class SalesTotalsByAmountTypedView : TypedViewBase<SalesTotalsByAmountRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnSaleAmount;
		private DataColumn _columnOrderId;
		private DataColumn _columnCompanyName;
		private DataColumn _columnShippedDate;
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
		static SalesTotalsByAmountTypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public SalesTotalsByAmountTypedView():base("SalesTotalsByAmount")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SalesTotalsByAmountTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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
			return new SalesTotalsByAmountRow(rowBuilder);
		}

		/// <summary>Initializes the hashtables for the typed view type and typed view field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("SaleAmount", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("OrderId", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("CompanyName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ShippedDate", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "SalesTotalsByAmount";		
			_columnSaleAmount = GeneralUtils.CreateTypedDataTableColumn("SaleAmount", @"SaleAmount", typeof(System.Decimal), this.Columns);
			_columnOrderId = GeneralUtils.CreateTypedDataTableColumn("OrderId", @"OrderId", typeof(System.Int32), this.Columns);
			_columnCompanyName = GeneralUtils.CreateTypedDataTableColumn("CompanyName", @"CompanyName", typeof(System.String), this.Columns);
			_columnShippedDate = GeneralUtils.CreateTypedDataTableColumn("ShippedDate", @"ShippedDate", typeof(System.DateTime), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.SalesTotalsByAmountTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnSaleAmount = this.Columns["SaleAmount"];
			_columnOrderId = this.Columns["OrderId"];
			_columnCompanyName = this.Columns["CompanyName"];
			_columnShippedDate = this.Columns["ShippedDate"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.SalesTotalsByAmountTypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			SalesTotalsByAmountTypedView cloneToReturn = ((SalesTotalsByAmountTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new SalesTotalsByAmountTypedView();
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
			get { return SalesTotalsByAmountTypedView.CustomProperties;}
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
			get { return SalesTotalsByAmountTypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field SaleAmount</summary>
		internal DataColumn SaleAmountColumn 
		{
			get { return _columnSaleAmount; }
		}

		/// <summary>Returns the column object belonging to the TypedView field OrderId</summary>
		internal DataColumn OrderIdColumn 
		{
			get { return _columnOrderId; }
		}

		/// <summary>Returns the column object belonging to the TypedView field CompanyName</summary>
		internal DataColumn CompanyNameColumn 
		{
			get { return _columnCompanyName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ShippedDate</summary>
		internal DataColumn ShippedDateColumn 
		{
			get { return _columnShippedDate; }
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
        get { return TypedViewType.SalesTotalsByAmountTypedView; }
    } 
		#endregion
	}

	/// <summary>Typed datarow for the typed datatable SalesTotalsByAmount</summary>
	public partial class SalesTotalsByAmountRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SalesTotalsByAmountTypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal SalesTotalsByAmountRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((SalesTotalsByAmountTypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field SaleAmount<br/><br/></summary>
		/// <remarks>Mapped on view field: "Sales Totals by Amount"."SaleAmount"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0</remarks>
		public System.Decimal SaleAmount 
		{
			get { return IsSaleAmountNull() ? (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)) : (System.Decimal)this[_parent.SaleAmountColumn]; }
			set { this[_parent.SaleAmountColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field SaleAmount is NULL, false otherwise.</summary>
		public bool IsSaleAmountNull() 
		{
			return IsNull(_parent.SaleAmountColumn);
		}

		/// <summary>Sets the TypedView field SaleAmount to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetSaleAmountNull() 
		{
			this[_parent.SaleAmountColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field OrderId<br/><br/></summary>
		/// <remarks>Mapped on view field: "Sales Totals by Amount"."OrderID"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field CompanyName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Sales Totals by Amount"."CompanyName"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field ShippedDate<br/><br/></summary>
		/// <remarks>Mapped on view field: "Sales Totals by Amount"."ShippedDate"<br/>
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
		#endregion
		
		#region Custom Typed View Row Code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomTypedViewRowCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Row Code

		#endregion	
	}
}
