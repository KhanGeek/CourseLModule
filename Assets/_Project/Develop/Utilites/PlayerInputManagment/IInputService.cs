namespace _Project.Develop
{
    public interface IInputService
    {
        bool TryGetStream(out string input);
        bool TryGetSelectedGameMode(out GameMode gameMode);
        bool Confirm();
    }
}