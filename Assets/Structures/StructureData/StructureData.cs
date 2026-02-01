using UnityEngine;

namespace ThriveOrDie.Structures
{
    [CreateAssetMenu(fileName = "StructureData", menuName = "Scriptable Objects/StructureData")]
    public class StructureData : ScriptableObject
    {
        public Vector3 Cords;
        
        /// <summary>Sets the current state of the structure</summary>
        public StructureType Type;
        public string Name = "Base";
        public int Health = 100;
        public int Size = 1;
        [SerializeField]
        int MaxLevel;
        
        /// <summary>Used to multiply it to the level to bost stats</summary>
        public float LevelMultiplier = 1.2f;

        /// <summary>Stores all sprites of a buildig in a list</summary>
        public Sprite[] Sprite;
    }
}
