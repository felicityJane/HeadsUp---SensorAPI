using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using CloudStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount;

namespace SensorAPI.Services
{
    public interface ICloudService
    {
        CloudTable CreateTableAsync(string tableName);
    }
}
