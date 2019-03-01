using System;
using Microsoft.Azure.Cosmos.Table;
using SensorAPI.Models;
using SensorAPI.Services;

namespace SensorAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ICloudService _CloudService;

        public UserRepository(ICloudService cloudService)
        {
            _CloudService = cloudService;
        }


        public UserEntity InsertUser(string userId, string name, string info)
        {
            TableOperation insertOperation;
            try
            {
                //get table
                CloudTable sensorTable = _CloudService.CreateTableAsync("user");

                insertOperation = TableOperation.Insert(new UserEntity(userId, name, info));
                sensorTable.Execute(insertOperation);
            }
            catch (Exception e)
            {
               throw e;
            }
            return (UserEntity) insertOperation.Entity;
        }

        //get specific entry buy userId and name
        public UserEntity GetUser(string userId, string name)
        {
            TableResult retrievedResult;
            try
            {
                //get table
                var sensorTable = _CloudService.CreateTableAsync("user");

                // get one entry
                TableOperation retrieveOperation = TableOperation.Retrieve<UserEntity>(userId, name);
                retrievedResult = sensorTable.Execute(retrieveOperation);
            }
            catch (Exception e)
            {
                throw e;
            }
            return (UserEntity)retrievedResult.Result;
        }
    }
}