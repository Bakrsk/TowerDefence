using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField] private EnemyTwo _enemyToSpawn;
    [SerializeField] private PlayerController _playerTarget;
    [SerializeField] private float _delaySpawn = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyAfterDelay());
    }
    private IEnumerator SpawnEnemyAfterDelay()
    {
        yield return new WaitForSeconds(_delaySpawn);
        EnemyTwo newEnemy = Instantiate(_enemyToSpawn, transform.position, Quaternion.identity);
        newEnemy.SetPlayer(_playerTarget);
        StartCoroutine(SpawnEnemyAfterDelay());
    }

 
}
