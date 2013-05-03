///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Friday, May 03, 2013 10:20:01 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;

namespace Northwind.Data
{
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Category.</summary>
	public enum CategoryFieldIndex
	{
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>CategoryName. </summary>
		CategoryName,
		///<summary>Description. </summary>
		Description,
		///<summary>Picture. </summary>
		Picture,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Customer.</summary>
	public enum CustomerFieldIndex
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>ContactName. </summary>
		ContactName,
		///<summary>ContactTitle. </summary>
		ContactTitle,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>Phone. </summary>
		Phone,
		///<summary>Fax. </summary>
		Fax,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerCustomerDemo.</summary>
	public enum CustomerCustomerDemoFieldIndex
	{
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>CustomerTypeId. </summary>
		CustomerTypeId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: CustomerDemographic.</summary>
	public enum CustomerDemographicFieldIndex
	{
		///<summary>CustomerTypeId. </summary>
		CustomerTypeId,
		///<summary>CustomerDesc. </summary>
		CustomerDesc,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Employee.</summary>
	public enum EmployeeFieldIndex
	{
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>LastName. </summary>
		LastName,
		///<summary>FirstName. </summary>
		FirstName,
		///<summary>Title. </summary>
		Title,
		///<summary>TitleOfCourtesy. </summary>
		TitleOfCourtesy,
		///<summary>BirthDate. </summary>
		BirthDate,
		///<summary>HireDate. </summary>
		HireDate,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>HomePhone. </summary>
		HomePhone,
		///<summary>Extension. </summary>
		Extension,
		///<summary>Photo. </summary>
		Photo,
		///<summary>Notes. </summary>
		Notes,
		///<summary>ReportsToId. </summary>
		ReportsToId,
		///<summary>PhotoPath. </summary>
		PhotoPath,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: EmployeeTerritory.</summary>
	public enum EmployeeTerritoryFieldIndex
	{
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>TerritoryId. </summary>
		TerritoryId,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Order.</summary>
	public enum OrderFieldIndex
	{
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>CustomerId. </summary>
		CustomerId,
		///<summary>EmployeeId. </summary>
		EmployeeId,
		///<summary>OrderDate. </summary>
		OrderDate,
		///<summary>RequiredDate. </summary>
		RequiredDate,
		///<summary>ShippedDate. </summary>
		ShippedDate,
		///<summary>ShipVia. </summary>
		ShipVia,
		///<summary>Freight. </summary>
		Freight,
		///<summary>ShipName. </summary>
		ShipName,
		///<summary>ShipAddress. </summary>
		ShipAddress,
		///<summary>ShipCity. </summary>
		ShipCity,
		///<summary>ShipRegion. </summary>
		ShipRegion,
		///<summary>ShipPostalCode. </summary>
		ShipPostalCode,
		///<summary>ShipCountry. </summary>
		ShipCountry,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: OrderDetail.</summary>
	public enum OrderDetailFieldIndex
	{
		///<summary>OrderId. </summary>
		OrderId,
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>Quantity. </summary>
		Quantity,
		///<summary>Discount. </summary>
		Discount,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Product.</summary>
	public enum ProductFieldIndex
	{
		///<summary>ProductId. </summary>
		ProductId,
		///<summary>ProductName. </summary>
		ProductName,
		///<summary>SupplierId. </summary>
		SupplierId,
		///<summary>CategoryId. </summary>
		CategoryId,
		///<summary>QuantityPerUnit. </summary>
		QuantityPerUnit,
		///<summary>UnitPrice. </summary>
		UnitPrice,
		///<summary>UnitsInStock. </summary>
		UnitsInStock,
		///<summary>UnitsOnOrder. </summary>
		UnitsOnOrder,
		///<summary>ReorderLevel. </summary>
		ReorderLevel,
		///<summary>Discontinued. </summary>
		Discontinued,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Region.</summary>
	public enum RegionFieldIndex
	{
		///<summary>RegionId. </summary>
		RegionId,
		///<summary>RegionDescription. </summary>
		RegionDescription,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Shipper.</summary>
	public enum ShipperFieldIndex
	{
		///<summary>ShipperId. </summary>
		ShipperId,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>Phone. </summary>
		Phone,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Supplier.</summary>
	public enum SupplierFieldIndex
	{
		///<summary>SupplierId. </summary>
		SupplierId,
		///<summary>CompanyName. </summary>
		CompanyName,
		///<summary>ContactName. </summary>
		ContactName,
		///<summary>ContactTitle. </summary>
		ContactTitle,
		///<summary>Address. </summary>
		Address,
		///<summary>City. </summary>
		City,
		///<summary>Region. </summary>
		Region,
		///<summary>PostalCode. </summary>
		PostalCode,
		///<summary>Country. </summary>
		Country,
		///<summary>Phone. </summary>
		Phone,
		///<summary>Fax. </summary>
		Fax,
		///<summary>HomePage. </summary>
		HomePage,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access EntityFields in the IEntityFields collection for the entity: Territory.</summary>
	public enum TerritoryFieldIndex
	{
		///<summary>TerritoryId. </summary>
		TerritoryId,
		///<summary>TerritoryDescription. </summary>
		TerritoryDescription,
		///<summary>RegionId. </summary>
		RegionId,
		/// <summary></summary>
		AmountOfFields
	}

	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : AlphabeticalListOfProducts.</summary>
	public enum AlphabeticalListOfProductsFieldIndex
	{
		///<summary>ProductId</summary>
		ProductId,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>SupplierId</summary>
		SupplierId,
		///<summary>CategoryId</summary>
		CategoryId,
		///<summary>QuantityPerUnit</summary>
		QuantityPerUnit,
		///<summary>UnitPrice</summary>
		UnitPrice,
		///<summary>UnitsInStock</summary>
		UnitsInStock,
		///<summary>UnitsOnOrder</summary>
		UnitsOnOrder,
		///<summary>ReorderLevel</summary>
		ReorderLevel,
		///<summary>Discontinued</summary>
		Discontinued,
		///<summary>CategoryName</summary>
		CategoryName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CategorySalesFor1997.</summary>
	public enum CategorySalesFor1997FieldIndex
	{
		///<summary>CategoryName</summary>
		CategoryName,
		///<summary>CategorySales</summary>
		CategorySales,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CurrentProductList.</summary>
	public enum CurrentProductListFieldIndex
	{
		///<summary>ProductId</summary>
		ProductId,
		///<summary>ProductName</summary>
		ProductName,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : CustomerAndSuppliersByCity.</summary>
	public enum CustomerAndSuppliersByCityFieldIndex
	{
		///<summary>City</summary>
		City,
		///<summary>CompanyName</summary>
		CompanyName,
		///<summary>ContactName</summary>
		ContactName,
		///<summary>Relationship</summary>
		Relationship,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : Invoices.</summary>
	public enum InvoicesFieldIndex
	{
		///<summary>ShipName</summary>
		ShipName,
		///<summary>ShipAddress</summary>
		ShipAddress,
		///<summary>ShipCity</summary>
		ShipCity,
		///<summary>ShipRegion</summary>
		ShipRegion,
		///<summary>ShipPostalCode</summary>
		ShipPostalCode,
		///<summary>ShipCountry</summary>
		ShipCountry,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>CustomerName</summary>
		CustomerName,
		///<summary>Address</summary>
		Address,
		///<summary>City</summary>
		City,
		///<summary>Region</summary>
		Region,
		///<summary>PostalCode</summary>
		PostalCode,
		///<summary>Country</summary>
		Country,
		///<summary>Salesperson</summary>
		Salesperson,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>OrderDate</summary>
		OrderDate,
		///<summary>RequiredDate</summary>
		RequiredDate,
		///<summary>ShippedDate</summary>
		ShippedDate,
		///<summary>ShipperName</summary>
		ShipperName,
		///<summary>ProductId</summary>
		ProductId,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>UnitPrice</summary>
		UnitPrice,
		///<summary>Quantity</summary>
		Quantity,
		///<summary>Discount</summary>
		Discount,
		///<summary>ExtendedPrice</summary>
		ExtendedPrice,
		///<summary>Freight</summary>
		Freight,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : OrderDetailsExtended.</summary>
	public enum OrderDetailsExtendedFieldIndex
	{
		///<summary>OrderId</summary>
		OrderId,
		///<summary>ProductId</summary>
		ProductId,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>UnitPrice</summary>
		UnitPrice,
		///<summary>Quantity</summary>
		Quantity,
		///<summary>Discount</summary>
		Discount,
		///<summary>ExtendedPrice</summary>
		ExtendedPrice,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : OrdersQry.</summary>
	public enum OrdersQryFieldIndex
	{
		///<summary>OrderId</summary>
		OrderId,
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>EmployeeId</summary>
		EmployeeId,
		///<summary>OrderDate</summary>
		OrderDate,
		///<summary>RequiredDate</summary>
		RequiredDate,
		///<summary>ShippedDate</summary>
		ShippedDate,
		///<summary>ShipVia</summary>
		ShipVia,
		///<summary>Freight</summary>
		Freight,
		///<summary>ShipName</summary>
		ShipName,
		///<summary>ShipAddress</summary>
		ShipAddress,
		///<summary>ShipCity</summary>
		ShipCity,
		///<summary>ShipRegion</summary>
		ShipRegion,
		///<summary>ShipPostalCode</summary>
		ShipPostalCode,
		///<summary>ShipCountry</summary>
		ShipCountry,
		///<summary>CompanyName</summary>
		CompanyName,
		///<summary>Address</summary>
		Address,
		///<summary>City</summary>
		City,
		///<summary>Region</summary>
		Region,
		///<summary>PostalCode</summary>
		PostalCode,
		///<summary>Country</summary>
		Country,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : OrderSubtotal.</summary>
	public enum OrderSubtotalFieldIndex
	{
		///<summary>OrderId</summary>
		OrderId,
		///<summary>Subtotal</summary>
		Subtotal,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : ProductsAboveAveragePrice.</summary>
	public enum ProductsAboveAveragePriceFieldIndex
	{
		///<summary>ProductName</summary>
		ProductName,
		///<summary>UnitPrice</summary>
		UnitPrice,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : ProductSalesFor1997.</summary>
	public enum ProductSalesFor1997FieldIndex
	{
		///<summary>CategoryName</summary>
		CategoryName,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>ProductSales</summary>
		ProductSales,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : ProductsByCategory.</summary>
	public enum ProductsByCategoryFieldIndex
	{
		///<summary>CategoryName</summary>
		CategoryName,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>QuantityPerUnit</summary>
		QuantityPerUnit,
		///<summary>UnitsInStock</summary>
		UnitsInStock,
		///<summary>Discontinued</summary>
		Discontinued,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : QuarterlyOrder.</summary>
	public enum QuarterlyOrderFieldIndex
	{
		///<summary>CustomerId</summary>
		CustomerId,
		///<summary>CompanyName</summary>
		CompanyName,
		///<summary>City</summary>
		City,
		///<summary>Country</summary>
		Country,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : SalesByCategory.</summary>
	public enum SalesByCategoryFieldIndex
	{
		///<summary>CategoryId</summary>
		CategoryId,
		///<summary>CategoryName</summary>
		CategoryName,
		///<summary>ProductName</summary>
		ProductName,
		///<summary>ProductSales</summary>
		ProductSales,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : SalesTotalsByAmount.</summary>
	public enum SalesTotalsByAmountFieldIndex
	{
		///<summary>SaleAmount</summary>
		SaleAmount,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>CompanyName</summary>
		CompanyName,
		///<summary>ShippedDate</summary>
		ShippedDate,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : SummaryOfSalesByQuarter.</summary>
	public enum SummaryOfSalesByQuarterFieldIndex
	{
		///<summary>ShippedDate</summary>
		ShippedDate,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>Subtotal</summary>
		Subtotal,
		/// <summary></summary>
		AmountOfFields
	}
	/// <summary>Index enum to fast-access Typed View EntityFields in the IEntityFields collection for the typed view : SummaryOfSalesByYear.</summary>
	public enum SummaryOfSalesByYearFieldIndex
	{
		///<summary>ShippedDate</summary>
		ShippedDate,
		///<summary>OrderId</summary>
		OrderId,
		///<summary>Subtotal</summary>
		Subtotal,
		/// <summary></summary>
		AmountOfFields
	}

