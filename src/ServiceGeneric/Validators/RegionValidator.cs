using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    public partial class RegionValidator : AbstractValidator<Region>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public RegionValidator(): this(null)
        {
        }

        internal RegionValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END             

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.RegionId).GreaterThanOrEqualTo(1);
                });

            RuleSet("UcRegionDescription", () =>
                {
                    RuleFor(y => y.RegionDescription).NotEmpty().Length(1, 50);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                    RuleFor(y => y.RegionId).GreaterThanOrEqualTo(1);
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.RegionId).GreaterThanOrEqualTo(1);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.RegionDescription).NotEmpty().Length(1, 50);

                    //Setup validators on relations (to avoid recursion issues, we will not process any validator types that have already been run)
                    //TODO: To avoid recursion issues, the unfortunate consequence at this time is that some objects may not get validated if they
                    //      have the same validator of a parent object in the graph. We will need to fix this at some point by tracking
                    //      previously validated objects for each type of validator (TBD).
                    if(!ParentValidators.Contains("TerritoryValidator")) 
                      RuleFor(x => x.Territories).SetCollectionValidator(new TerritoryValidator(new List<string>( ParentValidators ) { { "RegionValidator" } })).When(x => x.Territories != null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                           

    }
}
