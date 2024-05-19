using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CreateNewLearnSectionViewModel : AbstractViewModel
{
    private CreateNewLearnSectionModel _model = null;
    private CreateNewLearnSectionView _view = null;

    private CreateNewLernSectionData _data = null;

    public event Action SendData;

    [Inject]
    public void Construct(CreateNewLearnSectionView view, CreateNewLearnSectionModel model)
    {
        _view = view;
        _model = model;
        _view.DataChanget += PrepareData;
    }

    public override ViewData GetDataFromModel()
    {
        return _model.GetData();
    }

    public void ShowErrorMessage(CreateNewLernSectionData data)
    {
        _view.ShowErrorMessage(data.errorText);
    }

    public void PrepareData()
    {
        _data = (CreateNewLernSectionData) _view.GetData();
        SendData.Invoke();
    }

    public override ViewData GetData()
    {
        return _data;
    }
}
