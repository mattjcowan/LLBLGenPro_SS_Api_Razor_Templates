///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Saturday, March 16, 2013 2:58:27 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (13 + 16));
			InitCategoryEntityInfos();
			InitCustomerEntityInfos();
			InitCustomerCustomerDemoEntityInfos();
			InitCustomerDemographicEntityInfos();
			InitEmployeeEntityInfos();
			InitEmployeeTerritoryEntityInfos();
			InitOrderEntityInfos();
			InitOrderDetailEntityInfos();
			InitProductEntityInfos();
			InitRegionEntityInfos();
			InitShipperEntityInfos();
			InitSupplierEntityInfos();
			InitTerritoryEntityInfos();
			InitAlphabeticalListOfProductsTypedViewInfos();
			InitCategorySalesFor1997TypedViewInfos();
			InitCurrentProductListTypedViewInfos();
			InitCustomerAndSuppliersByCityTypedViewInfos();
			InitInvoicesTypedViewInfos();
			InitOrderDetailsExtendedTypedViewInfos();
			InitOrdersQryTypedViewInfos();
			InitOrderSubtotalTypedViewInfos();
			InitProductsAboveAveragePriceTypedViewInfos();
			InitProductSalesFor1997TypedViewInfos();
			InitProductsByCategoryTypedViewInfos();
			InitQuarterlyOrderTypedViewInfos();
			InitSalesByCategoryTypedViewInfos();
			InitSalesTotalsByAmountTypedViewInfos();
			InitSummaryOfSalesByQuarterTypedViewInfos();
			InitSummaryOfSalesByYearTypedViewInfos();
			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits CategoryEntity's FieldInfo objects</summary>
		private void InitCategoryEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CategoryFieldIndex), "CategoryEntity");
			this.AddElementFieldInfo("CategoryEntity", "CategoryId", typeof(System.Int32), true, false, true, false,  (int)CategoryFieldIndex.CategoryId, 0, 0, 10);
			this.AddElementFieldInfo("CategoryEntity", "CategoryName", typeof(System.String), false, false, false, false,  (int)CategoryFieldIndex.CategoryName, 15, 0, 0);
			this.AddElementFieldInfo("CategoryEntity", "Description", typeof(System.String), false, false, false, true,  (int)CategoryFieldIndex.Description, 1073741823, 0, 0);
			this.AddElementFieldInfo("CategoryEntity", "Picture", typeof(System.Byte[]), false, false, false, true,  (int)CategoryFieldIndex.Picture, 2147483647, 0, 0);
		}
		/// <summary>Inits CustomerEntity's FieldInfo objects</summary>
		private void InitCustomerEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CustomerFieldIndex), "CustomerEntity");
			this.AddElementFieldInfo("CustomerEntity", "CustomerId", typeof(System.String), true, false, false, false,  (int)CustomerFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)CustomerFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "ContactName", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.ContactName, 30, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "ContactTitle", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.ContactTitle, 30, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Address", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Address, 60, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "City", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Region", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Region, 15, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Country", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Country, 15, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Phone", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Phone, 24, 0, 0);
			this.AddElementFieldInfo("CustomerEntity", "Fax", typeof(System.String), false, false, false, true,  (int)CustomerFieldIndex.Fax, 24, 0, 0);
		}
		/// <summary>Inits CustomerCustomerDemoEntity's FieldInfo objects</summary>
		private void InitCustomerCustomerDemoEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CustomerCustomerDemoFieldIndex), "CustomerCustomerDemoEntity");
			this.AddElementFieldInfo("CustomerCustomerDemoEntity", "CustomerId", typeof(System.String), true, true, false, false,  (int)CustomerCustomerDemoFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("CustomerCustomerDemoEntity", "CustomerTypeId", typeof(System.String), true, true, false, false,  (int)CustomerCustomerDemoFieldIndex.CustomerTypeId, 10, 0, 0);
		}
		/// <summary>Inits CustomerDemographicEntity's FieldInfo objects</summary>
		private void InitCustomerDemographicEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CustomerDemographicFieldIndex), "CustomerDemographicEntity");
			this.AddElementFieldInfo("CustomerDemographicEntity", "CustomerTypeId", typeof(System.String), true, false, false, false,  (int)CustomerDemographicFieldIndex.CustomerTypeId, 10, 0, 0);
			this.AddElementFieldInfo("CustomerDemographicEntity", "CustomerDesc", typeof(System.String), false, false, false, true,  (int)CustomerDemographicFieldIndex.CustomerDesc, 1073741823, 0, 0);
		}
		/// <summary>Inits EmployeeEntity's FieldInfo objects</summary>
		private void InitEmployeeEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EmployeeFieldIndex), "EmployeeEntity");
			this.AddElementFieldInfo("EmployeeEntity", "EmployeeId", typeof(System.Int32), true, false, true, false,  (int)EmployeeFieldIndex.EmployeeId, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeEntity", "LastName", typeof(System.String), false, false, false, false,  (int)EmployeeFieldIndex.LastName, 20, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)EmployeeFieldIndex.FirstName, 10, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Title", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Title, 30, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "TitleOfCourtesy", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.TitleOfCourtesy, 25, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "BirthDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)EmployeeFieldIndex.BirthDate, 0, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "HireDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)EmployeeFieldIndex.HireDate, 0, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Address", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Address, 60, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "City", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Region", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Region, 15, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Country", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Country, 15, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "HomePhone", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.HomePhone, 24, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Extension", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Extension, 4, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Photo", typeof(System.Byte[]), false, false, false, true,  (int)EmployeeFieldIndex.Photo, 2147483647, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "Notes", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.Notes, 1073741823, 0, 0);
			this.AddElementFieldInfo("EmployeeEntity", "ReportsToId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)EmployeeFieldIndex.ReportsToId, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeEntity", "PhotoPath", typeof(System.String), false, false, false, true,  (int)EmployeeFieldIndex.PhotoPath, 255, 0, 0);
		}
		/// <summary>Inits EmployeeTerritoryEntity's FieldInfo objects</summary>
		private void InitEmployeeTerritoryEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EmployeeTerritoryFieldIndex), "EmployeeTerritoryEntity");
			this.AddElementFieldInfo("EmployeeTerritoryEntity", "EmployeeId", typeof(System.Int32), true, true, false, false,  (int)EmployeeTerritoryFieldIndex.EmployeeId, 0, 0, 10);
			this.AddElementFieldInfo("EmployeeTerritoryEntity", "TerritoryId", typeof(System.String), true, true, false, false,  (int)EmployeeTerritoryFieldIndex.TerritoryId, 20, 0, 0);
		}
		/// <summary>Inits OrderEntity's FieldInfo objects</summary>
		private void InitOrderEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrderFieldIndex), "OrderEntity");
			this.AddElementFieldInfo("OrderEntity", "OrderId", typeof(System.Int32), true, false, true, false,  (int)OrderFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("OrderEntity", "CustomerId", typeof(System.String), false, true, false, true,  (int)OrderFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "EmployeeId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)OrderFieldIndex.EmployeeId, 0, 0, 10);
			this.AddElementFieldInfo("OrderEntity", "OrderDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrderFieldIndex.OrderDate, 0, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "RequiredDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrderFieldIndex.RequiredDate, 0, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShippedDate", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)OrderFieldIndex.ShippedDate, 0, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipVia", typeof(Nullable<System.Int32>), false, true, false, true,  (int)OrderFieldIndex.ShipVia, 0, 0, 10);
			this.AddElementFieldInfo("OrderEntity", "Freight", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)OrderFieldIndex.Freight, 0, 4, 19);
			this.AddElementFieldInfo("OrderEntity", "ShipName", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipName, 40, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipAddress", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipAddress, 60, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipCity", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipCity, 15, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipRegion", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipRegion, 15, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipPostalCode", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipPostalCode, 10, 0, 0);
			this.AddElementFieldInfo("OrderEntity", "ShipCountry", typeof(System.String), false, false, false, true,  (int)OrderFieldIndex.ShipCountry, 15, 0, 0);
		}
		/// <summary>Inits OrderDetailEntity's FieldInfo objects</summary>
		private void InitOrderDetailEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrderDetailFieldIndex), "OrderDetailEntity");
			this.AddElementFieldInfo("OrderDetailEntity", "OrderId", typeof(System.Int32), true, true, false, false,  (int)OrderDetailFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("OrderDetailEntity", "ProductId", typeof(System.Int32), true, true, false, false,  (int)OrderDetailFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("OrderDetailEntity", "UnitPrice", typeof(System.Decimal), false, false, false, false,  (int)OrderDetailFieldIndex.UnitPrice, 0, 4, 19);
			this.AddElementFieldInfo("OrderDetailEntity", "Quantity", typeof(System.Int16), false, false, false, false,  (int)OrderDetailFieldIndex.Quantity, 0, 0, 5);
			this.AddElementFieldInfo("OrderDetailEntity", "Discount", typeof(System.Single), false, false, false, false,  (int)OrderDetailFieldIndex.Discount, 0, 0, 24);
		}
		/// <summary>Inits ProductEntity's FieldInfo objects</summary>
		private void InitProductEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ProductFieldIndex), "ProductEntity");
			this.AddElementFieldInfo("ProductEntity", "ProductId", typeof(System.Int32), true, false, true, false,  (int)ProductFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("ProductEntity", "ProductName", typeof(System.String), false, false, false, false,  (int)ProductFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("ProductEntity", "SupplierId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ProductFieldIndex.SupplierId, 0, 0, 10);
			this.AddElementFieldInfo("ProductEntity", "CategoryId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)ProductFieldIndex.CategoryId, 0, 0, 10);
			this.AddElementFieldInfo("ProductEntity", "QuantityPerUnit", typeof(System.String), false, false, false, true,  (int)ProductFieldIndex.QuantityPerUnit, 20, 0, 0);
			this.AddElementFieldInfo("ProductEntity", "UnitPrice", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)ProductFieldIndex.UnitPrice, 0, 4, 19);
			this.AddElementFieldInfo("ProductEntity", "UnitsInStock", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductFieldIndex.UnitsInStock, 0, 0, 5);
			this.AddElementFieldInfo("ProductEntity", "UnitsOnOrder", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductFieldIndex.UnitsOnOrder, 0, 0, 5);
			this.AddElementFieldInfo("ProductEntity", "ReorderLevel", typeof(Nullable<System.Int16>), false, false, false, true,  (int)ProductFieldIndex.ReorderLevel, 0, 0, 5);
			this.AddElementFieldInfo("ProductEntity", "Discontinued", typeof(System.Boolean), false, false, false, false,  (int)ProductFieldIndex.Discontinued, 0, 0, 0);
		}
		/// <summary>Inits RegionEntity's FieldInfo objects</summary>
		private void InitRegionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RegionFieldIndex), "RegionEntity");
			this.AddElementFieldInfo("RegionEntity", "RegionId", typeof(System.Int32), true, false, false, false,  (int)RegionFieldIndex.RegionId, 0, 0, 10);
			this.AddElementFieldInfo("RegionEntity", "RegionDescription", typeof(System.String), false, false, false, false,  (int)RegionFieldIndex.RegionDescription, 50, 0, 0);
		}
		/// <summary>Inits ShipperEntity's FieldInfo objects</summary>
		private void InitShipperEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ShipperFieldIndex), "ShipperEntity");
			this.AddElementFieldInfo("ShipperEntity", "ShipperId", typeof(System.Int32), true, false, true, false,  (int)ShipperFieldIndex.ShipperId, 0, 0, 10);
			this.AddElementFieldInfo("ShipperEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)ShipperFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("ShipperEntity", "Phone", typeof(System.String), false, false, false, true,  (int)ShipperFieldIndex.Phone, 24, 0, 0);
		}
		/// <summary>Inits SupplierEntity's FieldInfo objects</summary>
		private void InitSupplierEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SupplierFieldIndex), "SupplierEntity");
			this.AddElementFieldInfo("SupplierEntity", "SupplierId", typeof(System.Int32), true, false, true, false,  (int)SupplierFieldIndex.SupplierId, 0, 0, 10);
			this.AddElementFieldInfo("SupplierEntity", "CompanyName", typeof(System.String), false, false, false, false,  (int)SupplierFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "ContactName", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.ContactName, 30, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "ContactTitle", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.ContactTitle, 30, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "Address", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.Address, 60, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "City", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "Region", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.Region, 15, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "PostalCode", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "Country", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.Country, 15, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "Phone", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.Phone, 24, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "Fax", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.Fax, 24, 0, 0);
			this.AddElementFieldInfo("SupplierEntity", "HomePage", typeof(System.String), false, false, false, true,  (int)SupplierFieldIndex.HomePage, 1073741823, 0, 0);
		}
		/// <summary>Inits TerritoryEntity's FieldInfo objects</summary>
		private void InitTerritoryEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TerritoryFieldIndex), "TerritoryEntity");
			this.AddElementFieldInfo("TerritoryEntity", "TerritoryId", typeof(System.String), true, false, false, false,  (int)TerritoryFieldIndex.TerritoryId, 20, 0, 0);
			this.AddElementFieldInfo("TerritoryEntity", "TerritoryDescription", typeof(System.String), false, false, false, false,  (int)TerritoryFieldIndex.TerritoryDescription, 50, 0, 0);
			this.AddElementFieldInfo("TerritoryEntity", "RegionId", typeof(System.Int32), false, true, false, false,  (int)TerritoryFieldIndex.RegionId, 0, 0, 10);
		}

		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitAlphabeticalListOfProductsTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AlphabeticalListOfProductsFieldIndex), "AlphabeticalListOfProductsTypedView");
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "ProductId", typeof(System.Int32), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "SupplierId", typeof(System.Int32), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.SupplierId, 0, 0, 10);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "CategoryId", typeof(System.Int32), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.CategoryId, 0, 0, 10);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "QuantityPerUnit", typeof(System.String), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.QuantityPerUnit, 20, 0, 0);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "UnitPrice", typeof(System.Decimal), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.UnitPrice, 0, 4, 19);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "UnitsInStock", typeof(System.Int16), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.UnitsInStock, 0, 0, 5);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "UnitsOnOrder", typeof(System.Int16), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.UnitsOnOrder, 0, 0, 5);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "ReorderLevel", typeof(System.Int16), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.ReorderLevel, 0, 0, 5);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "Discontinued", typeof(System.Boolean), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.Discontinued, 0, 0, 0);
			this.AddElementFieldInfo("AlphabeticalListOfProductsTypedView", "CategoryName", typeof(System.String), false, false, true, false, (int)AlphabeticalListOfProductsFieldIndex.CategoryName, 15, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitCategorySalesFor1997TypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CategorySalesFor1997FieldIndex), "CategorySalesFor1997TypedView");
			this.AddElementFieldInfo("CategorySalesFor1997TypedView", "CategoryName", typeof(System.String), false, false, true, false, (int)CategorySalesFor1997FieldIndex.CategoryName, 15, 0, 0);
			this.AddElementFieldInfo("CategorySalesFor1997TypedView", "CategorySales", typeof(System.Decimal), false, false, true, false, (int)CategorySalesFor1997FieldIndex.CategorySales, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitCurrentProductListTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CurrentProductListFieldIndex), "CurrentProductListTypedView");
			this.AddElementFieldInfo("CurrentProductListTypedView", "ProductId", typeof(System.Int32), false, false, true, false, (int)CurrentProductListFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("CurrentProductListTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)CurrentProductListFieldIndex.ProductName, 40, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitCustomerAndSuppliersByCityTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CustomerAndSuppliersByCityFieldIndex), "CustomerAndSuppliersByCityTypedView");
			this.AddElementFieldInfo("CustomerAndSuppliersByCityTypedView", "City", typeof(System.String), false, false, true, false, (int)CustomerAndSuppliersByCityFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("CustomerAndSuppliersByCityTypedView", "CompanyName", typeof(System.String), false, false, true, false, (int)CustomerAndSuppliersByCityFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("CustomerAndSuppliersByCityTypedView", "ContactName", typeof(System.String), false, false, true, false, (int)CustomerAndSuppliersByCityFieldIndex.ContactName, 30, 0, 0);
			this.AddElementFieldInfo("CustomerAndSuppliersByCityTypedView", "Relationship", typeof(System.String), false, false, true, false, (int)CustomerAndSuppliersByCityFieldIndex.Relationship, 9, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitInvoicesTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(InvoicesFieldIndex), "InvoicesTypedView");
			this.AddElementFieldInfo("InvoicesTypedView", "ShipName", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipName, 40, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipAddress", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipAddress, 60, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipCity", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipCity, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipRegion", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipRegion, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipPostalCode", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipPostalCode, 10, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipCountry", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipCountry, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "CustomerId", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "CustomerName", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.CustomerName, 40, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "Address", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.Address, 60, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "City", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "Region", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.Region, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "PostalCode", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "Country", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.Country, 15, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "Salesperson", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.Salesperson, 31, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)InvoicesFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("InvoicesTypedView", "OrderDate", typeof(System.DateTime), false, false, true, false, (int)InvoicesFieldIndex.OrderDate, 0, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "RequiredDate", typeof(System.DateTime), false, false, true, false, (int)InvoicesFieldIndex.RequiredDate, 0, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShippedDate", typeof(System.DateTime), false, false, true, false, (int)InvoicesFieldIndex.ShippedDate, 0, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ShipperName", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ShipperName, 40, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "ProductId", typeof(System.Int32), false, false, true, false, (int)InvoicesFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("InvoicesTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)InvoicesFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("InvoicesTypedView", "UnitPrice", typeof(System.Decimal), false, false, true, false, (int)InvoicesFieldIndex.UnitPrice, 0, 4, 19);
			this.AddElementFieldInfo("InvoicesTypedView", "Quantity", typeof(System.Int16), false, false, true, false, (int)InvoicesFieldIndex.Quantity, 0, 0, 5);
			this.AddElementFieldInfo("InvoicesTypedView", "Discount", typeof(System.Single), false, false, true, false, (int)InvoicesFieldIndex.Discount, 0, 0, 24);
			this.AddElementFieldInfo("InvoicesTypedView", "ExtendedPrice", typeof(System.Decimal), false, false, true, false, (int)InvoicesFieldIndex.ExtendedPrice, 0, 4, 19);
			this.AddElementFieldInfo("InvoicesTypedView", "Freight", typeof(System.Decimal), false, false, true, false, (int)InvoicesFieldIndex.Freight, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitOrderDetailsExtendedTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrderDetailsExtendedFieldIndex), "OrderDetailsExtendedTypedView");
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "ProductId", typeof(System.Int32), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.ProductId, 0, 0, 10);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "UnitPrice", typeof(System.Decimal), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.UnitPrice, 0, 4, 19);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "Quantity", typeof(System.Int16), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.Quantity, 0, 0, 5);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "Discount", typeof(System.Single), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.Discount, 0, 0, 24);
			this.AddElementFieldInfo("OrderDetailsExtendedTypedView", "ExtendedPrice", typeof(System.Decimal), false, false, true, false, (int)OrderDetailsExtendedFieldIndex.ExtendedPrice, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitOrdersQryTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrdersQryFieldIndex), "OrdersQryTypedView");
			this.AddElementFieldInfo("OrdersQryTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)OrdersQryFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("OrdersQryTypedView", "CustomerId", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "EmployeeId", typeof(System.Int32), false, false, true, false, (int)OrdersQryFieldIndex.EmployeeId, 0, 0, 10);
			this.AddElementFieldInfo("OrdersQryTypedView", "OrderDate", typeof(System.DateTime), false, false, true, false, (int)OrdersQryFieldIndex.OrderDate, 0, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "RequiredDate", typeof(System.DateTime), false, false, true, false, (int)OrdersQryFieldIndex.RequiredDate, 0, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShippedDate", typeof(System.DateTime), false, false, true, false, (int)OrdersQryFieldIndex.ShippedDate, 0, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipVia", typeof(System.Int32), false, false, true, false, (int)OrdersQryFieldIndex.ShipVia, 0, 0, 10);
			this.AddElementFieldInfo("OrdersQryTypedView", "Freight", typeof(System.Decimal), false, false, true, false, (int)OrdersQryFieldIndex.Freight, 0, 4, 19);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipName", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipName, 40, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipAddress", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipAddress, 60, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipCity", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipCity, 15, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipRegion", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipRegion, 15, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipPostalCode", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipPostalCode, 10, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "ShipCountry", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.ShipCountry, 15, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "CompanyName", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "Address", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.Address, 60, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "City", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "Region", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.Region, 15, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "PostalCode", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("OrdersQryTypedView", "Country", typeof(System.String), false, false, true, false, (int)OrdersQryFieldIndex.Country, 15, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitOrderSubtotalTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrderSubtotalFieldIndex), "OrderSubtotalTypedView");
			this.AddElementFieldInfo("OrderSubtotalTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)OrderSubtotalFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("OrderSubtotalTypedView", "Subtotal", typeof(System.Decimal), false, false, true, false, (int)OrderSubtotalFieldIndex.Subtotal, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitProductsAboveAveragePriceTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ProductsAboveAveragePriceFieldIndex), "ProductsAboveAveragePriceTypedView");
			this.AddElementFieldInfo("ProductsAboveAveragePriceTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)ProductsAboveAveragePriceFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("ProductsAboveAveragePriceTypedView", "UnitPrice", typeof(System.Decimal), false, false, true, false, (int)ProductsAboveAveragePriceFieldIndex.UnitPrice, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitProductSalesFor1997TypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ProductSalesFor1997FieldIndex), "ProductSalesFor1997TypedView");
			this.AddElementFieldInfo("ProductSalesFor1997TypedView", "CategoryName", typeof(System.String), false, false, true, false, (int)ProductSalesFor1997FieldIndex.CategoryName, 15, 0, 0);
			this.AddElementFieldInfo("ProductSalesFor1997TypedView", "ProductName", typeof(System.String), false, false, true, false, (int)ProductSalesFor1997FieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("ProductSalesFor1997TypedView", "ProductSales", typeof(System.Decimal), false, false, true, false, (int)ProductSalesFor1997FieldIndex.ProductSales, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitProductsByCategoryTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ProductsByCategoryFieldIndex), "ProductsByCategoryTypedView");
			this.AddElementFieldInfo("ProductsByCategoryTypedView", "CategoryName", typeof(System.String), false, false, true, false, (int)ProductsByCategoryFieldIndex.CategoryName, 15, 0, 0);
			this.AddElementFieldInfo("ProductsByCategoryTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)ProductsByCategoryFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("ProductsByCategoryTypedView", "QuantityPerUnit", typeof(System.String), false, false, true, false, (int)ProductsByCategoryFieldIndex.QuantityPerUnit, 20, 0, 0);
			this.AddElementFieldInfo("ProductsByCategoryTypedView", "UnitsInStock", typeof(System.Int16), false, false, true, false, (int)ProductsByCategoryFieldIndex.UnitsInStock, 0, 0, 5);
			this.AddElementFieldInfo("ProductsByCategoryTypedView", "Discontinued", typeof(System.Boolean), false, false, true, false, (int)ProductsByCategoryFieldIndex.Discontinued, 0, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitQuarterlyOrderTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(QuarterlyOrderFieldIndex), "QuarterlyOrderTypedView");
			this.AddElementFieldInfo("QuarterlyOrderTypedView", "CustomerId", typeof(System.String), false, false, true, false, (int)QuarterlyOrderFieldIndex.CustomerId, 5, 0, 0);
			this.AddElementFieldInfo("QuarterlyOrderTypedView", "CompanyName", typeof(System.String), false, false, true, false, (int)QuarterlyOrderFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("QuarterlyOrderTypedView", "City", typeof(System.String), false, false, true, false, (int)QuarterlyOrderFieldIndex.City, 15, 0, 0);
			this.AddElementFieldInfo("QuarterlyOrderTypedView", "Country", typeof(System.String), false, false, true, false, (int)QuarterlyOrderFieldIndex.Country, 15, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitSalesByCategoryTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SalesByCategoryFieldIndex), "SalesByCategoryTypedView");
			this.AddElementFieldInfo("SalesByCategoryTypedView", "CategoryId", typeof(System.Int32), false, false, true, false, (int)SalesByCategoryFieldIndex.CategoryId, 0, 0, 10);
			this.AddElementFieldInfo("SalesByCategoryTypedView", "CategoryName", typeof(System.String), false, false, true, false, (int)SalesByCategoryFieldIndex.CategoryName, 15, 0, 0);
			this.AddElementFieldInfo("SalesByCategoryTypedView", "ProductName", typeof(System.String), false, false, true, false, (int)SalesByCategoryFieldIndex.ProductName, 40, 0, 0);
			this.AddElementFieldInfo("SalesByCategoryTypedView", "ProductSales", typeof(System.Decimal), false, false, true, false, (int)SalesByCategoryFieldIndex.ProductSales, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitSalesTotalsByAmountTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SalesTotalsByAmountFieldIndex), "SalesTotalsByAmountTypedView");
			this.AddElementFieldInfo("SalesTotalsByAmountTypedView", "SaleAmount", typeof(System.Decimal), false, false, true, false, (int)SalesTotalsByAmountFieldIndex.SaleAmount, 0, 4, 19);
			this.AddElementFieldInfo("SalesTotalsByAmountTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)SalesTotalsByAmountFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("SalesTotalsByAmountTypedView", "CompanyName", typeof(System.String), false, false, true, false, (int)SalesTotalsByAmountFieldIndex.CompanyName, 40, 0, 0);
			this.AddElementFieldInfo("SalesTotalsByAmountTypedView", "ShippedDate", typeof(System.DateTime), false, false, true, false, (int)SalesTotalsByAmountFieldIndex.ShippedDate, 0, 0, 0);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitSummaryOfSalesByQuarterTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SummaryOfSalesByQuarterFieldIndex), "SummaryOfSalesByQuarterTypedView");
			this.AddElementFieldInfo("SummaryOfSalesByQuarterTypedView", "ShippedDate", typeof(System.DateTime), false, false, true, false, (int)SummaryOfSalesByQuarterFieldIndex.ShippedDate, 0, 0, 0);
			this.AddElementFieldInfo("SummaryOfSalesByQuarterTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)SummaryOfSalesByQuarterFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("SummaryOfSalesByQuarterTypedView", "Subtotal", typeof(System.Decimal), false, false, true, false, (int)SummaryOfSalesByQuarterFieldIndex.Subtotal, 0, 4, 19);
		}
		/// <summary>Inits View's FieldInfo objects</summary>
		private void InitSummaryOfSalesByYearTypedViewInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SummaryOfSalesByYearFieldIndex), "SummaryOfSalesByYearTypedView");
			this.AddElementFieldInfo("SummaryOfSalesByYearTypedView", "ShippedDate", typeof(System.DateTime), false, false, true, false, (int)SummaryOfSalesByYearFieldIndex.ShippedDate, 0, 0, 0);
			this.AddElementFieldInfo("SummaryOfSalesByYearTypedView", "OrderId", typeof(System.Int32), false, false, true, false, (int)SummaryOfSalesByYearFieldIndex.OrderId, 0, 0, 10);
			this.AddElementFieldInfo("SummaryOfSalesByYearTypedView", "Subtotal", typeof(System.Decimal), false, false, true, false, (int)SummaryOfSalesByYearFieldIndex.Subtotal, 0, 4, 19);
		}		
	}
}




