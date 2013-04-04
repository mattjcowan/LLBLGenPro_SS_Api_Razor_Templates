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

                    //Setup validators on relations (to avoid recursion issues, we will not process any validator types that have already been run)
                    //TODO: To avoid recursion issues, the unfortunate consequence at this time is that some objects may not get validated if they
                    //      have the same validator of a parent object in the graph. We will need to fix this at some point by tracking
                    //      previously validated objects for each type of validator (TBD).
                    if(!ParentValidators.Contains("CustomerValidator")) 
                      RuleFor(x => x.Customer).SetValidator(new CustomerValidator(new List<string>( ParentValidators ) { { "OrderValidator" } })).When(x => x.Customer != null);
                    if(!ParentValidators.Contains("EmployeeValidator")) 
                      RuleFor(x => x.Employee).SetValidator(new EmployeeValidator(new List<string>( ParentValidators ) { { "OrderValidator" } })).When(x => x.Employee != null);
                    if(!ParentValidators.Contains("OrderDetailValidator")) 
                      RuleFor(x => x.OrderDetails).SetCollectionValidator(new OrderDetailValidator(new List<string>( ParentValidators ) { { "OrderValidator" } })).When(x => x.OrderDetails != null);
                    if(!ParentValidators.Contains("ShipperValidator")) 
                      RuleFor(x => x.Shipper).SetValidator(new ShipperValidator(new List<string>( ParentValidators ) { { "OrderValidator" } })).When(x => x.Shipper != null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                           

    }
}
