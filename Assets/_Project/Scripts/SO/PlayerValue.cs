using UnityEngine;

namespace _Project.Scripts.SO
{
    [CreateAssetMenu(fileName = "PlayerValue",menuName = "PlayerValue")]
    public class PlayerValue : ScriptableObject
    {
        [property:SerializeField] public int Value;

        public void AddValue(int value) => Value += value;
    }
}
