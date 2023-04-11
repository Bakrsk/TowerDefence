using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    public PlayerController _player;
    public static Inventory _inventory;
    public GameObject _gui;
    public int _itemRep;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _inventory = _gui.GetComponent<Inventory>();
            _inventory.AddItem(Items.getArmor(_itemRep));
            Destroy(gameObject);
        }
    }
}
