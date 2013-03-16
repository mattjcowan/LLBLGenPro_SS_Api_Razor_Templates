Please read the blog post [Generating a fully RESTful Api and UI from a database with LLBLGen and ServiceStack](http://www.mattjcowan.com/funcoding/2013/03/10/rest-api-with-llblgen-and-servicestack) to learn more about this project.

LLBLGen Pro and ServiceStack REST Api and Razor Templates
=================================

A set of LLBLGen Pro templates to generate a fully RESTful ServiceStack API and HTML interface to manage domain entities.

## DEMO ##

- Demo site: [http://northwind.mattjcowan.com][demo-site]
- Blog post: [Generating a RESTful Api and UI from a database with LLBLGen and ServiceStack]

## CHANGE LOG ##

### Update - March 16, 2013 ###

For the "json" examples below, you may want to use Chrome or a browser that can show you the results (or use Fiddler). IE will have you download the JS.

- Cleaned up XML output (nice and tidy now :-))

  Example: sample XML to see the tidy output
  /products?limit=10&include=supplier [xml][1-xml] [json][1-json]

- Introduced a new parameter "limit". When using "limit", disregard the paging object in the response, it does not apply at this time.

  Example: Fetch first 15 customers (paging and limits are mutually exclusive, paging trumps the limit parameter)
  /products?limit=5&include=supplier [xml][2-xml] [json][2-json]
  /customers?limit=15 [xml][3-xml] [json][3-json]

- Introduced deep fetching with max limits within subpaths (no imposed depth boundaries)

  Example: Fetch categories with ID = 1, and include 3 related products, and 2 related order details per product, as well as each supplier for each product
  /categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier [xml][4-xml] [json][4-json]

- Restricting which fields are fetched no longer just on root item but also related items

  Example: Simple query without selecting fields, vs query WITH field selections on related items
  /categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order [xml][5-xml] [json][5-json]
  /categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname [xml][6-xml] [json][6-json]

- Introduced basic relation queries (adding filters on sub-related items)

  Example: All products where the supplier is from Japan
  /products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier [xml][7-xml] [json][7-json]
  
  Example: You don't have to include the item that your are filtering, see below:
  /products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan)) [xml][8-xml] [json][8-json]
    
  Example: all products sold (that have shipped orders) on the 4th and 5th of July, 1996
  /products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996" [xml][9-xml] [json][9-json]
  
### Initial Release - March 11, 2013 ###

- Demo site: [http://northwind.mattjcowan.com][demo-site]
- Blog post: [Generating a fully RESTful Api and UI from a database with LLBLGen and ServiceStack]

## PLANNED FEATURES ##

- Add relationship aliasing and join type clauses, 
- Be able to filter included items down (not just limit) in response (for example return products and orderdetails and orders, but only those orders where the quantity sold was greater then 30)
- Be able to support aggregates (MAX, MIN, SUM, COUNT) and grouping clauses 

[demo-site] http://northwind.mattjcowan.com
[blog-site] http://www.mattjcowan.com/funcoding/2013/03/10/rest-api-with-llblgen-and-servicestack
[1-xml]   http://northwind.mattjcowan.com/products?limit=10&include=supplier&format=xml
[1-json]  http://northwind.mattjcowan.com/products?limit=10&include=supplier&format=json
[2-xml]   http://northwind.mattjcowan.com/products?limit=5&include=supplier&format=xml
[2-json]  http://northwind.mattjcowan.com/products?limit=5&include=supplier&format=json
[3-xml]   http://northwind.mattjcowan.com/customers?limit=15&format=xml
[3-json]  http://northwind.mattjcowan.com/customers?limit=15&format=json
[4-xml]   http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier&format=xml
[4-json]  http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products:3.orderdetails:2,products.supplier&format=json
[5-xml]   http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&format=xml
[5-json]  http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&format=json
[6-xml]   http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname&format=xml
[6-json]  http://northwind.mattjcowan.com/categories?filter=categoryId:eq:1&include=products.supplier,products.orderdetails:3.order&select=products.orderdetails.order.customerid,products.orderdetails.quantity,categoryid,products.productname,products.supplier.companyname&format=json
[7-xml]   http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier&format=xml
[7-json]  http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&include=supplier&format=json
[8-xml]   http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&format=xml
[8-json]  http://northwind.mattjcowan.com/products?filter=(^(supplierid:neq:14)(categoryid:neq:4)(supplier.country:eq:japan))&format=json
[9-xml]   http://northwind.mattjcowan.com/products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996"&format=xml
[9-json]  http://northwind.mattjcowan.com/products?filter=orderdetails.order.orderDate:bt:"07/04/1996":"07/05/1996"&format=json
