using UnityEngine;


//Structs on global scope
    public enum StructureState
    {
        Blueprint,
        Constructing, 
        Active,
        Damaged, 
        Destroyed,
    }
    public enum StructureType
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

[CreateAssetMenu(fileName = "StructureData", menuName = "Scriptable Objects/StructureData")]
public class StructureData : ScriptableObject
{
    //Not sure if it should hold stats class
    public StructureStats Stats;
    public Vector3 Cords = Vector3.zero;
    
    /// <summary>Sets the current state of the structure</summary>
    public StructureState State;
    public StructureType Type;
    public string BuildingName = "Base";
    public int Health = 100;
    public int Size = 1;
    [SerializeField]
    int MaxLevel;
    
    /// <summary>Used to multiply it to the level to bost stats</summary>
    public float LevelMultiplier = 1.2f;

    /// <summary>Stores all sprites of a buildig in a list</summary>
    public Sprite[] Sprite;
}

