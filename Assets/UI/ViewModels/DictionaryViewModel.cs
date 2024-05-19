using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Zenject;

public class DictionaryViewModel : AbstractViewModel
{
    private DictionaryModel _model = null;
    private DictionaryView _view = null;

    [Inject]
    public void Construct(DictionaryView view, DictionaryModel model)
    {
        _view = view;
        _view.SearchFieldChanged += SearchFieldChanged;
        _view.FilterChanged += FilterChanged;

        _view.GameModeChanged += GameModeChanged;
        _view.PlayButtonClicked += PlayButtonClicked;
        _view.MenuAddGroupButtonClicked += MenuAddGroupButtonClicked;
        _view.OptinsButtonClicked += OptinsButtonClicked;

        _view.AddNewGroupDialogButtonClicked += AddNewGroupDialogButtonClicked;
        _view.CloseDialogButtonClicked += CloseDialogButtonClicked;

        _model = model;
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

    private void OptinsButtonClicked()
    {

    }

    private void MenuAddGroupButtonClicked()
    {
        _model.ShowDialog();
    }

    private void GameModeChanged(GameModes gameMode)
    {

    }

    private void PlayButtonClicked()
    {

    }

    public void ShowAddNewGroupDialog()
    {
        _view.ShowAddNewGroupDialog();
    }

    public void HideAddNewGroupDialog()
    {
        _view.HideAddNewGroupDialog();
    }

    public void ShowErrorMessage(string text)
    {
        _view.ShowErrorMessage(text);
    }

    private void AddNewGroupDialogButtonClicked(string groupName)
    {
        _model.AddGroup(groupName);
    }

    private void CloseDialogButtonClicked()
    {
        _model.CloseDialog();
    }
}
