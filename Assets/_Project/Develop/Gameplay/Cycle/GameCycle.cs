using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Develop
{
    public class GameCycle : IUpdatable
    {
        private const bool _winGame = true;
        private const bool _looseGame = false;
        
        private string _sourseSequence;

        private bool _isRuning;
        
        private IInputService _inputService;
        private GameProgress _progress;
        private StopGameplay _stopGameplay;

        public GameCycle(string sourseSequence, IInputService inputService, StopGameplay stopGameplay)
        {
            _sourseSequence = sourseSequence;
            _inputService = inputService;
            _stopGameplay = stopGameplay;
        }

        public void Prepare()
        {
            _sourseSequence = Shuffle(_sourseSequence);
            
            _progress = new GameProgress(_sourseSequence);

            Debug.Log("Повтори последовательность: " + _sourseSequence);
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
            _stopGameplay.Start(isWin);
        }

        private string Shuffle(string input)
        {
            char[] array = input.ToCharArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }

            string result = default(string);

            foreach (char c in array)
            {
                result += c;
            }

            return result;
        }
    }
}