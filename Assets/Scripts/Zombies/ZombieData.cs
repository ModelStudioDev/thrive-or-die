using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
  /// <summary>
  /// The distance at wich a given zombie can spot humans
  /// </summary>
  public float spottingRange;
  /// <summary>
  /// The atack speed of a given zombie
  /// </summary>
  public float atackSpeed;
  /// <summary>
  /// The damage per hit value
  /// </summary>
  public float atackDamage;
  /// <summary>
  /// The resistence of a given zombie to atacks aimed at him
  /// </summary>
  public float atackResistence;
  /// <summary>
  /// The max health of a zombie
  /// </summary>
  public float maxHealth;
  /// <summary>
  /// The zombie speed
  /// </summary>
  public float speed;

}
