using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using ViewModel;
using TMPro;
using UnityEngine.UI;

namespace Components
{
    public class CharacterHealthDisplay : MonoBehaviour
    {
        public TextMeshProUGUI lifeLabel;
        public Slider healthBar;
        public CharacterDamage characterDamage;

        void Awake()
        {
            healthBar.maxValue = characterDamage.maximumLife;
        }
        
        void Start()
        {
            characterDamage.currentLife
                .Subscribe(UpdateHealth)
                .AddTo(this);
        }

        void UpdateHealth(int health)
        {
            if(health <= 0)
            {
                lifeLabel.text = "Game over";
                healthBar.value = 0;
                return;
            }

            lifeLabel.text = "Life: " + health.ToString();
            healthBar.value = health;
        }
    }
}
