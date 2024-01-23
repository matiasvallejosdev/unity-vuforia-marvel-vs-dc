using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;

namespace Components
{
    public class Character : MonoBehaviour, ICharacter, IDamage, IFight
    {
        [SerializeField] private CharacterData _characterData;
        public CharacterData characterData { get; set; }
        public CharacterState characterState { get; set; }

        [SerializeField] private CharacterFight _fightSystem;
        public CharacterFight figthSystem { get; set; }

        [SerializeField] private CharacterDamage _damageSystem;
        public CharacterDamage damageSystem { get; set; }

        void Awake()
        {
            this.characterData = _characterData;
            this.figthSystem = _fightSystem;
            this.damageSystem = _damageSystem;
            
            characterData.currentHits.Value = 0;
            damageSystem.currentLife.Value = damageSystem.maximumLife;
            characterState = CharacterState.Game;

            damageSystem.OnCharacterGameOver
                .Subscribe(OnCharacterGameOver)
                .AddTo(this);
        }

        private void OnCharacterGameOver(bool isGameOver)
        {
            characterState = CharacterState.GameOver;
        }

        public Vector3 GetCharacterPosition()
        {
            return this.gameObject.transform.position;
        }

        public bool GetAttackState()
        {
            if(characterState == CharacterState.Game)
                return true;
            
            return false;
        }
    }

    public enum CharacterState
    {
        Game,
        Pause,
        GameOver
    }
}
