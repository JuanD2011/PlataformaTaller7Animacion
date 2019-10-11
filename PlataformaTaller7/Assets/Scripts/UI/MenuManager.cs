﻿using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] panels = new GameObject[0];

    [SerializeField]
    private Settings settings = null;

    protected Animator[] panelAnimators = new Animator[0];

    private int currentPanelIndex = 0;

    private readonly string panelFadeIn = "MP Fade-in";
    private readonly string panelFadeOut = "MP Fade-out";
    private readonly string panelFadeInStart = "MP Fade-in Start";

    private readonly string panelModalIn = "MP Modal In";
    private readonly string panelModalOut = "MP Modal Out";

    protected virtual void Awake()
    {
        Memento.LoadData(settings);

        InitializePanelAnimators();
    }

    protected virtual void Start()
    {
        panelAnimators[currentPanelIndex].Play(panelFadeInStart);
    }

    protected void InitializePanelAnimators()
    {
        panelAnimators = new Animator[panels.Length];
        for (int i = 0; i < panelAnimators.Length; i++) panelAnimators[i] = panels[i].GetComponent<Animator>();
    }

    /// <summary>
    /// Fade out the current panel and fade in the panel provided by _newPanelIndex
    /// </summary>
    /// <param name="_newPanelIndex"></param>
    public void PanelAnim(int _newPanelIndex)
    {
        if (_newPanelIndex != currentPanelIndex)
        {
            panelAnimators[currentPanelIndex].Play(panelFadeOut);
            currentPanelIndex = _newPanelIndex;
            panelAnimators[currentPanelIndex].Play(panelFadeIn);
        }
    }

    /// <summary>
    /// Set current panel animation depending on the bool
    /// </summary>
    /// <param name="_IsOn"></param>
    public void ModalAnim(bool _IsOn)
    {
        if (_IsOn == true)
        {
            panelAnimators[currentPanelIndex].Play(panelModalOut);
        }
        else
        {
            panelAnimators[currentPanelIndex].Play(panelModalIn);
        }
    }

    /// <summary>
    /// Save settings
    /// </summary>
    public void SaveSettings()
    {
        Memento.SaveData(settings);
    }

    private void OnApplicationQuit()
    {
        if (settings == null) return;

        Memento.SaveData(settings);
    }
}
