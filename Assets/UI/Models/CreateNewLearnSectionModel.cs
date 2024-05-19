using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using Zenject;

public class CreateNewLearnSectionModel: AbstractModel
{
    private CreateNewLearnSectionViewModel _viewModel = null;

    private CreateNewLernSectionData _data = null;

    [Inject]
    public void Construct(CreateNewLearnSectionViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.SendData += TryMakeNewSection;
    }

    public ViewData GetData()
    {
        return _data;
    }

    private void ShowErrorMessage(string errorText)
    {
        _data.errorText = errorText;
        _viewModel.ShowErrorMessage(_data);
    }

    private void RewriteData()
    {
        _data = (CreateNewLernSectionData) _viewModel.GetData();
    }

    private void TryMakeNewSection()
    {
        RewriteData();
        Debug.Log(_data.sectionTitle);
        ShowErrorMessage("-1");
    }
}
