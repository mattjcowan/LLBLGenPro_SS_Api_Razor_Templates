///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
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
	/// <summary>Implements the relations factory for the entity: CustomerCustomerDemo. </summary>
	public partial class CustomerCustomerDemoRelations
	{
		/// <summary>CTor</summary>
		public CustomerCustomerDemoRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerCustomerDemoEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerEntityUsingCustomerId);
			toReturn.Add(this.CustomerDemographicEntityUsingCustomerTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between CustomerCustomerDemoEntity and CustomerEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerCustomerDemo.CustomerId - Customer.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Customer", false);
				relation.AddEntityFieldPair(CustomerFields.CustomerId, CustomerCustomerDemoFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCustomerDemoEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerCustomerDemoEntity and CustomerDemographicEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerCustomerDemo.CustomerTypeId - CustomerDemographic.CustomerTypeId
		/// </summary>
		public virtual IEntityRelation CustomerDemographicEntityUsingCustomerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerDemographic", false);
				relation.AddEntityFieldPair(CustomerDemographicFields.CustomerTypeId, CustomerCustomerDemoFields.CustomerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerDemographicEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCustomerDemoEntity", true);
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
	internal static class StaticCustomerCustomerDemoRelations
	{
		internal static readonly IEntityRelation CustomerEntityUsingCustomerIdStatic = new CustomerCustomerDemoRelations().CustomerEntityUsingCustomerId;
		internal static readonly IEntityRelation CustomerDemographicEntityUsingCustomerTypeIdStatic = new CustomerCustomerDemoRelations().CustomerDemographicEntityUsingCustomerTypeId;

		/// <summary>CTor</summary>
		static StaticCustomerCustomerDemoRelations()
		{
		}
	}
}
