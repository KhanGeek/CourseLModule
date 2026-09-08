namespace _Project.Develop
{
    public class GameplaySceneArgs : IInputSceneArgs
    {
        public GameplaySceneArgs(char[] chars)
        {
            Chars = chars;
        }

        public char[] Chars { get; private set; }
    }
}