	/// <summary>Index enum to fast-access TypedList Fields in the Columns collection of the Typed List: EmployeesByRegionAndTerritory</summary>
	public enum EmployeesByRegionAndTerritoryTypedListFieldIndex
	{
		///<summary>RegionId</summary>
		RegionId,
		///<summary>RegionDescription</summary>
		RegionDescription,
		///<summary>TerritoryId</summary>
		TerritoryId,
		///<summary>TerritoryDescription</summary>
		TerritoryDescription,
		///<summary>EmployeeId</summary>
		EmployeeId,
		///<summary>EmployeeFirstName</summary>
		EmployeeFirstName,
		///<summary>EmployeeLastName</summary>
		EmployeeLastName,
		///<summary>EmployeeCity</summary>
		EmployeeCity,
		///<summary>EmployeeCountry</summary>
		EmployeeCountry,
		///<summary>EmployeeRegion</summary>
		EmployeeRegion,
		/// <summary></summary>
		AmountOfFields
	}

	/// <summary>Enum definition for all the entity types defined in this namespace. Used by the entityfields factory.</summary>
	public enum EntityType
	{
		///<summary>Category</summary>
		CategoryEntity,
		///<summary>Customer</summary>
		CustomerEntity,
		///<summary>CustomerCustomerDemo</summary>
		CustomerCustomerDemoEntity,
		///<summary>CustomerDemographic</summary>
		CustomerDemographicEntity,
		///<summary>Employee</summary>
		EmployeeEntity,
		///<summary>EmployeeTerritory</summary>
		EmployeeTerritoryEntity,
		///<summary>Order</summary>
		OrderEntity,
		///<summary>OrderDetail</summary>
		OrderDetailEntity,
		///<summary>Product</summary>
		ProductEntity,
		///<summary>Region</summary>
		RegionEntity,
		///<summary>Shipper</summary>
		ShipperEntity,
		///<summary>Supplier</summary>
		SupplierEntity,
		///<summary>Territory</summary>
		TerritoryEntity
	}

