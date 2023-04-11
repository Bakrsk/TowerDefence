using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTower : Tower
{
    
    public override void Update()
    {
        Shoot();
        UpdateTarget();
        base.Update();
    }

}
