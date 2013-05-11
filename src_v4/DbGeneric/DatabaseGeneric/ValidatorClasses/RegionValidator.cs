///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.0
// Code is generated on: Saturday, May 11, 2013 6:38:28 PM
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using Northwind.Data;
using Northwind.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Northwind.Data.ValidatorClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Implementation of the Region Validator class. This class is the default location for validation rules for the
	/// RegionEntity class. 	/// This class is generated. A special user code region is available for you to add your own validation logic by overriding the base class methods. This code is preserved between code generation cycles.
	/// Though it's recommended that you use a partial class.</summary>
	[Serializable]
	public partial class RegionValidator : ValidatorBase
	{
		// Add your own validation code between the two region markers below. You can also use a partial class and add your overrides in that partial class.
		
		// __LLBLGENPRO_USER_CODE_REGION_START ValidationCode
		// TODO: Add your own validation code here. Do that by overriding base class methods.
		// __LLBLGENPRO_USER_CODE_REGION_END

		#region Code preservation logic for upgrading from 1.0.200x.y to v2.
		/// <summary> Method which is used to preserve code written in validator classes when LLBLGen Pro v1.0.200x.y was used. Please consult the Migrating Your Code section in the manual
		/// for details about this method and the contents of it.</summary>
		/// <param name="fieldIndex">Index of the field</param>
		/// <param name="value">new value of the field.</param>
		/// <returns>true, if value is a valid value for the field with index fieldIndex, false otherwise.</returns>
		/// <remarks>For code preservation only. If empty, ignore this method.</remarks>
		protected virtual bool OriginalValidate(int fieldIndex, object value)
		{
			bool toReturn = true;
			
			// __LLBLGENPRO_USER_CODE_REGION_START ValidationLogic
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		#endregion

		#region Included Code

		#endregion
	}
}

