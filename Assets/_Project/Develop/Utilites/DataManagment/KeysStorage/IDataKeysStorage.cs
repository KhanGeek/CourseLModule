namespace _Project.Develop
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}