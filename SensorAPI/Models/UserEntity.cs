using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Documents;

namespace SensorAPI.Models
{
    public class UserEntity : TableEntity
    {
        public UserEntity() { }

        public UserEntity(string userId, string name, string info)
        {
            PartitionKey = userId;
            RowKey = name;
            Info = info;
        }

        public string UserId => PartitionKey;
        public string Name => RowKey;
        public string Info { get; set; }

        public override string ToString() => $"{UserId} {Name} {Info}";
    }
}