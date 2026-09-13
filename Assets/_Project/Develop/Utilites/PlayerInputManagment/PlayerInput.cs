using System;
using UnityEngine;

namespace _Project.Develop
{
    public class PlayerInput: IInputService
    {
        private const KeyCode ConfirmKey = KeyCode.Space;
        
        public bool TryGetStream(out string input)
        {
            input = Input.inputString;

            if (input.Length == 0)
                return false;

            return true;
        }

        public bool TryGetSelectedGameMode(out GameMode gameMode)
        {
            if (TryGetStream(out string input))
            {
                if (int.TryParse(input, out int value) == false || Enum.IsDefined(typeof(GameMode), value) == false)
                {
                    Debug.Log("Некорректный ввод!");
                    gameMode = default(GameMode);
                    return false;
                }
                
                gameMode = (GameMode)value;
                return true;
            }
            
            gameMode = default(GameMode);
            return false;
        }

        public bool Confirm()
        {
            if(Input.GetKeyDown(ConfirmKey))
                return true;
            
            return false;
        }
    }
}