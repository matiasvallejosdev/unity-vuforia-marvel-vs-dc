using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    [CreateAssetMenu(fileName = "GameCommandFactory", menuName = "Scriptable/Command Factory/Game Command Factory")]
    public class GameFactoryCmd : ScriptableObject
    {
        public PerfomAttackCmd PerfomAttack(CharacterData characterData, CharacterFight characterFight, CharacterData characterAttackedData, CharacterDamage characterAttackedDamage)
        {
            return new PerfomAttackCmd(characterData, characterFight, characterAttackedData, characterAttackedDamage);
        }
        /*
        public PlayTurnCmd PlayTurn(PlayerCharacter player1, PlayerCharacter player2, GameData gameData)
        {
            return new PlayTurnCmd(player1, player2, gameData);
        }
        */
    }
}

