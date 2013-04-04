///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Thursday, April 04, 2013 4:25:31 PM
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
	/// <summary>Implements the relations factory for the entity: CustomerDemographic. </summary>
	public partial class CustomerDemographicRelations
	{
		/// <summary>CTor</summary>
		public CustomerDemographicRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerDemographicEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CustomerCustomerDemoEntityUsingCustomerTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerDemographicEntity and CustomerCustomerDemoEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerDemographic.CustomerTypeId - CustomerCustomerDemo.CustomerTypeId
		/// </summary>
		public virtual IEntityRelation CustomerCustomerDemoEntityUsingCustomerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCustomerDemos" , true);
				relation.AddEntityFieldPair(CustomerDemographicFields.CustomerTypeId, CustomerCustomerDemoFields.CustomerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerDemographicEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCustomerDemoEntity", false);
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
	internal static class StaticCustomerDemographicRelations
	{
		internal static readonly IEntityRelation CustomerCustomerDemoEntityUsingCustomerTypeIdStatic = new CustomerDemographicRelations().CustomerCustomerDemoEntityUsingCustomerTypeId;

		/// <summary>CTor</summary>
		static StaticCustomerDemographicRelations()
		{
		}
	}
}
