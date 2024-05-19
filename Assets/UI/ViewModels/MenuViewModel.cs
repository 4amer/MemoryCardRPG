using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuViewModel : AbstractViewModel
{
    private MenuModel _model = null;
    private MenuView _view = null;

    private MenuData _data = null;

    public RectTransform scrollContentRectTransform = null;
    public ScrollRect scrollRect = null;

    public GameObject[] _menuViews = null;

    [Inject]
    public void Construct(MenuView view, MenuModel model)
    {
        _view = view;
        _view.ChangeScrollContentRectTransform += ChangeSizeOfScrollContent;
        _view.WorldMapButtonClicked += ScrollToWorldMap;
        _view.DictionaryButtonClicked += ScrollToDictionary;
        _view.SettingsButtonClicked += ScrollToSettings;

        _menuViews = _view._menuViews;
        scrollContentRectTransform = _view._scrollContentRectTransform;

        _model = model;
        _model.scrollRect = _view.scrollRect;
    }

    private void ChangeSizeOfScrollContent()
    {
        _model.ChangeSizeOfScrollContent();
    }

    //Я устал поэтому сделал всрато, нужно придумать систему получше.
    private void ScrollToWorldMap()
    {
        _model.ScrollToValue(0f);
    }

    private void ScrollToDictionary()
    {
        _model.ScrollToValue(0.5f);
    }

    private void ScrollToSettings()
    {
        _model.ScrollToValue(1f);
    }

    public override ViewData GetData()
    {
        throw new System.NotImplementedException();
    }

    public override ViewData GetDataFromModel()
    {
        throw new System.NotImplementedException();
    }
}
