using UnityEngine;

public class StructureStats
{
    public int Level;
    public int Health;
    public Vector3 OriginPos;
    //Progression
    public int Level;

    //This variable could be changed depending if the level progresion
    //does not have in between progress 
    public int XP;

    /// <summary>Progress if the building is in construction</summary>
    public float BuildingProgress;

    //public StructureState CurrentState;


    //Not Sure if the class should run logic
    void UpdateStateByLevel(){    
        throw new NotImplementedException();
    }
    
}
