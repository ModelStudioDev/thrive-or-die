using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuilding", menuName = "Scriptable Objects/BaseBuilding")]
public class StructureData : ScriptableObject
{
    public Vector3 Cords = Vector3.zero;
    
    /// <summary>Sets the current state of the structure</summary>
    enum StructureState
    {
        Blueprint,
        Constructing, 
        Active,
        Damaged, 
        Destroyed,
    }
    enum StructureType
    {
        //Does Nothing,default if not indicated
        Base = 0,
        Storage,
        Crafting,
        Defense,
        Walls,
        Decoration,
        Investigation,
        //add more into future development
    }

    public StructureState State;
    public StructureState Type;
    public string BuildingName = "Base";
    public int Health = 100;
    public int Size = 1;
    int MaxLevel;
    
    /// <summary>Used to multiply it to the level to bost stats</summary>
    public float LevelMultiplier = 1.2f;

    /// <summary>Stores all sprites of a buildig in a list</summary>
    public Sprite[] Sprite;
}

