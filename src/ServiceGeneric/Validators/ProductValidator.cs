using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    public partial class ProductValidator : AbstractValidator<Product>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public ProductValidator(): this(null)
        {
        }

        internal ProductValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END             

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.ProductId).GreaterThanOrEqualTo(1);
                });

            RuleSet("UcProductName", () =>
                {
                    RuleFor(y => y.ProductName).NotEmpty().Length(1, 40);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.ProductId).GreaterThanOrEqualTo(1);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.ProductName).NotEmpty().Length(1, 40);
                    RuleFor(y => y.QuantityPerUnit).Length(0, 20).Unless(y => y.QuantityPerUnit == null);

                    //Setup validators on relations (to avoid recursion issues, we will not process any validator types that have already been run)
                    //TODO: To avoid recursion issues, the unfortunate consequence at this time is that some objects may not get validated if they
                    //      have the same validator of a parent object in the graph. We will need to fix this at some point by tracking
                    //      previously validated objects for each type of validator (TBD).
                    if(!ParentValidators.Contains("CategoryValidator")) 
                      RuleFor(x => x.Category).SetValidator(new CategoryValidator(new List<string>( ParentValidators ) { { "ProductValidator" } })).When(x => x.Category != null);
                    if(!ParentValidators.Contains("OrderDetailValidator")) 
                      RuleFor(x => x.OrderDetails).SetCollectionValidator(new OrderDetailValidator(new List<string>( ParentValidators ) { { "ProductValidator" } })).When(x => x.OrderDetails != null);
                    if(!ParentValidators.Contains("SupplierValidator")) 
                      RuleFor(x => x.Supplier).SetValidator(new SupplierValidator(new List<string>( ParentValidators ) { { "ProductValidator" } })).When(x => x.Supplier != null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                           

    }
}
