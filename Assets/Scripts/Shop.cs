using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
   private BuildManager _buildManager;

    private void Start()

    {
        _buildManager = BuildManager._instance;
    }
    public void PurchaseStandardTower()
    {
        Debug.Log("Standard Tower Selected");
        _buildManager.SetTowerToBuild(_buildManager._standardTowerPrefab);
    }
    public void PurchasedAnotherTower()
    {
        Debug.Log("Another Tower Selected");
        _buildManager.SetTowerToBuild(_buildManager._anotherTowerPrefab);
    }
}
