using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private SecondEnemy _secondEnemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _secondSpawnPoint;
    [SerializeField] private float _countdown = 2f;
    [SerializeField] private float _timeBetweenSpawns = 5f;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _currentLife;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private TextMeshProUGUI _waveTimer;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private AudioSource _deathAudio;

    private int _waveIndex = 0;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Start()
    {
        _currentLife = _maxHealth;
    }
    public void TakeDamage(int damage)
        {
            _currentLife-= damage;
            _healthBar.SetHealth((int)((float)_currentLife/(float)_maxHealth * 100));
        }
    private void Update()
    {
        if(_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenSpawns;
        }
        _countdown -= Time.deltaTime;
        _waveTimer.text = Mathf.Round(_countdown).ToString();
        GameOver();
    }
    private IEnumerator SpawnWave()
    {
        _waveIndex++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void SpawnEnemy()
    {
       Enemy newenemy = Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
       SecondEnemy enemytwo = Instantiate(_secondEnemyPrefab, _secondSpawnPoint.position, _spawnPoint.rotation);
        newenemy.Move(_endPoint.position);
        enemytwo.Move(_endPoint.position);
    }
    private void GameOver()
    {
        if(_currentLife == 0f)
        {
            //Time.timeScale = 0f;
            _gameOver.SetActive(true);
            _deathAudio.Play();
        }
    }
}

