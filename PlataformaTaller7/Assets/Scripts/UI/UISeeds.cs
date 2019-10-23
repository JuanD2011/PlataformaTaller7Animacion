using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISeeds : MonoBehaviour
{
    CurrencyDatabase currencyDataBase = null;
    TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        currencyDataBase = Resources.Load<CurrencyDatabase>("Scriptable Objects/Currency Database");
        m_Text = GetComponent<TextMeshProUGUI>();

        UpdateSeedsText();
    }

    private void Start()
    {
        currencyDataBase.OnSeedsUpdated += UpdateSeedsText;
    }

    private void UpdateSeedsText()
    {
        m_Text.text = currencyDataBase.seeds.ToString();
    }
}
