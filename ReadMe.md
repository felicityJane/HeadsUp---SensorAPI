Create a new azure table

1) click HOME in azure
2) Azure Comsos DB
3) +ADD
4) fill in details, at API choose Azure Table
5) review & create
6) create
7) this step takes some time until the ...Your deployment is underway message to go away.
8) once up and running you can click Data Explorer to view tables, you wont have any here 
  to belong with, you can chose to make a table or let the api do it for you.
9)here you can view any data in the table later.

Add you connection strings to API project

1) click Connection String in Azure
2) copy the one second from bottom PRIMARY CONNECTION STRING
3) open visual studio
4) Web.config file
5) paste connection string on line 12 (storage connection string), after value=


Run API

1) run the api application, an error website will pop up thats good - get the local port number
  from the address
2) now you can call the end-points

example http://localhost:portNumber/headsup/postuser/userid/name/info
