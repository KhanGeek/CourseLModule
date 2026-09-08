namespace _Project.Develop
{
    public class GameProgress
    {
        private string _subsequenceLine;
        private int _inputCount;
        
        public GameProgress(string subsequenceLine)
        {
            _subsequenceLine = subsequenceLine;
        }

        public SequenceElementCheckResult Check(char input)
        {
            if (input != _subsequenceLine[_inputCount])
                return SequenceElementCheckResult.Wrong;

            _inputCount++;

            return _inputCount >= _subsequenceLine.Length
                ? SequenceElementCheckResult.Completed
                : SequenceElementCheckResult.Correct;
        }
    }
}