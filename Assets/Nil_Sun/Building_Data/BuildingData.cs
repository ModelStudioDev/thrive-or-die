using UnityEngine;

public abstract class BuildingData : MonoBehaviour
{

    [System.Serializable]
    protected struct Coordinates
    {
        [SerializeField] private int x;
        [SerializeField] private int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X => x;
        public int Y => y;
    }

    [System.Serializable]
    protected enum StructureState
    {
        Blueprint, // Not placed, but selected
        Constructing, // Timer for its construction time
        Active, // Whether it's active
        Damaged, // Whether it's damaged 
        Destroyed, // Whether it's destroyed
    }

    [System.Serializable]
    protected enum StructureType
    {
        House, // Will store npc's / player's settlers
        Tower, // Those meant to defend or attack
        Bank, // Those meant to store materials (money, resources, food...)
        Wall, // Those meant to block
        Farm, // Those ment to yield resources
        NoValue, // 
    }

    [SerializeField] private BoxCollider2D structureCollider;
    [SerializeField] private SpriteRenderer structureSprite;

    [SerializeField] protected Coordinates structureCoordinates;
    [SerializeField] protected StructureState structureState;
    [SerializeField] protected StructureType structureType;
    [SerializeField] protected Vector2Int structureSize;

    [SerializeField] protected float structureMaxHealth;
    [SerializeField] protected float structureCurrentHealth;

    protected virtual void Awake()
    {
        if (structureCollider == null) Debug.Log("Enlighted child, put the damn collider to the structure");
        if (structureSprite == null) Debug.Log("Enlighted child, put the damn sprite to the structure");
        // In order to keep the code maintainable, we'll have the collider in the parent and the sprite or other stuff
        // of the structure in a child. For the love of God, dont mash everything in the parent.
        // Drag the component to the serialized field in the inspector
    }


}
