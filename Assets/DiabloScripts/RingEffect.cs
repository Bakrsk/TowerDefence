using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _Symbol;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _text.text = "Now you have to accomplish the remaining puzzle.";
            _text.GetComponent<DesactivateText>().DesactivateQuote();
            _Symbol.SetActive(true);
            Destroy(gameObject);
        }
    }
    public void SetText(TextMeshProUGUI newText)
    {
        _text = newText;
    }
    public void SetSymbol(GameObject newSymbol)
    {
        _Symbol = newSymbol;
    }
}

