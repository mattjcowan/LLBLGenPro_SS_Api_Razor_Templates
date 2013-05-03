///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Friday, May 03, 2013 10:20:04 AM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data.DatabaseSpecific
{
	/// <summary>Class which contains the static logic to execute retrieval stored procedures in the database.</summary>
	public static partial class RetrievalProcedures
	{



		/// <summary>Calls stored procedure 'CustOrderHist'.<br/><br/></summary>
		/// <param name="customerId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrderHist(System.String customerId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CustOrderHist(customerId, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CustOrderHist'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="customerId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrderHist(System.String customerId, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCustOrderHistCall(dataAccessProvider, customerId))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CustOrderHist'.</summary>
		/// <param name="customerId">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCustOrderHistCallAsQuery(System.String customerId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateCustOrderHistCall(dataAccessProvider, customerId).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'CustOrdersDetail'.<br/><br/></summary>
		/// <param name="orderId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrdersDetail(System.Int32 orderId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CustOrdersDetail(orderId, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CustOrdersDetail'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="orderId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrdersDetail(System.Int32 orderId, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCustOrdersDetailCall(dataAccessProvider, orderId))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CustOrdersDetail'.</summary>
		/// <param name="orderId">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCustOrdersDetailCallAsQuery(System.Int32 orderId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateCustOrdersDetailCall(dataAccessProvider, orderId).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'CustOrdersOrders'.<br/><br/></summary>
		/// <param name="customerId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrdersOrders(System.String customerId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CustOrdersOrders(customerId, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'CustOrdersOrders'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="customerId">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable CustOrdersOrders(System.String customerId, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateCustOrdersOrdersCall(dataAccessProvider, customerId))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'CustOrdersOrders'.</summary>
		/// <param name="customerId">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetCustOrdersOrdersCallAsQuery(System.String customerId)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateCustOrdersOrdersCall(dataAccessProvider, customerId).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'Employee Sales by Country'.<br/><br/></summary>
		/// <param name="beginningDate">Input parameter. </param>
		/// <param name="endingDate">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable EmployeeSalesByCountry(System.DateTime beginningDate, System.DateTime endingDate)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return EmployeeSalesByCountry(beginningDate, endingDate, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'Employee Sales by Country'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="beginningDate">Input parameter. </param>
		/// <param name="endingDate">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable EmployeeSalesByCountry(System.DateTime beginningDate, System.DateTime endingDate, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateEmployeeSalesByCountryCall(dataAccessProvider, beginningDate, endingDate))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'Employee Sales by Country'.</summary>
		/// <param name="beginningDate">Input parameter of stored procedure</param>
		/// <param name="endingDate">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetEmployeeSalesByCountryCallAsQuery(System.DateTime beginningDate, System.DateTime endingDate)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateEmployeeSalesByCountryCall(dataAccessProvider, beginningDate, endingDate).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'SalesByCategory'.<br/><br/></summary>
		/// <param name="categoryName">Input parameter. </param>
		/// <param name="ordYear">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SalesByCategoryAndYear(System.String categoryName, System.String ordYear)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return SalesByCategoryAndYear(categoryName, ordYear, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'SalesByCategory'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="categoryName">Input parameter. </param>
		/// <param name="ordYear">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SalesByCategoryAndYear(System.String categoryName, System.String ordYear, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateSalesByCategoryAndYearCall(dataAccessProvider, categoryName, ordYear))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'SalesByCategory'.</summary>
		/// <param name="categoryName">Input parameter of stored procedure</param>
		/// <param name="ordYear">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetSalesByCategoryAndYearCallAsQuery(System.String categoryName, System.String ordYear)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateSalesByCategoryAndYearCall(dataAccessProvider, categoryName, ordYear).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'Sales by Year'.<br/><br/></summary>
		/// <param name="beginningDate">Input parameter. </param>
		/// <param name="endingDate">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SalesByYear(System.DateTime beginningDate, System.DateTime endingDate)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return SalesByYear(beginningDate, endingDate, dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'Sales by Year'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="beginningDate">Input parameter. </param>
		/// <param name="endingDate">Input parameter. </param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable SalesByYear(System.DateTime beginningDate, System.DateTime endingDate, IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateSalesByYearCall(dataAccessProvider, beginningDate, endingDate))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'Sales by Year'.</summary>
		/// <param name="beginningDate">Input parameter of stored procedure</param>
		/// <param name="endingDate">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetSalesByYearCallAsQuery(System.DateTime beginningDate, System.DateTime endingDate)
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateSalesByYearCall(dataAccessProvider, beginningDate, endingDate).ToRetrievalQuery();
			}
		}

		/// <summary>Calls stored procedure 'Ten Most Expensive Products'.<br/><br/></summary>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable TenMostExpensiveProducts()
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return TenMostExpensiveProducts(dataAccessProvider);
			}
		}

		/// <summary>Calls stored procedure 'Ten Most Expensive Products'.<br/><br/></summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable TenMostExpensiveProducts(IDataAccessCore dataAccessProvider)
		{
			using(StoredProcedureCall call = CreateTenMostExpensiveProductsCall(dataAccessProvider))
			{
				DataTable toReturn = call.FillDataTable();
				return toReturn;
			}
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'Ten Most Expensive Products'.</summary>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetTenMostExpensiveProductsCallAsQuery()
		{
			using(DataAccessAdapter dataAccessProvider = new DataAccessAdapter())
			{
				return CreateTenMostExpensiveProductsCall(dataAccessProvider).ToRetrievalQuery();
			}
		}

		/// <summary>Creates the call object for the call 'CustOrderHist' to stored procedure 'CustOrderHist'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="customerId">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCustOrderHistCall(IDataAccessCore dataAccessProvider, System.String customerId)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[CustOrderHist]", "CustOrderHist")
							.AddParameter("@CustomerID", "NChar", 5, ParameterDirection.Input, true, 0, 0, customerId);
		}

		/// <summary>Creates the call object for the call 'CustOrdersDetail' to stored procedure 'CustOrdersDetail'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="orderId">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCustOrdersDetailCall(IDataAccessCore dataAccessProvider, System.Int32 orderId)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[CustOrdersDetail]", "CustOrdersDetail")
							.AddParameter("@OrderID", "Int", 0, ParameterDirection.Input, true, 10, 0, orderId);
		}

		/// <summary>Creates the call object for the call 'CustOrdersOrders' to stored procedure 'CustOrdersOrders'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="customerId">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateCustOrdersOrdersCall(IDataAccessCore dataAccessProvider, System.String customerId)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[CustOrdersOrders]", "CustOrdersOrders")
							.AddParameter("@CustomerID", "NChar", 5, ParameterDirection.Input, true, 0, 0, customerId);
		}

		/// <summary>Creates the call object for the call 'EmployeeSalesByCountry' to stored procedure 'Employee Sales by Country'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="beginningDate">Input parameter</param>
		/// <param name="endingDate">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateEmployeeSalesByCountryCall(IDataAccessCore dataAccessProvider, System.DateTime beginningDate, System.DateTime endingDate)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[Employee Sales by Country]", "EmployeeSalesByCountry")
							.AddParameter("@Beginning_Date", "DateTime", 0, ParameterDirection.Input, true, 0, 0, beginningDate)
							.AddParameter("@Ending_Date", "DateTime", 0, ParameterDirection.Input, true, 0, 0, endingDate);
		}

		/// <summary>Creates the call object for the call 'SalesByCategoryAndYear' to stored procedure 'SalesByCategory'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="categoryName">Input parameter</param>
		/// <param name="ordYear">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateSalesByCategoryAndYearCall(IDataAccessCore dataAccessProvider, System.String categoryName, System.String ordYear)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[SalesByCategory]", "SalesByCategoryAndYear")
							.AddParameter("@CategoryName", "NVarChar", 15, ParameterDirection.Input, true, 0, 0, categoryName)
							.AddParameter("@OrdYear", "NVarChar", 4, ParameterDirection.Input, true, 0, 0, ordYear);
		}

		/// <summary>Creates the call object for the call 'SalesByYear' to stored procedure 'Sales by Year'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <param name="beginningDate">Input parameter</param>
		/// <param name="endingDate">Input parameter</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateSalesByYearCall(IDataAccessCore dataAccessProvider, System.DateTime beginningDate, System.DateTime endingDate)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[Sales by Year]", "SalesByYear")
							.AddParameter("@Beginning_Date", "DateTime", 0, ParameterDirection.Input, true, 0, 0, beginningDate)
							.AddParameter("@Ending_Date", "DateTime", 0, ParameterDirection.Input, true, 0, 0, endingDate);
		}

		/// <summary>Creates the call object for the call 'TenMostExpensiveProducts' to stored procedure 'Ten Most Expensive Products'.</summary>
		/// <param name="dataAccessProvider">The data access provider.</param>
		/// <returns>Ready to use StoredProcedureCall object</returns>
		private static StoredProcedureCall CreateTenMostExpensiveProductsCall(IDataAccessCore dataAccessProvider)
		{
			return new StoredProcedureCall(dataAccessProvider, @"[Northwind].[dbo].[Ten Most Expensive Products]", "TenMostExpensiveProducts");
		}


		#region Included Code

		#endregion
	}
}
