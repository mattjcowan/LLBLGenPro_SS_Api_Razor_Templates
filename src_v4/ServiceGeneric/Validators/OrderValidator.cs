using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    public partial class OrderValidator : AbstractValidator<Order>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public OrderValidator(): this(null)
        {
        }

        internal OrderValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.OrderId).GreaterThanOrEqualTo(1);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.OrderId).GreaterThanOrEqualTo(1);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.CustomerId).Length(0, 5).Unless(y => y.CustomerId == null);
                    RuleFor(y => y.ShipName).Length(0, 40).Unless(y => y.ShipName == null);
                    RuleFor(y => y.ShipAddress).Length(0, 60).Unless(y => y.ShipAddress == null);
                    RuleFor(y => y.ShipCity).Length(0, 15).Unless(y => y.ShipCity == null);
                    RuleFor(y => y.ShipRegion).Length(0, 15).Unless(y => y.ShipRegion == null);
                    RuleFor(y => y.ShipPostalCode).Length(0, 10).Unless(y => y.ShipPostalCode == null);
                    RuleFor(y => y.ShipCountry).Length(0, 15).Unless(y => y.ShipCountry == null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END     

    }
}
