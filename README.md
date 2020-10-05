# ComparisonTech.API

1)	Swagger has been enabled. Please use https://localhost:44358/swagger
2)	The user is anonymous. However, we still need to distinguish the messages that belong to each anonymous user. We assume that when user lands in the website, a certain anonymoustrackingId will be generated and added either to the headers or cookies (Google after recent updates has certain problems with cookies and hence we need to enable the anonymous trackingid to be exposed via the headers). This is a very valid scenario we can use in similar journeys like when anonymous user checks out an order. This is how I would design and implement it. The test requires (prod-ready code so parts of the test need to be real implementations)
3)	Before you start posting messages, please generate an anonymous tracking id using POST / anonoymousTrackingId. We can then later use the anonoymousTrackingId in POST /messageboard and GET /messageBoard requests.

Improvements
1)	Obviously, the IFakeDBContext needs to be replaced with an actual storage implantation (EF, Dapper etc)
2)	Integration tests and more unit tests.
