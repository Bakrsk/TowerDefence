using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SecondEnemy _enemyTwo;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Knight")
        {
            GameManager._instance.TakeDamage(5);
            _enemy.gameObject.SetActive(false);
        }
       if (other.gameObject.tag == "Soul")
        {
            GameManager._instance.TakeDamage(5);
            _enemyTwo.gameObject.SetActive(false);
        }
    }
}
