using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Zenject;

public class DictionaryViewModel : AbstractViewModel
{
    private DictionaryModel _dictionaryModel = null;

    [Inject]
    public void Construct(DictionaryView view, DictionaryModel model)
    {
        view.SearchFieldChanged += SearchFieldChanged;
        view.FilterChanged += FilterChanged;

        view.GameModeChanged += GameModeChanged;
        view.PlayButtonClicked += PlayButtonClicked;
        view.AddGroupButtonClicked += AddGroupButtonClicked;
        view.OptinsButtonClicked += OptinsButtonClicked;

        _dictionaryModel = model;
    }

    public override ViewData GetData()
    {
        return null;
    }

    public override ViewData GetDataFromModel()
    {
        return null;
    }

    private void SearchFieldChanged(string text)
    {
        Debug.Log(text);
    }

    private void FilterChanged(SearchFilters filter)
    {
        Debug.Log(filter);
    }

    public void OptinsButtonClicked()
    {

    }

    public void AddGroupButtonClicked()
    {

    }

    public void GameModeChanged(GameModes gameMode)
    {

    }

    public void PlayButtonClicked()
    {

    }
}
