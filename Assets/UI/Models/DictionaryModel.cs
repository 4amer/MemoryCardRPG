using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Zenject;

public class DictionaryModel : AbstractModel
{
    private DictionaryViewModel _viewModel = null;
    private IDataController _dataController = null;
    private DictionaryData _dictionaryData = null;

    private const string ErrorTextInputIsEmty = "Field is empty!";
    private const string ErrorTextHasWhiteSpace = "There is spaces in you text!";
    private const string ErrorTextHasSpecialCharacters = "There are special characters in your text!";
    private const string ErrorTextGroupAlreadyExist = "This group is already exist!";

    [Inject]
    public void Construct(DictionaryViewModel viewModel, DictionaryData data, IDataController dataController)
    {
        _viewModel = viewModel;
        _dictionaryData = data;
        _dataController = dataController;
    }

    public void ChangeGameMode(GameModes gameMode)
    {
        _dictionaryData.gameMode = gameMode;
    }

    public void AddGroup(string groupName)
    {
        if (string.IsNullOrWhiteSpace(groupName))
        {
            _viewModel.ShowErrorMessage(ErrorTextInputIsEmty);
            return;
        }
        else if(groupName.Any(Char.IsWhiteSpace))
        {
            _viewModel.ShowErrorMessage(ErrorTextHasWhiteSpace);
            return;
        }
        else if (groupName.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            _viewModel.ShowErrorMessage(ErrorTextHasSpecialCharacters);
            return;
        }
        foreach (GroupData groupData in _dataController.GetAllGroups())
        {
            if(groupData.groupName == groupName)
            {
                _viewModel.ShowErrorMessage(ErrorTextGroupAlreadyExist);
                return;
            }
        }

        GroupData data = new GroupData(groupName, null);

        _dataController.AddGroup(data);
        _viewModel.CreateNewGroup(data);
    }

    public void ShowDialog()
    {
        _viewModel.ShowAddNewGroupDialog();
    }

    public void CloseDialog()
    {
        _viewModel.HideAddNewGroupDialog();
    }

    public void AddWord(string groupName, WordData wordData)
    {

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