	/// <summary>Enum definition for all the typed view types defined in this namespace. Used by the entityfields factory.</summary>
	public enum TypedViewType
	{
		///<summary>AlphabeticalListOfProducts</summary>
		AlphabeticalListOfProductsTypedView,
		///<summary>CategorySalesFor1997</summary>
		CategorySalesFor1997TypedView,
		///<summary>CurrentProductList</summary>
		CurrentProductListTypedView,
		///<summary>CustomerAndSuppliersByCity</summary>
		CustomerAndSuppliersByCityTypedView,
		///<summary>Invoices</summary>
		InvoicesTypedView,
		///<summary>OrderDetailsExtended</summary>
		OrderDetailsExtendedTypedView,
		///<summary>OrdersQry</summary>
		OrdersQryTypedView,
		///<summary>OrderSubtotal</summary>
		OrderSubtotalTypedView,
		///<summary>ProductsAboveAveragePrice</summary>
		ProductsAboveAveragePriceTypedView,
		///<summary>ProductSalesFor1997</summary>
		ProductSalesFor1997TypedView,
		///<summary>ProductsByCategory</summary>
		ProductsByCategoryTypedView,
		///<summary>QuarterlyOrder</summary>
		QuarterlyOrderTypedView,
		///<summary>SalesByCategory</summary>
		SalesByCategoryTypedView,
		///<summary>SalesTotalsByAmount</summary>
		SalesTotalsByAmountTypedView,
		///<summary>SummaryOfSalesByQuarter</summary>
		SummaryOfSalesByQuarterTypedView,
		///<summary>SummaryOfSalesByYear</summary>
		SummaryOfSalesByYearTypedView
	}

	#region Custom ConstantsEnums Code
	
	// __LLBLGENPRO_USER_CODE_REGION_START CustomUserConstants
	// __LLBLGENPRO_USER_CODE_REGION_END
	#endregion

	#region Included code

	#endregion
}

