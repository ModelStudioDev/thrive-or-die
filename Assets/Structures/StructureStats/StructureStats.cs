using UnityEngine;

namespace ThriveOrDie.Structures
{
    public class StructureStats
    {
        public int Health;
        public Vector3 OriginPos;
        public int Level;
        public int XP;
        /// <summary>Progress if the building is in construction</summary>
        public float BuildingProgress;
        public StructureState CurrentState;
    }
}