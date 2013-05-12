Please read the blog post [Generating a fully RESTful Api and UI from a database with LLBLGen and ServiceStack](http://www.mattjcowan.com/funcoding/2013/03/10/rest-api-with-llblgen-and-servicestack) to learn more about this project.

LLBLGen Pro and ServiceStack REST Api and Razor Templates
=================================

A set of LLBLGen Pro templates to generate a fully RESTful ServiceStack API and HTML interface to manage domain entities.

## DEMO ##

- **Demo site**: [http://northwind.mattjcowan.com][demo-site]
- **Blog post**: [Generating a RESTful Api and UI from a database with LLBLGen and ServiceStack][blog-site]

## CHANGE LOG ##

For all examples below, you may want to use Chrome or a browser that can show you the results (or use Fiddler). 
Chrome is nice in the sense that it always displays the reponse from the server, regardless of status code (200, 400, 401, 404, 500, etc...) and regardless of the content type (JS, XML, etc...).

### Update - May 11, 2013 ###

Added support for Typed Views and Typed Lists (for both LLBLGen 3.5 and 4.0, and using ServiceStack v3.9.38).

- **New blog post**: [RESTful Api and UI for Typed Views and Typed Lists with LLBLGen and ServiceStack][blog-site2]
- **New demo of typed view browser**: [http://northwind.mattjcowan.com/views][demo-typed-views]
- **New demo of typed list browser**: [http://northwind.mattjcowan.com/lists][demo-typed-lists]
- **Previous demo of entity browser**: [http://northwind.mattjcowan.com/views][demo-entities]

### Update - May 3, 2013 ###

Added a new LLBLGen Preset and some additional templates to make the project compatible with the newly released LLBLGen V4 release.

If you are using LLBLGen V4, please pick the "MJC.Presets.Adapter.ServiceStack.V4" preset when generating the code.

### Update - April 4, 2013 ###

The goal for this release was to give developers working with these templates and the generated code a means to further extend the code without impacting the code generation process and future releases of the templates.

Please use the "Issues" section of the GitHub project to file desired enhancements and/or point out issues with the code.

- Primary Key and Unique Constraint requests now respond with a 404 status and a clean response for non-existent records
  
  **Example**: two sample responses for non-existent categorie (PK and UC)
  
  [/categories/99999][10-xml] ([xml][10-xml], [json][10-json])

  [/categories/uc/categoryname/non-existent][11-xml] ([xml][11-xml], [json][11-json])

- Added simple validation to the auto-generated services, for all CREATE/UPDATE/DELETE methods
  The validation gathers up the errors and sends them back with the response.
  
  **Example**: The following code is in response to a DELETE request with an invalid category id at URL: /categories/0
      
        { "responseStatus" : { "errorCode" : "ValidationException",
              "errors" : [ { "errorCode" : "GreaterThanOrEqual",
                    "fieldName" : "CategoryId",
                    "message" : "'Category Id' must be greater than or equal to '1'."
                  } ],
              "message" : "Validation failed: \r\n -- 'Category Id' must be greater than or equal to '1'.",
              "stackTrace" : null
            },
          "result" : false
        }

- Added partial methods throughout the generated code allowing anyone the ability to easily customize the code using partial classes

- Added LLBLGen user regions throughout the generated code allowing developers to easily add bits of code where needed to extend existing functionality

- Added some new settings in LLBLGen designer to specify where the Authenticate attributes should be generated
  
  - You can observe these settings by navigating to Project > Settings > LLBLGen Pro Runtime Framework > ServiceStack

### Update - March 16, 2013 ###

- Cleaned up XML output (nice and tidy now :-))

  **Example**: sample XML to see the tidy output
  
  [/products?limit=10&include=supplier][1-xml] ([xml][1-xml], [json][1-json])

- Introduced a new parameter "limit". When using "limit", disregard the paging object in the response, it does not apply at this time.

  **Example**: Fetch first 15 customers (paging and limits are mutually exclusive, paging trumps the limit parameter)
  
  [/products?limit=5&include=supplier][2-xml] ([xml][2-xml], [json][2-json])
  
  [/customers?limit=15][3-xml] ([xml][3-xml], [json][3-json])

- Introduced deep fetching with max limits within subpaths (no imposed depth boundaries)

  **Example**: Fetch categories with ID = 1, and include 3 related products, and 2 related order details per product, as well as each supplier for each product
  [/categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier][4-xml] ([xml][4-xml], [json][4-json])

- Restricting which fields are fetched no longer just on root item but also related items

  **Example**: Simple query without selecting fields, vs query WITH field selections on related items
  
  [/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order][5-xml] ([xml][5-xml], [json][5-json])
  
  [/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname][6-xml] ([xml][6-xml], [json][6-json])

- Introduced basic relation queries (adding filters on sub-related items)

  **Example**: All products where the supplier is from Japan
  
  [/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier][7-xml] ([xml][7-xml], [json][7-json])
  
  **Example**: You don't have to include the item that your are filtering, see below:
  
  [/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))][8-xml] ([xml][8-xml], [json][8-json])
    
  **Example**: all products sold (that have shipped orders) on the 4th and 5th of July, 1996
  
  [/products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996"][9-xml] ([xml][9-xml], [json][9-json])
  
### Initial Release - March 11, 2013 ###

- Demo site: [http://northwind.mattjcowan.com][demo-site]
- Blog post: [Generating a fully RESTful Api and UI from a database with LLBLGen and ServiceStack][blog-site]

## PLANNED FEATURES ##

- Add relationship aliasing and join type clauses, 
- Be able to filter included items down (not just limit) in response (for example return products and orderdetails and orders, but only those orders where the quantity sold was greater then 30)
- Be able to support aggregates (MAX, MIN, SUM, COUNT) and grouping clauses 

[demo-site]: http://northwind.mattjcowan.com
[blog-site]: http://www.mattjcowan.com/funcoding/2013/03/10/rest-api-with-llblgen-and-servicestack
[blog-site2]: http://www.mattjcowan.com/funcoding/2013/05/11/restful-api-and-ui-for-typed-views-and-typed-lists/
[demo-entities]: http://northwind.mattjcowan.com/entities
[demo-typed-views]: http://northwind.mattjcowan.com/views
[demo-typed-lists]: http://northwind.mattjcowan.com/lists
[1-xml]: http://northwind.mattjcowan.com/products?limit=10&include=supplier&format=xml
[1-json]: http://northwind.mattjcowan.com/products?limit=10&include=supplier&format=json
[2-xml]: http://northwind.mattjcowan.com/products?limit=5&include=supplier&format=xml
[2-json]: http://northwind.mattjcowan.com/products?limit=5&include=supplier&format=json
[3-xml]: http://northwind.mattjcowan.com/customers?limit=15&format=xml
[3-json]: http://northwind.mattjcowan.com/customers?limit=15&format=json
[4-xml]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier&format=xml
[4-json]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier&format=json
[5-xml]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&format=xml
[5-json]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&format=json
[6-xml]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname&format=xml
[6-json]: http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname&format=json
[7-xml]: http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier&format=xml
[7-json]: http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier&format=json
[8-xml]: http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&format=xml
[8-json]: http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&format=json
[9-xml]: http://northwind.mattjcowan.com/products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996"&format=xml
[9-json]: http://northwind.mattjcowan.com/products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996"&format=json
[10-xml]: http://northwind.mattjcowan.com/categories/9999?format=xml
[10-json]: http://northwind.mattjcowan.com/categories/9999?format=json
[11-xml]: http://northwind.mattjcowan.com/categories/uc/categoryname/non-existent?format=xml
[11-json]: http://northwind.mattjcowan.com/categories/uc/categoryname/non-existent?format=json
