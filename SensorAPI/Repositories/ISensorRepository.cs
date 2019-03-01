using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public interface ISensorRepository
    {
        //add entry
        DataEntity InsertSensorData(string userId, string rowKey, int distance);

        //get entry by userId
        DataEntity GetSensorData(string userId, string rowkey);

        //get all entries by userId
        IEnumerable<DataEntity> GetSensorData(string userId);
    }
}