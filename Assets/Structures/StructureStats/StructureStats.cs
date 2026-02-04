using UnityEngine;

namespace ThriveOrDie.Structures
{
    //setters for runtime modification
    public record StructureStats
    {
        public int health {get; set;}
        public Vector3 originPosition {get; set;}
        public short level {get; set;}
        public StructureState state {get; set;}
    }
}