using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;
using ViewModel;
using System;

namespace Components
{
    public class CharacterAnimationDisplay : MonoBehaviour
    {
        public Animator animator;
        public CharacterFight characterData;

        void Start()
        {
            characterData.OnCharacterAttack
                .Subscribe(OnCharacterAttack)
                .AddTo(this);
        }

        private void OnCharacterAttack(CharacterMotion characterMotion)
        {
            animator.SetTrigger(characterMotion.motionName);
        }
    }   
}
