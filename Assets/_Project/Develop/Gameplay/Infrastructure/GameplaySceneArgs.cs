namespace _Project.Develop
{
    public class GameplaySceneArgs : IInputSceneArgs
    {
        public GameplaySceneArgs(string sequence)
        {
            Sequence = sequence;
        }

        public string Sequence { get; private set; }
    }
}