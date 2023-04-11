using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    [SerializeField] private Animator _animatorEnemy;
    [SerializeField] private PlayerController _currentPlayer;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private string ATTACKTRIGGERLNAME = "_attackTri";
    private void Update()
    {
        AttackOrChase();
    }
    private void AttackOrChase()
    {
        if (Vector3.Distance(transform.position, _currentPlayer.transform.position) < _range)
        {
            _animatorEnemy.SetTrigger(ATTACKTRIGGERLNAME);
        }
        else
        {
            chase();
        }
    }
    private void chase()
    {
        transform.LookAt(_currentPlayer.transform.position);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
    public void SetPlayer(PlayerController newPlayer)
    {
        _currentPlayer = newPlayer;
    }
    public void PlayerTakeDamage()
    {
        _currentPlayer.TakeDamage(5);
    }
}

