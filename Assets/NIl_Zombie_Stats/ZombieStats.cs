using System.Numerics;

[CreateAssetMenu(fileName = "ZombieStats", menuName = "Scriptable Objects/ZombieStats")]
public class ZombieStats : ScriptableObject
{
    [SerializeField] private string prefabName;

    [SerializeField] private int numberOfPrefabsToCreate;
    [SerializeField] private Vector2[] spawnPoints;


    enum ZombieType
    {
        regular,
        crawler, // Un nugget amb braços
        agressive,
        spitZombie,
        tank,
        // M'he inventat els tipus
    }


    enum ZombieLevel
    {
        lvl_1,
        lvl_2,
        lvl_3,
        lvl_4,
        lvl_5,
    }

    [SerializeField] private ZombieType type;
    private ZombieLevel level;

    [SerializeField] private float maxHealth;
    [SerializeField] private float strength;
    [SerializeField] private float speed;



}
