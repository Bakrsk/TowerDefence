using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackradius = 2f;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            Attack();
        }
    }
    private void Attack()
    {
        EnemyTwo closestenemy = null;
        float minDist = float.MaxValue;
        Collider[] hitColliders = Physics.OverlapSphere(_attackPosition.position, _attackradius);
        foreach (Collider collider in hitColliders)
        {
            EnemyTwo enemy = collider.GetComponent<EnemyTwo>();
            if (enemy != null)
            {
                float distance = (enemy.transform.position - _attackPosition.position).magnitude;
                if ((enemy.transform.position - _attackPosition.position).magnitude < minDist)
                {
                    if(minDist > distance)
                    {
                        closestenemy = enemy;
                        minDist = distance;
                    } 
                }
            }
        } 
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPosition.position, _attackradius);
    }
}
