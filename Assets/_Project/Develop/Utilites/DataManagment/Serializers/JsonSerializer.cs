using Newtonsoft.Json;

namespace _Project.Develop
{
    public class JsonSerializer : IDataSerializer
    {
        public string Serialize<TData>(TData data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public TData Deserialize<TData>(string serializedData)
        {
            return JsonConvert.DeserializeObject<TData>(serializedData);
        }
    }
}