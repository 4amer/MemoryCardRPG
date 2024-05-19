using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DictionaryModel : AbstractModel
{
    private DictionaryViewModel _viewModel = null;
    private DictionaryData _dictionaryData = null;

    [Inject]
    public void Construct(DictionaryViewModel viewModel, DictionaryData data)
    {
        _viewModel = viewModel;
        _dictionaryData = data;
    }

    public void ChangeGameMode(GameModes gameMode)
    {
        _dictionaryData.gameMode = gameMode;
    }

    public string[] GetAllGroups()
    {
        return null;
    }

    public string[] GetWordsFromGroup(string groupName)
    {
        return null;
    }

    public string[] GetWordsStartWith(string characters)
    {
        return null;
    }

    public string[] GetGroupsStartWith(string characters)
    {
        return null;
    }
}
