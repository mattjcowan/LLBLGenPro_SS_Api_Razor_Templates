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
	/// <summary>Implements the relations factory for the entity: Shipper. </summary>
	public partial class ShipperRelations
	{
		/// <summary>CTor</summary>
		public ShipperRelations()
		{
		}

		/// <summary>Gets all relations of the ShipperEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrderEntityUsingShipVia);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShipperEntity and OrderEntity over the 1:n relation they have, using the relation between the fields:
		/// Shipper.ShipperId - Order.ShipVia
		/// </summary>
		public virtual IEntityRelation OrderEntityUsingShipVia
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Orders" , true);
				relation.AddEntityFieldPair(ShipperFields.ShipperId, OrderFields.ShipVia);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShipperEntity", true);
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
	internal static class StaticShipperRelations
	{
		internal static readonly IEntityRelation OrderEntityUsingShipViaStatic = new ShipperRelations().OrderEntityUsingShipVia;

		/// <summary>CTor</summary>
		static StaticShipperRelations()
		{
		}
	}
}
