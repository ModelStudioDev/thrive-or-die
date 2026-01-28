using UnityEngine;

public class ResourceBuildingController : BaseBuildingController<ResourceBuilding>
{

    
    protected override void Start()
    {
        base.Start(); 
    }
    
    protected override void Update()
    {
        base.Update(); 
    }

    protected override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        
        /* Calculates health lost and aplies the same percantage to resources
        Example:
        - Health: 100 → 75 (lost 25 = 25%)
        - Resources: 80 → 60 (lost 20 = 25%)*/
        float healthPercentageLost = (float)dmg / Data.MaxHealth;
        int resourceLoss = Mathf.CeilToInt(Data.MaxCapacity * healthPercentageLost);
        
    }

    private void Gather() { }

    //Ignore it,for later testing
    public int GetResources() { return Data.ResourceCuantity; }
}
