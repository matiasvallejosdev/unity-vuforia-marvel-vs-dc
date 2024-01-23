using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace Components
{
    public class CharacterInformationDisplay : MonoBehaviour
    {
        public CharacterData characterData;
        public CharacterFight characterFight;
        public CharacterDamage characterDamage;

        [Header("UI")]
        public RawImage imageCharacter;
        public TextMeshProUGUI nameLabel;
        public Slider lifeBar;
        public Slider timeAttack;
        public Slider distanceAttack;
        public Slider damageAttack;

        void Start()
        {
            Show(characterData, characterDamage, characterFight);
        }

        public void Show(CharacterData characterData, CharacterDamage characterDamage, CharacterFight characterFight)
        {
            imageCharacter.texture = characterData.characterImage;
            nameLabel.text = characterData.characterName;

            lifeBar.value = characterDamage.maximumLife;

            damageAttack.value = characterFight.damage;
            distanceAttack.value = characterFight.distanceAttack; // change
            timeAttack.value = characterFight.rate;
        } 
    }
}
