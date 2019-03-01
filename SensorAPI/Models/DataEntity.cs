using Microsoft.Azure.Cosmos.Table;

namespace SensorAPI.Models
{
    public class DataEntity : TableEntity
    {
        public DataEntity() { }

        public DataEntity(string userId, string stamp, int distance)
        {
            PartitionKey = userId;
            RowKey = stamp;
            Distance = distance;
        }

        public string UserId => PartitionKey;
        public string Stamp => RowKey;
        public int Distance { get; set; }

        public override string ToString() => $"{UserId} {Stamp} {Distance}";
    }
}