using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _Door1;
    [SerializeField] private GameObject _Door2;
    [SerializeField] private GameObject _DoorContainer;
    [SerializeField] private GameObject _Symbol;
    [SerializeField] private GameObject _Symbol1;
    [SerializeField] private GameObject _Symbol2;
    [SerializeField] private GameObject _Symbol3;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _gui;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _attackPosition;
    [SerializeField] LayerMask _layerGround;
    [SerializeField] LayerMask _layerEnemy;
    [SerializeField] LayerMask _layerEnemyRange;
    [SerializeField] private bool _attack;
    [SerializeField] private string ATTACKTRIGGERLNAME = "_attackTri";
    [SerializeField] private string DEATHTRIGGERLNAME = "_DeathTri";
    [SerializeField] private string SPEEDFLOATNAME = "_vitesse";
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _minDistance = 0.5f;
    [SerializeField] private float _attackradius = 2f;
    [SerializeField] private float _animationDelay = 0.25f;
    [SerializeField] private int damage = 5;
    private bool _hasTarget;
    private Transform _currentTarget;
    private RangeAttack _currentRangeEnemy;
    private Camera _cam;
    private Vector3 _direction;
    private Vector3 _target;
    public HealthBar _healthbar;
    public int _maxHealth = 100;
    public int _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _currentHealth = _maxHealth;
        _healthbar.SetMaxHealth(_maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(SPEEDFLOATNAME, _rigidbody.velocity.magnitude / 10);
        move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray;
            RaycastHit hit;
            ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, _layerGround))
            {
                _target = hit.point;
                transform.LookAt(_target);
            }
            
            Ray rayy;
            RaycastHit hitEnemy;
            rayy = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayy, out hitEnemy,1000f,_layerEnemy))
            {
                EnemyHealth currentEnemy = hitEnemy.collider.GetComponent<EnemyHealth>();
                if (currentEnemy != null)
                {
                    _currentTarget = currentEnemy.transform;
                    //_currentTarget.transform.position = hitEnemy.point;
                    transform.LookAt(new Vector3(_currentTarget.transform.position.x, transform.position.y, _currentTarget.transform.position.z));
                    _hasTarget = true;
                    TriggerAttackAnimation();
                }

            }
        }
        if(_hasTarget && _currentTarget != null)
        {
            if (Vector3.Distance(transform.position, _currentTarget.transform.position) < _attackradius)
            {
                TriggerAttackAnimation();
                _hasTarget = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 10f;
        } 
    }
    void move()
    {
        if ((transform.position - _target).magnitude > _minDistance)
        {

            if (_target != Vector3.zero)
            {
                _direction = (_target - transform.position).normalized;

            }
        }
        else
        {
            _direction = Vector3.zero;
        }
        _rigidbody.velocity = _direction * _speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        _target = transform.position;
        if(collision.gameObject.tag == "Symbol")
        {
            _Symbol.SetActive(false);
            _Symbol1.SetActive(true);
            _Symbol2.SetActive(true);
            _Symbol3.SetActive(true);
        }
        if(collision.gameObject.tag == "EscapeDoor")
        {
            Destroy(_Door1.gameObject);
            Destroy(_Door2.gameObject);
            Destroy(_DoorContainer.gameObject);
            _Symbol1.SetActive(false);
            _endScreen.SetActive(true);
            _gui.SetActive(false);
        }
        if(collision.gameObject.tag == "Potion")
        {
            _currentHealth = _maxHealth;
            _healthbar.SetHealth(_currentHealth);
        }
    }
    private void TriggerAttackAnimation()
    {
        EnemyHealth closestenemy = null;
        float minDist = float.MaxValue;
        Collider[] hitColliders = Physics.OverlapSphere(_attackPosition.position, _attackradius);
        foreach (Collider collider in hitColliders)
        {
            EnemyHealth enemy = collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                float distance = (enemy.transform.position - _attackPosition.position).magnitude;
                if ((enemy.transform.position - _attackPosition.position).magnitude < minDist)
                {
                    if (minDist > distance)
                    {
                        closestenemy = enemy;
                        minDist = distance;
                        _animator.SetTrigger(ATTACKTRIGGERLNAME);
                    }
                }
            }
        }
        if(closestenemy !=null )
        {
            StartCoroutine(AttackClosestEnnemy(closestenemy));
        }
    }
    private IEnumerator AttackClosestEnnemy(EnemyHealth closestEnemy)
    {
        yield return new WaitForSeconds(_animationDelay);
        closestEnemy.gameObject.SetActive(false);
        closestEnemy.ReceiveDamage(damage);
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"current health is {_currentHealth} healthbar is {_healthbar.gameObject}");
        _healthbar.SetHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            Debug.Log("Health is 0");
            _animator.SetTrigger(DEATHTRIGGERLNAME);
            _gameOver.SetActive(true);
            StartCoroutine(ReloadSceneAfterDeath());
        }
    }
    private IEnumerator ReloadSceneAfterDeath()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Diablo");
    }
}
