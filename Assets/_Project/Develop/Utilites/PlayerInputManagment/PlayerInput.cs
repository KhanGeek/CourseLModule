using UnityEngine;

namespace _Project.Develop
{
    public class PlayerInput: IInputService
    {
        public bool TryGetStream(out string input)
        {
            input = Input.inputString;

            if (input.Length == 0)
                return false;

            return true;
        }
    }
}