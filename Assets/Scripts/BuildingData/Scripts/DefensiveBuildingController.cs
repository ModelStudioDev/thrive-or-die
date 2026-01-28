using UnityEngine;
using System.Collections.Generic;

public class DefensiveBuildingController : BaseBuildingController<DefensiveBuilding>
{
    private float _baseTimer;
    // Using gameobject type,chanche later to specific type
    List<GameObject> AvailableTargets = new List<GameObject>();
    protected override void Start()
    {
        base.Start();
        _baseTimer =  Data.AttackTimer;
        transform.position = Data.Cords;
    }
    /// <summary>Trigered when the time is 0</summary>
    void Attack()
    {

        GetTargets();
        if (AvailableTargets == null || AvailableTargets.Count == 0)
        {
            Debug.Log("No targets available!");
        }
        else
        {
            foreach (GameObject enemy in AvailableTargets)
            {
                Debug.Log(enemy.name);
            }
            AvailableTargets.Clear();
        }
       
    }
    //make sure to clear the list before calling the function for a repeated time
    void GetTargets()
    {      
        // Not necessary yet  
        /* ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(layerMask);
        filter.useTriggers = useTriggers;*/

        //Planing to create a gizmos area on another func to debug (=
        Collider2D[] Hits = Physics2D.OverlapCircleAll(Data.Cords, Data.AreaRadius);

        foreach (Collider2D Coll in Hits)
        {
            if (Coll != null && Coll.gameObject.CompareTag("Enemy"))
            {
                AvailableTargets.Add(Coll.gameObject);
            }
        }     
    }
    protected override void Update()
    {
        base.Update();
        if (_baseTimer > 0f)
        {
            _baseTimer -= Time.deltaTime;
            if (_baseTimer < 0f) _baseTimer = 0f; // limit negative
        }
        if(_baseTimer == 0f)
        {
            Attack();
            _baseTimer = Data.AttackTimer;
        }
        
    }

    protected override void Draw()
    {
        base.Update();
        //NOT IMPLEMENTED
    }
}
