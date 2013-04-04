using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    public partial class CustomerValidator : AbstractValidator<Customer>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public CustomerValidator(): this(null)
        {
        }

        internal CustomerValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END             

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.CustomerId).NotEmpty().Length(1, 5);
                });

            RuleSet("UcCompanyName", () =>
                {
                    RuleFor(y => y.CompanyName).NotEmpty().Length(1, 40);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                    RuleFor(y => y.CustomerId).NotEmpty().Length(1, 5);
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.CustomerId).NotEmpty().Length(1, 5);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.CompanyName).NotEmpty().Length(1, 40);
                    RuleFor(y => y.ContactName).Length(0, 30).Unless(y => y.ContactName == null);
                    RuleFor(y => y.ContactTitle).Length(0, 30).Unless(y => y.ContactTitle == null);
                    RuleFor(y => y.Address).Length(0, 60).Unless(y => y.Address == null);
                    RuleFor(y => y.City).Length(0, 15).Unless(y => y.City == null);
                    RuleFor(y => y.Region).Length(0, 15).Unless(y => y.Region == null);
                    RuleFor(y => y.PostalCode).Length(0, 10).Unless(y => y.PostalCode == null);
                    RuleFor(y => y.Country).Length(0, 15).Unless(y => y.Country == null);
                    RuleFor(y => y.Phone).Length(0, 24).Unless(y => y.Phone == null);
                    RuleFor(y => y.Fax).Length(0, 24).Unless(y => y.Fax == null);

                    //Setup validators on relations (to avoid recursion issues, we will not process any validator types that have already been run)
                    //TODO: To avoid recursion issues, the unfortunate consequence at this time is that some objects may not get validated if they
                    //      have the same validator of a parent object in the graph. We will need to fix this at some point by tracking
                    //      previously validated objects for each type of validator (TBD).
                    if(!ParentValidators.Contains("CustomerCustomerDemoValidator")) 
                      RuleFor(x => x.CustomerCustomerDemos).SetCollectionValidator(new CustomerCustomerDemoValidator(new List<string>( ParentValidators ) { { "CustomerValidator" } })).When(x => x.CustomerCustomerDemos != null);
                    if(!ParentValidators.Contains("OrderValidator")) 
                      RuleFor(x => x.Orders).SetCollectionValidator(new OrderValidator(new List<string>( ParentValidators ) { { "CustomerValidator" } })).When(x => x.Orders != null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                           

    }
}
