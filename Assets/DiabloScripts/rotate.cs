using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private Transform _radarOrigin;
    [SerializeField] private TextMeshProUGUI _text;
    private bool _Check;
    private bool _previousCheck;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origine = _radarOrigin.position;
        Vector3 direction = _radarOrigin.forward;
        Ray ray = new Ray(origine, direction);
        RaycastHit hit;

        transform.Rotate(new Vector3(0, _speed * Time.deltaTime, 0));
        
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            Debug.DrawRay(origine, direction * hit.distance, Color.red);
            _Check = true;
            float distance = hit.distance;
            Vector3 hitposition = hit.point;
            string name = hit.collider.gameObject.name;
            Vector3 pos = hit.collider.transform.position;
            _text.text = $"Nom: {name} Distance: {Mathf.Round(distance  * 100 )/100} HitPos: {hitposition} Position {pos}";
        }
        else
        {
            _Check = false;
        }
        if(_Check != _previousCheck)
        {

        }
        _previousCheck = _Check;

         

    }
}
