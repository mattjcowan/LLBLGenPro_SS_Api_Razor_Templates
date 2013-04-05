///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Thursday, April 04, 2013 7:01:34 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using Northwind.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Northwind.Data.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory
	{
		private int _aliasCounter = 0;

		/// <summary>Creates a new DynamicQuery instance with no alias set.</summary>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create()
		{
			return Create(string.Empty);
		}

		/// <summary>Creates a new DynamicQuery instance with the alias specified as the alias set.</summary>
		/// <param name="alias">The alias.</param>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create(string alias)
		{
			return new DynamicQuery(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
	
		/// <summary>Creates a new EntityQuery for the entity of the type specified with no alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>()
			where TEntity : IEntityCore
		{
			return Create<TEntity>(string.Empty);
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with the alias specified as the alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <param name="alias">The alias.</param>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>(string alias)
			where TEntity : IEntityCore
		{
			return new EntityQuery<TEntity>(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
				
		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string fieldName)
		{
			return Field<object>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field(string targetAlias, string fieldName)
		{
			return Field<object>(targetAlias, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value represented by the field.</typeparam>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string fieldName)
		{
			return Field<TValue>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField2 Field<TValue>(string targetAlias, string fieldName)
		{
			return new EntityField2(fieldName, targetAlias, typeof(TValue));
		}
		
		/// <summary>Gets the next alias counter value to produce artifical aliases with</summary>
		private int GetNextAliasCounterValue()
		{
			_aliasCounter++;
			return _aliasCounter;
		}
		
		/// <summary>Creates and returns a new EntityQuery for the Category entity</summary>
		public EntityQuery<CategoryEntity> Category
		{
			get { return Create<CategoryEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Customer entity</summary>
		public EntityQuery<CustomerEntity> Customer
		{
			get { return Create<CustomerEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CustomerCustomerDemo entity</summary>
		public EntityQuery<CustomerCustomerDemoEntity> CustomerCustomerDemo
		{
			get { return Create<CustomerCustomerDemoEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CustomerDemographic entity</summary>
		public EntityQuery<CustomerDemographicEntity> CustomerDemographic
		{
			get { return Create<CustomerDemographicEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Employee entity</summary>
		public EntityQuery<EmployeeEntity> Employee
		{
			get { return Create<EmployeeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the EmployeeTerritory entity</summary>
		public EntityQuery<EmployeeTerritoryEntity> EmployeeTerritory
		{
			get { return Create<EmployeeTerritoryEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Order entity</summary>
		public EntityQuery<OrderEntity> Order
		{
			get { return Create<OrderEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the OrderDetail entity</summary>
		public EntityQuery<OrderDetailEntity> OrderDetail
		{
			get { return Create<OrderDetailEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Product entity</summary>
		public EntityQuery<ProductEntity> Product
		{
			get { return Create<ProductEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Region entity</summary>
		public EntityQuery<RegionEntity> Region
		{
			get { return Create<RegionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Shipper entity</summary>
		public EntityQuery<ShipperEntity> Shipper
		{
			get { return Create<ShipperEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Supplier entity</summary>
		public EntityQuery<SupplierEntity> Supplier
		{
			get { return Create<SupplierEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Territory entity</summary>
		public EntityQuery<TerritoryEntity> Territory
		{
			get { return Create<TerritoryEntity>(); }
		}

	}
}