using UnityEngine;

namespace ThriveOrDie.Structures
{
    [CreateAssetMenu(fileName = "StructureData", menuName = "Scriptable Objects/StructureData")]
    public class StructureData : ScriptableObject
    {
        public Vector3 cords;
        
        /// <summary>Sets the current state of the structure</summary>
        public StructureType type;
        public string name;
        //LevelScaler<int> health = new();
        public int size;
        [SerializeField]
        public int maxLevel;
        /// <summary>Stores all sprites of a buildig in a list</summary>
        public Sprite[] sprite;
    }
}
