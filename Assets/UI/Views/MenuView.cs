using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : AbstractView
{
    [SerializeField] private Button _mapMenuButton = null;
    [SerializeField] private Button _dictionaryButton = null;
    [SerializeField] private Button _settingsButton = null;
    [SerializeField] public RectTransform _scrollContentRectTransform = null;
    [SerializeField] public ScrollRect scrollRect;

    [SerializeField] public GameObject[] _menuViews = null;

    private /* interface */ MenuData _data = new MenuData();

    public event Action ChangeScrollContentRectTransform;

    public event Action WorldMapButtonClicked;
    public event Action DictionaryButtonClicked;
    public event Action SettingsButtonClicked;

    private void Start()
    {
        ChangeScrollContentRectTransform?.Invoke();
    }

    private void PrepareData()
    {
        base.PrepareData();
    }

    public void WorldMapButton()
    {
        WorldMapButtonClicked?.Invoke();
    }

    public void DictionaryButton()
    {
        DictionaryButtonClicked?.Invoke();
    }
    public void SettingsButton()
    {
        SettingsButtonClicked?.Invoke();
    }
}
