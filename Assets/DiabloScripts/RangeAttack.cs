using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private Animator _animatorEnemyRange;
    [SerializeField] private Transform _ProjectileSpawnPoint;
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerController _playerTarget;
    [SerializeField] private Projectiles _projectile;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private string ATTACKTRIGGERLNAME = "_rangeAttack";
    [SerializeField] private float _distance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float howclose;
    [SerializeField] private float _sphereSpeed;
    [SerializeField] private float _yTargetOffset = 1.25f;
    [SerializeField] private bool canAttack = true;
    private float _delayAttack = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(_player.position, transform.position);
        if (canAttack)
        {
            if (_distance <= howclose)
            {
                StartCoroutine(SpawnProjectileAfterDelay());
            }
        }   
    }
    private IEnumerator SpawnProjectileAfterDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(_delayAttack);
        Projectiles newProjectile = Instantiate(_projectile, _ProjectileSpawnPoint.position, Quaternion.identity);
        newProjectile.GoTowardsTraget(_playerTarget, _yTargetOffset);
        transform.LookAt(_player);
        _animatorEnemyRange.SetTrigger(ATTACKTRIGGERLNAME);
        StartCoroutine(SpawnProjectileAfterDelay());
    }
    public void SetPlayer(PlayerController newPlayer)
    {
        _playerTarget = newPlayer;
    }
}
