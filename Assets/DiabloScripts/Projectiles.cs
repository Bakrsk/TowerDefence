using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigid;
    [SerializeField] private float _speed = 5f;
    private PlayerController _player;
    public void GoTowardsTraget(PlayerController player, float offset)
    {
        _rigid.velocity = (player.transform.position + new Vector3(0,offset,0) - transform.position).normalized * _speed;
        _player = player;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Destroy(gameObject);
            _player.TakeDamage(10);
        }
    }
}
