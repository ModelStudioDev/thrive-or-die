using UnityEngine;

[CreateAssetMenu(fileName = "DefensiveBuilding", menuName = "Scriptable Objects/DefensiveBuilding")]
public class DefensiveBuilding : BaseBuilding
{
    /// <summary>World Units of the detection area</summary>
    public float AreaRadius = 10f;
    /// <summary>Coldown for shooting in floating points</summary>
    public float AttackTimer = 2f;
    /// <summary>Damage per bullet</summary>
    public int Damage = 40;
    
    
    /// <summary>Bullet fired per shot</summary>
    public int Burst = 1;
}
