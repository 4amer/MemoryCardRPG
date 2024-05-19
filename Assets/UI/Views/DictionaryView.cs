using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DictionaryView : AbstractView
{
    [SerializeField] private TMP_InputField _searchField = null;
    [SerializeField] private TMP_Dropdown _searchDropDown = null;
    [SerializeField] private TMP_Dropdown _gameModeDropDown = null;

    [SerializeField] private GameObject _newGroupDialog = null;
    [SerializeField] private TMP_InputField _addNewGroupInputText = null;
    [SerializeField] private TextMeshProUGUI _errorText = null;

    [SerializeField] private Transform _groupButtonContainer = null;
    [SerializeField] private GameObject _groupButtonPrefab = null;
    [SerializeField] private Transform _wordButtonContainer = null;
    [SerializeField] private GameObject _wordButtonPrefab = null;

    private DictionaryData _dictionaryData = null;

    //Search field
    public event Action<string> SearchFieldChanged;
    public event Action<SearchFilters> FilterChanged;

    //Bottom menu
    public event Action OptinsButtonClicked;
    public event Action MenuAddGroupButtonClicked;
    public event Action<GameModes> GameModeChanged;
    public event Action PlayButtonClicked;

    //Add new group dialog
    public event Action<string> AddNewGroupDialogButtonClicked;
    public event Action CloseDialogButtonClicked;

    [Inject]
    public void Construct(DictionaryData data)
    {
        _dictionaryData = data;
    }

    private void Awake()
    {
        _searchDropDown = _searchDropDown.GetComponent<TMP_Dropdown>();
    }

    public void WhenSearchFieldChanged()
    {
        string text = _searchField.text;
        SearchFieldChanged?.Invoke(text);
    }

    public void WhenFilterChanged()
    {
        SearchFilters filter = FindSearchFilter();
        FilterChanged?.Invoke(filter);
    }

    public void WhenOptinsButtonClicked()
    {
        OptinsButtonClicked?.Invoke();
    }

    public void WhenAddGroupButtonClicked()
    {
        MenuAddGroupButtonClicked?.Invoke();
    }

    public void WhenGameModeChanged()
    {
        GameModes gameMode = FindGameMode();
        GameModeChanged?.Invoke(gameMode);
    }
    
    public void WhenPlayButtonClicked()
    {
        PlayButtonClicked?.Invoke();
    }

    public void WhenAddNewGroupDialogButtonClicked()
    {
        string groupName = _addNewGroupInputText.text;
        AddNewGroupDialogButtonClicked?.Invoke(groupName);
    }

    public void WhenCloseDialogButtonClicked()
    {
        CloseDialogButtonClicked?.Invoke();
    }

    private GameModes FindGameMode()
    {
        GameModes gameMode = GameModes.Classic;
        int pickedIndex = _gameModeDropDown.value;
        string selectedOption = _gameModeDropDown.options[pickedIndex].text;
        switch (selectedOption)
        {
            case "Default":
                gameMode = GameModes.Classic;
                break;
            case "ByWords":
                gameMode = GameModes.MemoryCards;
                break;
            case "ByGroups":
                gameMode = GameModes.SpeedRun;
                break;
        }
        return gameMode;
    }

    private SearchFilters FindSearchFilter()
    {
        SearchFilters filter = SearchFilters.None;
        int pickedIndex = _searchDropDown.value;
        string selectedOption = _searchDropDown.options[pickedIndex].text;
        switch (selectedOption)
        {
            case "Default":
                filter = SearchFilters.None;
                break;
            case "ByWords":
                filter = SearchFilters.ByWords;
                break;
            case "ByGroups":
                filter = SearchFilters.ByGroups;
                break;
        }
        return filter;
    }

    public void ShowAddNewGroupDialog()
    {
        _newGroupDialog.active = true;
    }

    public void HideAddNewGroupDialog()
    {
        _newGroupDialog.active = false;
        ClearNewGroupInputField();
        ClearErrorMessage();
    }

    public void ClearNewGroupInputField()
    {
        _addNewGroupInputText.text = string.Empty;
    }

    public void ShowErrorMessage(string text)
    {
        _errorText.text = text;
    }

    public void ClearErrorMessage()
    {
        _errorText.text = string.Empty;
    }

    public void CreateNewGroup(GroupData data)
    {
        GameObject groupButton = Instantiate(_groupButtonPrefab, _groupButtonContainer);
        groupButton.GetComponent<GroupButton>().Init(data);
    }
}
