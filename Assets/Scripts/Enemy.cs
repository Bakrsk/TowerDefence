using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float _speed = 5f;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _enemyAnimator;
   // private string _SPEEDFLOATNAME = "_vitesse";
   
    public virtual void Move(Vector3 position)
    {
        _agent.speed = _speed;
        _agent.SetDestination(position);
        //_enemyAnimator.SetFloat(_SPEEDFLOATNAME, 5f);
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndZone")
        {
            GameManager._instance.TakeDamage(5);
            Destroy(gameObject);
        }
    }
}
