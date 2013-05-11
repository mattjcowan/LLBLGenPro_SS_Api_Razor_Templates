using System.Collections.Generic;
using Northwind.Data.Dtos;
using ServiceStack.FluentValidation;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Validators
{ 
    public partial class EmployeeValidator : AbstractValidator<Employee>, IRequiresHttpRequest
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        /// <summary>The HTTP request. Lazily loaded, so only available in the validation delegates.</summary>
        public IHttpRequest HttpRequest { get; set; }

        #region Class Extensibility Methods
        partial void OnCreateValidator();
        #endregion

        private IList<string> ParentValidators { get; set; }

        public EmployeeValidator(): this(null)
        {
        }

        internal EmployeeValidator(IList<string> parentValidators)
        {
            ParentValidators = parentValidators ?? new List<string>();
            OnCreateValidator();
            
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBeforeRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

            //Validation rules for GET requests (READ)
            RuleSet("PkRequest", () =>
                {
                    RuleFor(y => y.EmployeeId).GreaterThanOrEqualTo(1);
                });

            //Validation rules for POST requests (CREATE)
            RuleSet(ApplyTo.Post, () =>
                {
                });
            
            //Validation rules for PUT and DELETE requests (UPDATE / DELETE)
            RuleSet(ApplyTo.Put | ApplyTo.Delete, () =>
                {
                    RuleFor(y => y.EmployeeId).GreaterThanOrEqualTo(1);
                });

            //Common Validation rules for POST and PUT requests (CREATE and UPDATE)
            RuleSet(ApplyTo.Post | ApplyTo.Put, () =>
                {
                    RuleFor(y => y.LastName).NotEmpty().Length(1, 20);
                    RuleFor(y => y.FirstName).NotEmpty().Length(1, 10);
                    RuleFor(y => y.Title).Length(0, 30).Unless(y => y.Title == null);
                    RuleFor(y => y.TitleOfCourtesy).Length(0, 25).Unless(y => y.TitleOfCourtesy == null);
                    RuleFor(y => y.Address).Length(0, 60).Unless(y => y.Address == null);
                    RuleFor(y => y.City).Length(0, 15).Unless(y => y.City == null);
                    RuleFor(y => y.Region).Length(0, 15).Unless(y => y.Region == null);
                    RuleFor(y => y.PostalCode).Length(0, 10).Unless(y => y.PostalCode == null);
                    RuleFor(y => y.Country).Length(0, 15).Unless(y => y.Country == null);
                    RuleFor(y => y.HomePhone).Length(0, 24).Unless(y => y.HomePhone == null);
                    RuleFor(y => y.Extension).Length(0, 4).Unless(y => y.Extension == null);
                    RuleFor(y => y.Notes).Length(0, 1073741823).Unless(y => y.Notes == null);
                    RuleFor(y => y.PhotoPath).Length(0, 255).Unless(y => y.PhotoPath == null);
                });

	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAfterRules 
	// __LLBLGENPRO_USER_CODE_REGION_END 

        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                             

    }
}
