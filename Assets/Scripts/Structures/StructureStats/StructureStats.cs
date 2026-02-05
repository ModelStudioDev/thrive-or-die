using UnityEngine;

namespace ThriveOrDie.Structures
{
  public record StructureStats
  {
    #region Data

    public StructureData structureData;
    /// </summary>Current health of the structure <summary>
    public int health;
    /// <summary>Structure current position of origin </summary>
    public Vector2Int originPosition;

    /// </summary>Current level of the structure <summary>
    public short level;
    /// <summary> Current state of the structure</summary>
    public StructureState state;
    #endregion


    #region Constructors
    public StructureStats(Vector2Int position, StructureData structureData)
    {
      #region Default constrcutor
      health = (int)structureData.health.GetValue();
      originPosition = position;
      level = 1;
      state = StructureState.InConstruction;
      this.structureData = structureData;
      #endregion
    }
    #endregion
  }
}
