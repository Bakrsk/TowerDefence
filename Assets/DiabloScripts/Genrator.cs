using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Genrator : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionList = new List<Transform>();
    [SerializeField] private EnemyTwo _MeleeEnemy;
    [SerializeField] private RangeAttack _RangeEnemy;
    [SerializeField] private PlayerController _playerTarget;
    [SerializeField] private RingEffect _escapeRing;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _Symbol;
    private List<int> _indexList = new List<int>();
    void Start()
    {
        for (int i = 0; i < _positionList.Count; i++)
        {
            _indexList.Add(i);
        }
        int ringForEscape = Random.Range(0, _indexList.Count);
        RingEffect newRing = Instantiate(_escapeRing, _positionList[_indexList[ringForEscape]].position, Quaternion.identity);
        newRing.SetText(_text);
        newRing.SetSymbol(_Symbol);
        _indexList.Remove(_indexList[ringForEscape]);
        int RangeEnemy = Random.Range(0, _indexList.Count);
        RangeAttack newRangeEnemy = Instantiate(_RangeEnemy, _positionList[_indexList[RangeEnemy]].position, Quaternion.identity);
        newRangeEnemy.SetPlayer(_playerTarget);
        _indexList.Remove(_indexList[RangeEnemy]);
        for (int i = 0; i < _indexList.Count; i++)
        {
            EnemyTwo newEnemy = Instantiate(_MeleeEnemy, _positionList[_indexList[i]].position, Quaternion.identity);
            newEnemy.SetPlayer(_playerTarget);
        }
    }
}
