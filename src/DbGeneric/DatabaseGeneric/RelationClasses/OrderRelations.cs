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
using System.Collections;
using System.Collections.Generic;
using Northwind.Data;
using Northwind.Data.FactoryClasses;
using Northwind.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Order. </summary>
	public partial class OrderRelations
	{
		/// <summary>CTor</summary>
		public OrderRelations()
		{
		}

		/// <summary>Gets all relations of the OrderEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrderDetailEntityUsingOrderId);
			toReturn.Add(this.CustomerEntityUsingCustomerId);
			toReturn.Add(this.EmployeeEntityUsingEmployeeId);
			toReturn.Add(this.ShipperEntityUsingShipVia);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrderEntity and OrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// Order.OrderId - OrderDetail.OrderId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingOrderId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrderDetails" , true);
				relation.AddEntityFieldPair(OrderFields.OrderId, OrderDetailFields.OrderId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OrderEntity and CustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// Order.CustomerId - Customer.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Customer", false);
				relation.AddEntityFieldPair(CustomerFields.CustomerId, OrderFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrderEntity and EmployeeEntity over the m:1 relation they have, using the relation between the fields:
		/// Order.EmployeeId - Employee.EmployeeId
		/// </summary>
		public virtual IEntityRelation EmployeeEntityUsingEmployeeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Employee", false);
				relation.AddEntityFieldPair(EmployeeFields.EmployeeId, OrderFields.EmployeeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrderEntity and ShipperEntity over the m:1 relation they have, using the relation between the fields:
		/// Order.ShipVia - Shipper.ShipperId
		/// </summary>
		public virtual IEntityRelation ShipperEntityUsingShipVia
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Shipper", false);
				relation.AddEntityFieldPair(ShipperFields.ShipperId, OrderFields.ShipVia);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShipperEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderEntity", true);
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
	internal static class StaticOrderRelations
	{
		internal static readonly IEntityRelation OrderDetailEntityUsingOrderIdStatic = new OrderRelations().OrderDetailEntityUsingOrderId;
		internal static readonly IEntityRelation CustomerEntityUsingCustomerIdStatic = new OrderRelations().CustomerEntityUsingCustomerId;
		internal static readonly IEntityRelation EmployeeEntityUsingEmployeeIdStatic = new OrderRelations().EmployeeEntityUsingEmployeeId;
		internal static readonly IEntityRelation ShipperEntityUsingShipViaStatic = new OrderRelations().ShipperEntityUsingShipVia;

		/// <summary>CTor</summary>
		static StaticOrderRelations()
		{
		}
	}
}
