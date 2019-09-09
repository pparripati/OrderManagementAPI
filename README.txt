Prerequisite:
	Please follow the steps in README.txt under SEI_DB database project before running the API

Note: 
	1) NuGet packages are not included in Git repo and the zip file. Below running the application please open NuGet package manager and click "restore" to restore from online package sources
	2) Server name, database name (if changed) has to be updated in web.config line 77. key name is "SEIEntities" 



Information:
1) Global Exception handler is added. Complete error detail will be returned only in debug mode
2) Swagger is configured. Please use /swagger to try below API's

Api 1: /api/order (POST)
		JSON samples to create new order(s). To prepare more samples please refer to Appendix to get valid Product & Customer Id
		
		Sample1:
		{
			"productId" : "D00CF1F0-F3AB-4336-930E-A8CB53C23A36",
			"customerId" : "4F4BB36A-5828-4428-A4FF-7DAF9501AA53",
			"orderDate" : "09/08/2019",
			"quantity": 1,
			"pricePaid": 12.49
		}

		Sample 2:
		{
			"productId" : "ED3098CD-2F92-420D-ABA7-0B50C46F5AEC",
			"customerId" : "5ABB57F2-A153-4A24-82FA-D32C3F45FAB6",
			"orderDate" : "09/08/2019",
			"quantity": 1,
			"pricePaid": 9.99,
			"shippedDate": "09/09/2019"
		}

Api 2: /api/pendingorders (GET)
Note: 
1) seed data to get 2 pendingorders (out of 4) is already populated if database project is published
2) If above both sample json for creating the orders is executed then there will be 3 pending orders

Api 3: /api/product (GET)
Note: seed data for 5 products is already populated if database project is published

--------------------------------------------------------------------------------
Appendix:
--------------------------------------------------------------------------------
More samples can be created using below ids. Seed data is already inserted in to tables

Valid Product Id
----------------------------------------
ED3098CD-2F92-420D-ABA7-0B50C46F5AEC
A347DBA4-0E76-4ACE-A66F-31BBC68EB23B
303AFA15-B03F-4508-830F-53EDA4CC8573
9B3BFF26-FFA3-4402-B0C4-A5F20EAE9917
D00CF1F0-F3AB-4336-930E-A8CB53C23A36
----------------------------------------


Valid Customer Id
----------------------------------------
4F4BB36A-5828-4428-A4FF-7DAF9501AA53
5ABB57F2-A153-4A24-82FA-D32C3F45FAB6
2208CD7A-7CA0-43D1-864D-F48C3D309CEA
----------------------------------------