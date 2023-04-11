using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string _enemyTag = "Enemy";
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _range = 15f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;
    [Header ("Attributes")]
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _fireCountDown = 0f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    public void UpdateTarget() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies) 
        { 
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance<=_range) 
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    public virtual void Update()
    {
        if(_target == null) return;

        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation,lookRotation,Time.deltaTime * _speed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if(_fireCountDown<= 0f)
        {
            Shoot();
            _fireCountDown = 1f / _fireRate;
        }

        _fireCountDown -= Time.deltaTime;

    }
    public void Shoot()
    {
       GameObject bulletGo = (GameObject)Instantiate(_bullet,_firePoint.position,_firePoint.rotation);
       Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet != null )
        {
            bullet.Seek(_target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);    
    }

}
