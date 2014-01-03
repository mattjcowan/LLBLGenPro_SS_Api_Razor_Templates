///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Thursday, January 02, 2014 6:55:38 PM
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
	/// <summary>Implements the relations factory for the entity: Territory. </summary>
	public partial class TerritoryRelations
	{
		/// <summary>CTor</summary>
		public TerritoryRelations()
		{
		}

		/// <summary>Gets all relations of the TerritoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EmployeeTerritoryEntityUsingTerritoryId);
			toReturn.Add(this.RegionEntityUsingRegionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and EmployeeTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Territory.TerritoryId - EmployeeTerritory.TerritoryId
		/// </summary>
		public virtual IEntityRelation EmployeeTerritoryEntityUsingTerritoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmployeeTerritories" , true);
				relation.AddEntityFieldPair(TerritoryFields.TerritoryId, EmployeeTerritoryFields.TerritoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeTerritoryEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TerritoryEntity and RegionEntity over the m:1 relation they have, using the relation between the fields:
		/// Territory.RegionId - Region.RegionId
		/// </summary>
		public virtual IEntityRelation RegionEntityUsingRegionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Region", false);
				relation.AddEntityFieldPair(RegionFields.RegionId, TerritoryFields.RegionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RegionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", true);
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
	internal static class StaticTerritoryRelations
	{
		internal static readonly IEntityRelation EmployeeTerritoryEntityUsingTerritoryIdStatic = new TerritoryRelations().EmployeeTerritoryEntityUsingTerritoryId;
		internal static readonly IEntityRelation RegionEntityUsingRegionIdStatic = new TerritoryRelations().RegionEntityUsingRegionId;

		/// <summary>CTor</summary>
		static StaticTerritoryRelations()
		{
		}
	}
}
