using UnityEngine;

namespace ThriveOrDie.Structures
{
    [CreateAssetMenu(fileName = "Structure", menuName = "ThriveOrDie/Structure")]
    public class StructureData : ScriptableObject
    {
        /// <summary>Sets the current state of the structure</summary>
        public StructureType type;
        public string name;
        //not implemented
        //LevelScaler<int> health = new();
        public int size;
        [SerializeField]
        public int maxLevel;
        /// <summary>Stores all sprites of a buildig in a list</summary>
        public Sprite[] sprite;
        /*99% this is not your intended implementation,also i dont know what you mean making
        it variable per level,could collision with other structure when lvl'ing up */
        //can't initialize to size in an so
        public bool[][] footprint;

    }
}
    