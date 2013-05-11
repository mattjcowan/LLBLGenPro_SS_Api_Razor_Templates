using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.ServiceModel;
using ServiceStack.Text;
using Northwind.Data.Dtos;
using Northwind.Data.Dtos.TypedListDtos;
using Northwind.Data.ServiceInterfaces;
using Northwind.Data.ServiceInterfaces.TypedListServiceInterfaces;
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalNamespaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 

namespace Northwind.Data.Services.TypedListServices
{ 
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                             
    [LogRequestFilter, LogExceptionFilter]
    public abstract partial class TypedListServiceBase: Service
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END 
    {
        public string BaseServiceUri
        {
            get { return base.Request.GetApplicationUrl().TrimEnd('/') + "/lists"; }
        }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcBaseAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                     
    }
    
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalAttributes 
	// __LLBLGENPRO_USER_CODE_REGION_END                             
    public abstract partial class TypedListServiceBase<TDto, TRepository>: TypedListServiceBase
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalInterfaces 
	// __LLBLGENPRO_USER_CODE_REGION_END                             
        where TDto: CommonTypedListDtoBase
        where TRepository: ITypedListServiceRepository<TDto>
    {
        // Set using the IoC Container with Property Injection
        public virtual TRepository Repository { get; set; }
        
	// __LLBLGENPRO_USER_CODE_REGION_START SsSvcAdditionalMethods 
	// __LLBLGENPRO_USER_CODE_REGION_END                                                                                     
    }
}
