using UnityEngine;
using TMPro;

public class UISeeds : MonoBehaviour
{
    [SerializeField] CurrencyDatabase currencyDatabase = null;
    TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();

        UpdateSeedsText();
    }

    private void Start()
    {
        currencyDatabase.OnSeedsUpdated += UpdateSeedsText;
    }

    private void UpdateSeedsText()
    {
        m_Text.text = currencyDatabase.seeds.ToString();
    }
}
