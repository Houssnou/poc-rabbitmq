# poc-rabbitmq
Rabbitmq proof of concept: .Net microservices using RabbitMQ Messaging as broker.
> You must have Docker installed.

1. Run docker-compose file to create an isntance of RabbitMQ on container:
   . navigate to the root folder of the solution 
   . type ``` 
              docker-compose up -d 
          ``` ( `-d` allows the command to be executed in detached mode)

2. Open this link on the browser to test the running instance of RabbitMQ: http://localhost:15672/ using the super cool credentials in the docker-compose file.
3. Add the following to each service:      
   1. Add the connection string settings to create the database (Banking and Transfer respectively for each service).      
   2. Create the database:        
        -  First, set the API as startup project     
        -  Then, in `Package Manager Console`, select `Infrastructure` as Default Project and run the following:    
        -  ```add-migration "Initial Migration" -Context BankingDbContext``` to create the migrations   
        -  ```update-database -Context BankingDbContext``` to apply the db creation migration to the database 
   3. Ensure that the database are created successfully. 
4. Right on the solution and go to properties then select `Multi Startup Project`:  
  . set `POC.Banking.API` and `POC.Transfer.API` actions to start
5. Launch the project
6. On the pages automatically opened by Visual Studio:  
	. Navigate to the Banking Swagger page and create a transfert  
	. Then navigate to rabbitMQ page, search for the queue and the message  
	. Navigate to the Transfer Swagger page and Test the get all transfert endpoint. 
