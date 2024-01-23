using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class PerfomAttackCmd : MonoBehaviour, ICommand
    {
        private CharacterData characterData;
        private CharacterFight characterFight;
        private CharacterData characterAttackedData;
        private CharacterDamage characterAttackedDamage;

        public PerfomAttackCmd(CharacterData characterData, CharacterFight characterFight, CharacterData characterAttackedData, CharacterDamage characterAttackedDamage)
        {
            this.characterData = characterData;
            this.characterFight = characterFight;
            this.characterAttackedData = characterAttackedData;
            this.characterAttackedDamage = characterAttackedDamage;
        }

        public void Execute()
        {
            Debug.Log($"{characterData.characterName}({characterData.characterId}) is attacking to {characterAttackedData.characterName}({characterAttackedData.characterId})");
            if(characterAttackedDamage.currentLife.Value > 0)
            {
                characterAttackedDamage.currentLife.Value -= characterFight.damage;
                characterData.currentHits.Value += 1;

                characterFight.OnCharacterAttack.OnNext(characterData.characterMotion);

                if(characterAttackedDamage.currentLife.Value <= 0)
                    characterAttackedDamage.OnCharacterGameOver
                        .OnNext(true);
            }
        }
    }
}
