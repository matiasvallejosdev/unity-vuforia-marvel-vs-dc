using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;
using TMPro;
using UnityEngine.UI;
using System;

namespace Components
{
    public class CharacterDataDisplay : MonoBehaviour
    {
        public RawImage characterImage;
        public TextMeshProUGUI hitsLabel;
        public TextMeshProUGUI nextAttackLabel;

        public CharacterData characterData;
        public CharacterFight characterFight;

        void Start()
        {
            characterData.currentHits
                .Subscribe(UpdateHits)
                .AddTo(this);
            
            characterFight.nextAttack
                .Subscribe(UpdateNextAttack)
                .AddTo(this);
            
            characterImage.texture = characterData.characterImage;
        }

        private void UpdateNextAttack(int value)
        {
            if(value <= 0)
            {
                nextAttackLabel.text = "Go!";
                return;
            }
            nextAttackLabel.text = value.ToString();
        }

        void UpdateHits(int hits)
        {
            hitsLabel.text = "Hits: " + hits.ToString();
        }
    }
}
