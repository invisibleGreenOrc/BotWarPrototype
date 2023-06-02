using CodeBase.Enemies;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "PlayerTypeData", menuName = "Static Data/Player Type Data")]
    public class PlayerTypeStaticData : ScriptableObject
    {
        public PlayerTypeMaterial[] PlayerTypeMaterials;
    }
}
