///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Saturday, May 11, 2013 6:40:54 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Northwind.Data;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Customer. </summary>
	public partial class CustomerRelations
	{
		/// <summary>CTor</summary>
		public CustomerRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerCustomerDemoEntityUsingCustomerId);
			toReturn.Add(this.OrderEntityUsingCustomerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerEntity and CustomerCustomerDemoEntity over the 1:n relation they have, using the relation between the fields:
		/// Customer.CustomerId - CustomerCustomerDemo.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerCustomerDemoEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCustomerDemos" , true);
				relation.AddEntityFieldPair(CustomerFields.CustomerId, CustomerCustomerDemoFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCustomerDemoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerEntity and OrderEntity over the 1:n relation they have, using the relation between the fields:
		/// Customer.CustomerId - Order.CustomerId
		/// </summary>
		public virtual IEntityRelation OrderEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Orders" , true);
				relation.AddEntityFieldPair(CustomerFields.CustomerId, OrderFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", false);
				return relation;
			}
		}


		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticCustomerRelations
	{
		internal static readonly IEntityRelation CustomerCustomerDemoEntityUsingCustomerIdStatic = new CustomerRelations().CustomerCustomerDemoEntityUsingCustomerId;
		internal static readonly IEntityRelation OrderEntityUsingCustomerIdStatic = new CustomerRelations().OrderEntityUsingCustomerId;

		/// <summary>CTor</summary>
		static StaticCustomerRelations()
		{
		}
	}
}
