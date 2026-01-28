using UnityEngine;

//Used generics to chanche the type depending on the class
public class BaseBuildingController<T> : MonoBehaviour where T : BaseBuilding

{
    [SerializeField]
    protected T Data;
    protected virtual void Start()
    {
        Debug.Log("BaseInit");
        Data.MaxHealth = Data.Health;
        transform.position = Data.Cords;
    }

    protected virtual void Update()
    {

        if (Data.Health <= 0){OnDestroyed();}

        //Check State Before Runing
        //Do nothing if state is blueprint or is constructing
        
        //if (Data.State == 0) return;
        //if (Data.State == 1) return;


        
    }

    /// <summary>Handles the work of Updating the sprite based on conditions</summary>
    protected virtual void Draw()
    {
        //transform to percentatge
        float healthPercent = (float)Data.Health / Data.MaxHealth;

        
        /*
        // in Blueprint
        if (Data.State == 0)
        {
            Data.Sprite[4]
        }
        else if (healthPercent > 0.66f)
            Data.Sprite[0]; // fine
        else if (healthPercent > 0.33f)
            Data.Sprite[1];  // somewhat destroyed
        else if (healthPercent > 0f)
            Data.Sprite[2];  // hit
        else
            Data.Sprite[3];  // cocked
        */
    
    }
    protected void OnDestroyed()
    {
        //NOT IMPLEMENTED
        Debug.Log("Destroyed: " + gameObject);
        Destroy(gameObject);
    }
    protected virtual void TakeDamage(int dmg)
    {
        Data.Health -= dmg;
    }
}
