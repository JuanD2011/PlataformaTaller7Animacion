using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILogInInvalid : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI = null;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        LogInManager.OnLoggedIn += ShowInvalidLogInProcess;
    }

    private void ShowInvalidLogInProcess(bool _LoggedIn)
    {
        if (_LoggedIn) return;

        textMeshProUGUI.text = "Código inválido";
    }
}
