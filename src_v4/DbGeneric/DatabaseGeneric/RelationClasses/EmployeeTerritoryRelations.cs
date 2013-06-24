///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Monday, June 24, 2013 12:49:15 AM
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
	/// <summary>Implements the relations factory for the entity: EmployeeTerritory. </summary>
	public partial class EmployeeTerritoryRelations
	{
		/// <summary>CTor</summary>
		public EmployeeTerritoryRelations()
		{
		}

		/// <summary>Gets all relations of the EmployeeTerritoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EmployeeEntityUsingEmployeeId);
			toReturn.Add(this.TerritoryEntityUsingTerritoryId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EmployeeTerritoryEntity and EmployeeEntity over the m:1 relation they have, using the relation between the fields:
		/// EmployeeTerritory.EmployeeId - Employee.EmployeeId
		/// </summary>
		public virtual IEntityRelation EmployeeEntityUsingEmployeeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Employee", false);
				relation.AddEntityFieldPair(EmployeeFields.EmployeeId, EmployeeTerritoryFields.EmployeeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeTerritoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EmployeeTerritoryEntity and TerritoryEntity over the m:1 relation they have, using the relation between the fields:
		/// EmployeeTerritory.TerritoryId - Territory.TerritoryId
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Territory", false);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, EmployeeTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeTerritoryEntity", true);
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
	internal static class StaticEmployeeTerritoryRelations
	{
		internal static readonly IEntityRelation EmployeeEntityUsingEmployeeIdStatic = new EmployeeTerritoryRelations().EmployeeEntityUsingEmployeeId;
		internal static readonly IEntityRelation TerritoryEntityUsingTerritoryIdStatic = new EmployeeTerritoryRelations().TerritoryEntityUsingTerritoryId;

		/// <summary>CTor</summary>
		static StaticEmployeeTerritoryRelations()
		{
		}
	}
}
