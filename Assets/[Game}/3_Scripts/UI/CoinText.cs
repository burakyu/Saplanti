using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    TextMeshProUGUI _coinText;

    private void OnEnable()
    {
        EventManager.CoinCollected.AddListener(UpdateCoinText);
    }

    private void OnDisable()
    {
        EventManager.CoinCollected.RemoveListener(UpdateCoinText);
    }

    private void Start()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        _coinText.text = CoinManager.CoinCount.ToString();
    }
}
