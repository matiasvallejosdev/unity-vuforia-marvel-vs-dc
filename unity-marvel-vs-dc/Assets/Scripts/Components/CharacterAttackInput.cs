using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using UniRx;
using Commands;
using System;

namespace Components
{
    public class CharacterAttackInput : MonoBehaviour
    {
        public GameFactoryCmd gameFactoryCmd; 
        public Character character;
        public Transform pointAttack;

        private float _nextFire = 0f;

        void OnRaycastEnter(GameObject collider)
        {
            // Attack
            ICharacter characterCollision = collider.gameObject.GetComponent<ICharacter>();
            IDamage damagableCollision = collider.gameObject.GetComponent<IDamage>();

            if(damagableCollision != null & characterCollision != null & character.GetAttackState())
            {
                Attack(characterCollision, damagableCollision);
            }
            else 
            {
                Debug.Log("Trigger enter but doesn't have damagable");
            }
        }

        private void Attack(ICharacter characterCollision, IDamage damagableCollision)
        {
            if(_nextFire > 0 || characterCollision.characterData.characterId == character.characterData.characterId)
                return;
                         
            Debug.Log($"Trigger enter in damagable ({characterCollision.characterData.characterName} with position {character.GetCharacterPosition()})");
            gameFactoryCmd.PerfomAttack(character.characterData, character.figthSystem, characterCollision.characterData, damagableCollision.damageSystem).Execute();
            _nextFire = character.figthSystem.rate;
        }

        void Update()
        {
            _nextFire -= Time.deltaTime;
            character.figthSystem.nextAttack.Value = (Int32)Math.Round(_nextFire);

            RaycastHit hit;
            if(Physics.Raycast(pointAttack.position, pointAttack.forward, out hit, character.figthSystem.distanceAttack) && _nextFire <= 0)
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.DrawLine(pointAttack.position, hit.transform.position, Color.green, 0.1f);
                OnRaycastEnter(hit.collider.gameObject);
            }
        }
    }
}
