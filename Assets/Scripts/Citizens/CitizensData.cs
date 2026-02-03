using UnityEngine;

[CreateAssetMenu(fileName = "CitizensData", menuName = "Scriptable Objects/CitizensData")]
public class CitizensData : ScriptableObject
{
  /// <summary>
  /// The range which it can spott enemies
  /// </summary>
  public float spottingRange;
  /// <summary>
  /// The attack speed
  /// </summary>
  public float attackSpeed;
  /// <summary>
  /// The attack damage
  /// </summary>
  public float attackdamage;
  /// <summary>
  /// The attack resistence
  /// </summary>
  public float attackResistence;
  /// <summary>
  /// Its max health
  /// </summary>
  public float maxHealth;
  /// <summary>
  /// Its speed
  /// </summary>
  public float speed;
  /// <summary>
  /// The percentage of infection
  /// </summary>
  public float infectionPercentage;
  /// <summary>
  /// The change of reproducing
  /// </summary>
  public float reproductionChance;
    
}
