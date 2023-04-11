using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffset;
    private BuildManager _buildManager;
    private Renderer _renderer;
    private Color _startColor;
    private GameObject _tower;

    private void Start()
    {
        _buildManager = BuildManager._instance;
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }
    private void OnMouseEnter()
    {
        if (_buildManager.GetTowerToBuild() == null) return;
        _renderer.material.color = _hoverColor;
    }
    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
    private void OnMouseDown()
    {
        if (_buildManager.GetTowerToBuild() == null) return;
        
        if(_tower != null )
        {
            Debug.Log("Can't build there!!!! ");
            return;
        }

        GameObject towerToBuild = _buildManager.GetTowerToBuild();
        _tower= (GameObject)Instantiate(towerToBuild,transform.position + _positionOffset,transform.rotation);
    }
}
