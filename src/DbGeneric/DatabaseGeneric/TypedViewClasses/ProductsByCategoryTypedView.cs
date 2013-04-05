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
	
	/// <summary>Typed datatable for the view 'ProductsByCategory'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class ProductsByCategoryTypedView : TypedViewBase<ProductsByCategoryRow>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnCategoryName;
		private DataColumn _columnProductName;
		private DataColumn _columnQuantityPerUnit;
		private DataColumn _columnUnitsInStock;
		private DataColumn _columnDiscontinued;
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
		private const int AmountOfFields = 5;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static ProductsByCategoryTypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ProductsByCategoryTypedView():base("ProductsByCategory")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ProductsByCategoryTypedView(SerializationInfo info, StreamingContext context):base(info, context)
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
			return new ProductsByCategoryRow(rowBuilder);
		}

		/// <summary>Initializes the hashtables for the typed view type and typed view field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Hashtable();
			_fieldsCustomProperties = new Hashtable();
			Hashtable fieldHashtable;
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("CategoryName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("ProductName", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("QuantityPerUnit", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("UnitsInStock", fieldHashtable);
			fieldHashtable = new Hashtable();
			_fieldsCustomProperties.Add("Discontinued", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "ProductsByCategory";		
			_columnCategoryName = GeneralUtils.CreateTypedDataTableColumn("CategoryName", @"CategoryName", typeof(System.String), this.Columns);
			_columnProductName = GeneralUtils.CreateTypedDataTableColumn("ProductName", @"ProductName", typeof(System.String), this.Columns);
			_columnQuantityPerUnit = GeneralUtils.CreateTypedDataTableColumn("QuantityPerUnit", @"QuantityPerUnit", typeof(System.String), this.Columns);
			_columnUnitsInStock = GeneralUtils.CreateTypedDataTableColumn("UnitsInStock", @"UnitsInStock", typeof(System.Int16), this.Columns);
			_columnDiscontinued = GeneralUtils.CreateTypedDataTableColumn("Discontinued", @"Discontinued", typeof(System.Boolean), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.ProductsByCategoryTypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnCategoryName = this.Columns["CategoryName"];
			_columnProductName = this.Columns["ProductName"];
			_columnQuantityPerUnit = this.Columns["QuantityPerUnit"];
			_columnUnitsInStock = this.Columns["UnitsInStock"];
			_columnDiscontinued = this.Columns["Discontinued"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.ProductsByCategoryTypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			ProductsByCategoryTypedView cloneToReturn = ((ProductsByCategoryTypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new ProductsByCategoryTypedView();
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
			get { return ProductsByCategoryTypedView.CustomProperties;}
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
			get { return ProductsByCategoryTypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field CategoryName</summary>
		internal DataColumn CategoryNameColumn 
		{
			get { return _columnCategoryName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field ProductName</summary>
		internal DataColumn ProductNameColumn 
		{
			get { return _columnProductName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field QuantityPerUnit</summary>
		internal DataColumn QuantityPerUnitColumn 
		{
			get { return _columnQuantityPerUnit; }
		}

		/// <summary>Returns the column object belonging to the TypedView field UnitsInStock</summary>
		internal DataColumn UnitsInStockColumn 
		{
			get { return _columnUnitsInStock; }
		}

		/// <summary>Returns the column object belonging to the TypedView field Discontinued</summary>
		internal DataColumn DiscontinuedColumn 
		{
			get { return _columnDiscontinued; }
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

	/// <summary>Typed datarow for the typed datatable ProductsByCategory</summary>
	public partial class ProductsByCategoryRow : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ProductsByCategoryTypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal ProductsByCategoryRow(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((ProductsByCategoryTypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field CategoryName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Products by Category"."CategoryName"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 15</remarks>
		public System.String CategoryName 
		{
			get { return IsCategoryNameNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.CategoryNameColumn]; }
			set { this[_parent.CategoryNameColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field CategoryName is NULL, false otherwise.</summary>
		public bool IsCategoryNameNull() 
		{
			return IsNull(_parent.CategoryNameColumn);
		}

		/// <summary>Sets the TypedView field CategoryName to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCategoryNameNull() 
		{
			this[_parent.CategoryNameColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field ProductName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Products by Category"."ProductName"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field QuantityPerUnit<br/><br/></summary>
		/// <remarks>Mapped on view field: "Products by Category"."QuantityPerUnit"<br/>
		/// View field characteristics (type, precision, scale, length): NVarChar, 0, 0, 20</remarks>
		public System.String QuantityPerUnit 
		{
			get { return IsQuantityPerUnitNull() ? (System.String)TypeDefaultValue.GetDefaultValue(typeof(System.String)) : (System.String)this[_parent.QuantityPerUnitColumn]; }
			set { this[_parent.QuantityPerUnitColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field QuantityPerUnit is NULL, false otherwise.</summary>
		public bool IsQuantityPerUnitNull() 
		{
			return IsNull(_parent.QuantityPerUnitColumn);
		}

		/// <summary>Sets the TypedView field QuantityPerUnit to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetQuantityPerUnitNull() 
		{
			this[_parent.QuantityPerUnitColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field UnitsInStock<br/><br/></summary>
		/// <remarks>Mapped on view field: "Products by Category"."UnitsInStock"<br/>
		/// View field characteristics (type, precision, scale, length): SmallInt, 5, 0, 0</remarks>
		public System.Int16 UnitsInStock 
		{
			get { return IsUnitsInStockNull() ? (System.Int16)TypeDefaultValue.GetDefaultValue(typeof(System.Int16)) : (System.Int16)this[_parent.UnitsInStockColumn]; }
			set { this[_parent.UnitsInStockColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field UnitsInStock is NULL, false otherwise.</summary>
		public bool IsUnitsInStockNull() 
		{
			return IsNull(_parent.UnitsInStockColumn);
		}

		/// <summary>Sets the TypedView field UnitsInStock to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetUnitsInStockNull() 
		{
			this[_parent.UnitsInStockColumn] = System.Convert.DBNull;
		}

		/// <summary>Gets / sets the value of the TypedView field Discontinued<br/><br/></summary>
		/// <remarks>Mapped on view field: "Products by Category"."Discontinued"<br/>
		/// View field characteristics (type, precision, scale, length): Bit, 0, 0, 0</remarks>
		public System.Boolean Discontinued 
		{
			get { return IsDiscontinuedNull() ? (System.Boolean)TypeDefaultValue.GetDefaultValue(typeof(System.Boolean)) : (System.Boolean)this[_parent.DiscontinuedColumn]; }
			set { this[_parent.DiscontinuedColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field Discontinued is NULL, false otherwise.</summary>
		public bool IsDiscontinuedNull() 
		{
			return IsNull(_parent.DiscontinuedColumn);
		}

		/// <summary>Sets the TypedView field Discontinued to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetDiscontinuedNull() 
		{
			this[_parent.DiscontinuedColumn] = System.Convert.DBNull;
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
