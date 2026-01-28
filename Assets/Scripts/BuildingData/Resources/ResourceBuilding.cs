using UnityEngine;

[CreateAssetMenu(fileName = "ResourceBuilding", menuName = "Scriptable Objects/ResourceBuilding")]
public class ResourceBuilding : BaseBuilding
{

    [System.Serializable]

    /// <summary>NOT IMPLEMENTED type of the resource that is stored</summary>
    private enum _ResourceType
    {
        A,B,C,D,F,G
    }
    [SerializeField]
    _ResourceType ResourceType;
    public int MaxCapacity;
    public int ResourceCuantity;
}
