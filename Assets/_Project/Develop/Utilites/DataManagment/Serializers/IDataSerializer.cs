namespace _Project.Develop
{
    public interface IDataSerializer
    {
        string Serialize<TData>(TData data);
        TData Deserialize<TData>(string serializedData);
    }
}