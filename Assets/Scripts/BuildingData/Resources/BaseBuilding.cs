using UnityEngine;

[CreateAssetMenu(fileName = "BaseBuilding", menuName = "Scriptable Objects/BaseBuilding")]
public class BaseBuilding : ScriptableObject
{

    [SerializeField]
    public Vector3 Cords = Vector3.zero;
    
    [System.Serializable]

    /// <summary>Sets the current state of the structure</summary>
    public enum StructureState
    {
        Blueprint,
        Constructing, 
        Active,
        Damaged, 
        Destroyed,
    }

    public StructureState State;

    public string BuildingName = "Base";
    public int Health = 100;
    public int MaxHealth;

    /// <summary>Stores all sprites of a buildig in a list</summary>
    public Sprite[] Sprite;
}

