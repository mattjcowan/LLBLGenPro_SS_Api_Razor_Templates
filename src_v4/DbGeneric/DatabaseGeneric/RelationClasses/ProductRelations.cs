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
	/// <summary>Implements the relations factory for the entity: Product. </summary>
	public partial class ProductRelations
	{
		/// <summary>CTor</summary>
		public ProductRelations()
		{
		}

		/// <summary>Gets all relations of the ProductEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrderDetailEntityUsingProductId);
			toReturn.Add(this.CategoryEntityUsingCategoryId);
			toReturn.Add(this.SupplierEntityUsingSupplierId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ProductEntity and OrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// Product.ProductId - OrderDetail.ProductId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingProductId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrderDetails" , true);
				relation.AddEntityFieldPair(ProductFields.ProductId, OrderDetailFields.ProductId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ProductEntity and CategoryEntity over the m:1 relation they have, using the relation between the fields:
		/// Product.CategoryId - Category.CategoryId
		/// </summary>
		public virtual IEntityRelation CategoryEntityUsingCategoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Category", false);
				relation.AddEntityFieldPair(CategoryFields.CategoryId, ProductFields.CategoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CategoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ProductEntity and SupplierEntity over the m:1 relation they have, using the relation between the fields:
		/// Product.SupplierId - Supplier.SupplierId
		/// </summary>
		public virtual IEntityRelation SupplierEntityUsingSupplierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Supplier", false);
				relation.AddEntityFieldPair(SupplierFields.SupplierId, ProductFields.SupplierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupplierEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProductEntity", true);
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
	internal static class StaticProductRelations
	{
		internal static readonly IEntityRelation OrderDetailEntityUsingProductIdStatic = new ProductRelations().OrderDetailEntityUsingProductId;
		internal static readonly IEntityRelation CategoryEntityUsingCategoryIdStatic = new ProductRelations().CategoryEntityUsingCategoryId;
		internal static readonly IEntityRelation SupplierEntityUsingSupplierIdStatic = new ProductRelations().SupplierEntityUsingSupplierId;

		/// <summary>CTor</summary>
		static StaticProductRelations()
		{
		}
	}
}
