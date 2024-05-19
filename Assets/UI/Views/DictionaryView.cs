using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DictionaryView : AbstractView
{
    [SerializeField] private TMP_InputField _searchField = null;
    [SerializeField] private TMP_Dropdown _searchDropDown = null;
    [SerializeField] private TMP_Dropdown _gameModeDropDown = null;

    private DictionaryData _dictionaryData = null;

    public event Action<string> SearchFieldChanged;
    public event Action<SearchFilters> FilterChanged;

    public event Action OptinsButtonClicked;
    public event Action AddGroupButtonClicked;
    public event Action<GameModes> GameModeChanged;
    public event Action PlayButtonClicked;

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
        AddGroupButtonClicked?.Invoke();
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
}
