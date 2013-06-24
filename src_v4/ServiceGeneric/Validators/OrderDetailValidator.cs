using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    /* Identifying fields:       - OrderId
       - ProductId
    */
    public partial class OrderDetailValidator : AbstractValidator<OrderDetail>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public OrderDetailValidator(): this(null)
        {
        }

        internal OrderDetailValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.OrderId).GreaterThanOrEqualTo(1);
                    RuleFor(y => y.ProductId).GreaterThanOrEqualTo(1);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                    RuleFor(y => y.OrderId).GreaterThanOrEqualTo(1);
                    RuleFor(y => y.ProductId).GreaterThanOrEqualTo(1);
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.OrderId).GreaterThanOrEqualTo(1);
                    RuleFor(y => y.ProductId).GreaterThanOrEqualTo(1);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.UnitPrice).GreaterThanOrEqualTo(0);
                    RuleFor(y => y.Quantity).Must(s => s > 0);
                    RuleFor(y => y.Discount).GreaterThanOrEqualTo(0);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                       

    }
}
