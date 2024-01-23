using UnityEngine;
using UniRx;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "Damage", menuName = "Scriptable/Character Damage")]
    public class CharacterDamage : ScriptableObject
    {
        public IntReactiveProperty currentLife;
        public int warningLife;
        public int maximumLife;
        public ISubject<CharacterMotion> OnCharacterDefense = new Subject<CharacterMotion>();
        public ISubject<bool> OnCharacterGameOver = new Subject<bool>();
    }
}

