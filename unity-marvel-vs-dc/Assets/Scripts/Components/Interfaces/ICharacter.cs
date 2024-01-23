using UnityEngine;
using ViewModel;

namespace Components
{
    public interface ICharacter
    {
        public CharacterData characterData { get; set; }
        public CharacterState characterState {get; set;}


        public Vector3 GetCharacterPosition();
        public bool GetAttackState(); 
    }
}

