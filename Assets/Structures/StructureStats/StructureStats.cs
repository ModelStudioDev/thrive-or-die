using UnityEngine;

namespace ThriveOrDie.Structures
{
    //setters for runtime modification
    public record StructureStats
    {
        public int Health {get; set;}
        public Vector3 Pos {get; set;}
        public short Level {get; set;}
        public StructureState State {get; set;}
    }
}