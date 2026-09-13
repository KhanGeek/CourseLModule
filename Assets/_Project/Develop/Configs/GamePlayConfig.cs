using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop
{
    [CreateAssetMenu(fileName = "GamePlayConfig", menuName = "Configs/GamePlayConfig")]
    public class GamePlayConfig : ScriptableObject
    {
        [SerializeField] private List<ConfigField> SequncesConfig = new();
        
        private Dictionary<GameMode, string> _sequences = new();
        
        public IReadOnlyDictionary<GameMode, string> Sequences => _sequences;

        private void OnValidate()
        {
            foreach (ConfigField seqence in SequncesConfig)
                _sequences[seqence.GameMode] = seqence.Sequence;
        }
    }
}