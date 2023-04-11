using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;
    private GameObject _towerToBuild;
    [SerializeField] public GameObject _standardTowerPrefab;
    [SerializeField] public GameObject _anotherTowerPrefab;



    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }
    public void SetTowerToBuild(GameObject tower)
    {
        _towerToBuild = tower;
    }

    
}
