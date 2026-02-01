using UnityEngine;

namespace ThriveOrDie.Structures
{
    //setters for runtime modification
    public record StructureStats
    {
        public int Health {get; set;}
        public Vector3 Pos {get; set;}
        public int Level {get; set;}
        public int XP {get; set;}
        /// <summary>Progress if the building is in construction</summary>
        public float BuildingProgress {get; set;}
        public StructureState CurrentState {get; set;}
    }
}