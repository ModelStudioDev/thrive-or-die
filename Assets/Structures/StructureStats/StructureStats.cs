using UnityEngine;

namespace ThriveOrDie.Structures
{
    public record StructureStats
    {
        /// </summary>Current health of the structure <summary>
        public int health;
        /// <summary>Structure current position of origin </summary>
        public Vector3 originPosition;
        
        /// </summary>Current level of the structure <summary>
        public short level;
        /// <summary> Current state of the structure</summary>
        public StructureState state; 
    }
}