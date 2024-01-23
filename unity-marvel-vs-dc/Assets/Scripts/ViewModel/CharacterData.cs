using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;
using UniRx;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable/Character Data")]
    public class CharacterData : ScriptableObject
    {
        public string characterId;
        public string characterName;
        public Texture characterImage;
        public IntReactiveProperty currentHits;
        public int recordPoints;
        public CharacterMotion characterMotion;
    }
}
