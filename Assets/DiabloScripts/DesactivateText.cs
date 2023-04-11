using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DesactivateText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public void DesactivateQuote()
    {
        StartCoroutine(DesactivateTextAfterDelay());
    }
    private IEnumerator DesactivateTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        _text.gameObject.SetActive(false);
    }
}
