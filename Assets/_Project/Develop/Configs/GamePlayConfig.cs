using UnityEngine;

namespace _Project.Develop
{
    [CreateAssetMenu(fileName = "GamePlayConfig", menuName = "Configs/GamePlayConfig")]
    public class GamePlayConfig : ScriptableObject
    {
        public char[] DigitsChars;
        public char[] LettersChars;
    }
}