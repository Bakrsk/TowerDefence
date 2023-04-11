using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _minDistance = 0.5f;
    [SerializeField] LayerMask _layer;
    private Camera _cam;
    private Vector3 _direction;
    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray ray;
            RaycastHit hit;
            ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f,_layer))
            {
                
                _target = hit.point;
                Debug.Log(_target);
                transform.LookAt(_target);


            }
        }

    }
    void move()
    {
        if ((transform.position - _target).magnitude > _minDistance)
        {
            
            if (_target != Vector3.zero)
            {
                _direction = (_target - transform.position).normalized;
                transform.position += _direction * _speed * Time.deltaTime;

            }
        }
   
        
    }
}
