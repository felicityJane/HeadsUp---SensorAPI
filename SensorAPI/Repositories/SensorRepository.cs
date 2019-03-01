using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Cosmos.Table;
using SensorAPI.Models;
using SensorAPI.Services;

namespace SensorAPI.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private ICloudService _CloudService;

        public SensorRepository(ICloudService cloudService)
        {
            _CloudService = cloudService;
        }


        public DataEntity InsertSensorData(string userId, string rowKey, int distance)
        {
            TableOperation insertOperation;
            try
            {
                //get table
                CloudTable sensorTable = _CloudService.CreateTableAsync("sensor");

                //insert
                insertOperation = TableOperation.Insert(new DataEntity(userId, rowKey, distance));
                sensorTable.Execute(insertOperation);
            }
            catch (Exception e)
            {
                throw e;
            }

            return (DataEntity)insertOperation.Entity;
        }

        //get specific entry buy userId and rowkey
        public DataEntity GetSensorData(string userId, string rowkey)
        {
            TableResult retrievedResult;
            try
            {
                //get table
                var sensorTable = _CloudService.CreateTableAsync("sensor");

                // get one entry
                TableOperation retrieveOperation = TableOperation.Retrieve<DataEntity>(userId, rowkey);
                retrievedResult = sensorTable.Execute(retrieveOperation);
            }
            catch (Exception e)
            {
                throw e;
            }

            return (DataEntity)retrievedResult.Result;

        }


        //get all entries by userId and specify parameters for rowkey
        public IEnumerable<DataEntity> GetSensorData(string userId)
        {
            IEnumerable<DataEntity> dataEntity;
            try
            {
                var sensorTable = _CloudService.CreateTableAsync("sensor");

                // list of entries
                TableQuery<DataEntity> retrieveOperation = new TableQuery<DataEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId));

                dataEntity = sensorTable.ExecuteQuery(retrieveOperation);
            }
            catch (Exception e)
            {
                throw e;
            }

            return dataEntity;
        }

        //get entries by userId and specify parameters for rowkey
        public IQueryable<DataEntity> GetSensorDataSpecific(string userId, string rowkey)
        {
            var sensorTable = _CloudService.CreateTableAsync("sensor");

            // list of entries
            TableQuery<DataEntity> retrieveOperation = new TableQuery<DataEntity>().Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userId),
                TableOperators.And,
                TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, "2")));

            IEnumerable<DataEntity> dataEntity = sensorTable.ExecuteQuery(retrieveOperation);

            return (IQueryable<DataEntity>) dataEntity;
        }

    }
}