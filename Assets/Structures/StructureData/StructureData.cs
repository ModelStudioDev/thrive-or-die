using UnityEngine;
using ThriveOrDie.Utils;
namespace ThriveOrDie.Structures
{
    [CreateAssetMenu(fileName = "Structure", menuName = "ThriveOrDie/Structure")]
    public class StructureData : ScriptableObject
    {
        /// <summary>Specific type of the structure</summary>
        public StructureType type;
        public string name;
        LevelScaler health = new();
        public int size;
        public int maxLevel;
        public bool[][] footprint;

    }
}
    