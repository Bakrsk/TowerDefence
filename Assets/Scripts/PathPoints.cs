using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public static Transform[] _pathPoints;
    private void Awake()
    {
        _pathPoints = new Transform[transform.childCount];
        for (int i = 0; i <_pathPoints.Length; i++)
        {
            _pathPoints[i] = transform.GetChild(i);
        }
    }
}
