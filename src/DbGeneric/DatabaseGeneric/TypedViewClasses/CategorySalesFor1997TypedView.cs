///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Monday, June 24, 2013 1:03:43 AM
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
	
	/// <summary>Typed datatable for the view 'CategorySalesFor1997'.<br/><br/></summary>
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class CategorySalesFor1997TypedView : TypedViewBase<CategorySalesFor1997Row>, ITypedView2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesView
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DataColumn _columnCategoryName;
		private DataColumn _columnCategorySales;
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
		private const int AmountOfFields = 2;
		#endregion

		/// <summary>Static CTor for setting up custom property hashtables.</summary>
		static CategorySalesFor1997TypedView()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CategorySalesFor1997TypedView():base("CategorySalesFor1997")
		{
			InitClass();
		}
#if !CF	
		/// <summary>Protected constructor for deserialization.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CategorySalesFor1997TypedView(SerializationInfo info, StreamingContext context):base(info, context)
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
			return new CategorySalesFor1997Row(rowBuilder);
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
			_fieldsCustomProperties.Add("CategorySales", fieldHashtable);
		}

		/// <summary>
		/// Initialize the datastructures.
		/// </summary>
		protected override void InitClass()
		{
			TableName = "CategorySalesFor1997";		
			_columnCategoryName = GeneralUtils.CreateTypedDataTableColumn("CategoryName", @"CategoryName", typeof(System.String), this.Columns);
			_columnCategorySales = GeneralUtils.CreateTypedDataTableColumn("CategorySales", @"CategorySales", typeof(System.Decimal), this.Columns);
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CategorySalesFor1997TypedView);
			
			// __LLBLGENPRO_USER_CODE_REGION_START AdditionalFields
			// be sure to call _fields.Expand(number of new fields) first. 
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitialized();
		}

		/// <summary>Initializes the members, after a clone action.</summary>
		private void InitMembers()
		{
			_columnCategoryName = this.Columns["CategoryName"];
			_columnCategorySales = this.Columns["CategorySales"];
			_fields = EntityFieldsFactory.CreateTypedViewEntityFieldsObject(TypedViewType.CategorySalesFor1997TypedView);
			// __LLBLGENPRO_USER_CODE_REGION_START InitMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Clones this instance.</summary>
		/// <returns>A clone of this instance</returns>
		public override DataTable Clone() 
		{
			CategorySalesFor1997TypedView cloneToReturn = ((CategorySalesFor1997TypedView)(base.Clone()));
			cloneToReturn.InitMembers();
			return cloneToReturn;
		}
#if !CF			
		/// <summary>Creates a new instance of the DataTable class.</summary>
		/// <returns>a new instance of a datatable with this schema.</returns>
		protected override DataTable CreateInstance() 
		{
			return new CategorySalesFor1997TypedView();
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
			get { return CategorySalesFor1997TypedView.CustomProperties;}
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
			get { return CategorySalesFor1997TypedView.FieldsCustomProperties;}
		}

		/// <summary>Returns the column object belonging to the TypedView field CategoryName</summary>
		internal DataColumn CategoryNameColumn 
		{
			get { return _columnCategoryName; }
		}

		/// <summary>Returns the column object belonging to the TypedView field CategorySales</summary>
		internal DataColumn CategorySalesColumn 
		{
			get { return _columnCategorySales; }
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
        get { return TypedViewType.CategorySalesFor1997TypedView; }
    } 
		#endregion
	}

	/// <summary>Typed datarow for the typed datatable CategorySalesFor1997</summary>
	public partial class CategorySalesFor1997Row : DataRow
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfacesRow
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CategorySalesFor1997TypedView	_parent;
		#endregion

		/// <summary>CTor</summary>
		/// <param name="rowBuilder">Row builder object to use when building this row</param>
		protected internal CategorySalesFor1997Row(DataRowBuilder rowBuilder) : base(rowBuilder) 
		{
			_parent = ((CategorySalesFor1997TypedView)(this.Table));
		}

		#region Class Property Declarations

		/// <summary>Gets / sets the value of the TypedView field CategoryName<br/><br/></summary>
		/// <remarks>Mapped on view field: "Category Sales for 1997"."CategoryName"<br/>
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

		/// <summary>Gets / sets the value of the TypedView field CategorySales<br/><br/></summary>
		/// <remarks>Mapped on view field: "Category Sales for 1997"."CategorySales"<br/>
		/// View field characteristics (type, precision, scale, length): Money, 19, 4, 0</remarks>
		public System.Decimal CategorySales 
		{
			get { return IsCategorySalesNull() ? (System.Decimal)TypeDefaultValue.GetDefaultValue(typeof(System.Decimal)) : (System.Decimal)this[_parent.CategorySalesColumn]; }
			set { this[_parent.CategorySalesColumn] = value; }
		}

		/// <summary>Returns true if the TypedView field CategorySales is NULL, false otherwise.</summary>
		public bool IsCategorySalesNull() 
		{
			return IsNull(_parent.CategorySalesColumn);
		}

		/// <summary>Sets the TypedView field CategorySales to NULL. Not recommended; a typed list should be used as a readonly object.</summary>
    	public void SetCategorySalesNull() 
		{
			this[_parent.CategorySalesColumn] = System.Convert.DBNull;
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
