using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Develop
{
    public class GameCycle : IUpdatable
    {
        public event Action<bool> StopGame;
        
        private const bool _winGame = true;
        private const bool _looseGame = false;
        
        private char[] _sourseChars;

        private bool _isRuning;
        
        private IInputService _inputService;

        private GameProgress _progress;

        public GameCycle(char[] sourseChars, IInputService inputService)
        {
            _sourseChars = sourseChars;
            _inputService = inputService;
        }

        public void Prepare()
        {
            Shuffle(_sourseChars);

            string subsequenceLine = default(string);
            
            foreach (char sourseChar in _sourseChars)
                subsequenceLine += sourseChar;
            
            _progress = new GameProgress(subsequenceLine);

            Debug.Log("Повтори последовательность: " + subsequenceLine);
        }

        public void Start()
        {
            _isRuning = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRuning==false)
                return;
            
            if(_inputService.TryGetStream(out string input))
            {
                foreach (char c in input)
                {
                    switch (_progress.Check(c))
                    {
                        case SequenceElementCheckResult.Correct:
                            continue;

                        case SequenceElementCheckResult.Completed:
                            WinGame();
                            return;

                        case SequenceElementCheckResult.Wrong:
                            LooseGame();
                            return;
                    }
                }
            }
        }

        private void LooseGame()
        {
            Debug.Log("Увы, получится в друго раз! Нажми Пробел что бы перезапустить!");
            Stop(_looseGame);
        }

        private void WinGame()
        {
            Debug.Log("Поздравляем с победой! Нажми Пробел для возвращения в главное меню!");
            Stop(_winGame);
        }

        private void Stop(bool isWin)
        {
            _isRuning = false;
            StopGame?.Invoke(isWin);
        }

        private void Shuffle(char[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}