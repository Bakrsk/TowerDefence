using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    private bool _isDead;
    // Start is called before the first frame update
    public void ReceiveDamage(int damage)
    {
        Debug.Log($" {name}Received {damage} damage");
    }
    public bool isDead()
    {
        return _isDead;
    }
}
