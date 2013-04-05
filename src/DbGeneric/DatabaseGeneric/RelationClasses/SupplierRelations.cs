///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: Thursday, April 04, 2013 7:01:34 PM
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
	/// <summary>Implements the relations factory for the entity: Supplier. </summary>
	public partial class SupplierRelations
	{
		/// <summary>CTor</summary>
		public SupplierRelations()
		{
		}

		/// <summary>Gets all relations of the SupplierEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ProductEntityUsingSupplierId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SupplierEntity and ProductEntity over the 1:n relation they have, using the relation between the fields:
		/// Supplier.SupplierId - Product.SupplierId
		/// </summary>
		public virtual IEntityRelation ProductEntityUsingSupplierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Products" , true);
				relation.AddEntityFieldPair(SupplierFields.SupplierId, ProductFields.SupplierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupplierEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", false);
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
	internal static class StaticSupplierRelations
	{
		internal static readonly IEntityRelation ProductEntityUsingSupplierIdStatic = new SupplierRelations().ProductEntityUsingSupplierId;

		/// <summary>CTor</summary>
		static StaticSupplierRelations()
		{
		}
	}
}
