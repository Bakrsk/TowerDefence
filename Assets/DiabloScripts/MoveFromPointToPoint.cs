using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromPointToPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> _sphereList = new List<Transform>();
    [SerializeField] private Transform _spheretoMove;
    [SerializeField] private int _indexToDestroy;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _minDist = 0.5f;
    //private Transform _currentTarget;

    private int _currentTargetIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = (_sphereList[_currentTargetIndex].position - _spheretoMove.position).normalized;
        _spheretoMove.transform.position += direction * _speed * Time.deltaTime;
        if ((_sphereList[_currentTargetIndex].position - _spheretoMove.position).magnitude < _minDist)
        {
            int count = _sphereList.Count;
            _currentTargetIndex++;
            _currentTargetIndex = _currentTargetIndex % count;
        }




    }

    public void DestroySphereAtIndex()
    {

    }
}
