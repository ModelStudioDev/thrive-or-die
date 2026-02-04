using UnityEngine;

namespace ThriveOrDie.Structures
{
    //setters for runtime modification
    public record StructureStats
    {
        public int health;
        public Vector3 originPosition;
        public short level;
        public StructureState state; 
    }
}