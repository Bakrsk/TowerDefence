using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameObject _impactEffect;
    [SerializeField] float _speed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( _target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    public void Seek (Transform target)
    {
        _target = target;
    }
    void HitTarget ()
    {
      GameObject effectInstance =(GameObject)Instantiate(_impactEffect, transform.position,transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
        
    }
}
