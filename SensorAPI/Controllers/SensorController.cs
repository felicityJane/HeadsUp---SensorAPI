using System;
using System.Collections.Generic;
using System.Web.Http;
using SensorAPI.Models;
using SensorAPI.Repositories;

namespace SensorAPI.Controllers
{
    public class SensorController : ApiController
    {
        private ISensorRepository _sensorRepository;

        public SensorController(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }
       
        [Route("headsup/sensor/postdata/{userId}/{rowKey}/{distance}")]
        [HttpPost]
        public IHttpActionResult PostData(string userId, string rowKey, int distance)
        {            
            var data = _sensorRepository.InsertSensorData(userId, rowKey, distance);
            try
            {
                data = _sensorRepository.InsertSensorData(userId, rowKey, distance);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json(data);
        }

        [Route("headsup/sensor/getsensordata/{userId}/{rowkey}")]
        [HttpGet]
        public IHttpActionResult GetSensorData(string userId, string rowkey)
        {
            var data = _sensorRepository.GetSensorData(userId, rowkey);
            try
            {
                data = _sensorRepository.GetSensorData(userId, rowkey);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json(data);
        }

        [Route("headsup/sensor/getsensordata/{userId}")]
        [HttpGet]
        public IHttpActionResult GetSensorData(string userId)
        {
            var data = _sensorRepository.GetSensorData(userId);
            try
            {
                data = _sensorRepository.GetSensorData(userId);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json(data);
        }

    }
}