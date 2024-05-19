using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Zenject;

public class CreateNewLearnSectionView : AbstractView
{
    [SerializeField] private TextMeshProUGUI _textField = null;
    [SerializeField] private GameObject _errorTextGameObject = null;
    [SerializeField] private Button _button = null;

    private ICreateNewLearnSectionDataView _data = new CreateNewLernSectionData();

    private void Start()
    {
        _textField = _textField.GetComponent<TextMeshProUGUI>();
        
    }

    public void Display(ICreateNewLearnSectionDataView data)
    {
        _data = data;
    }

    public ICreateNewLearnSectionDataView GetData()
    {
        return _data;
    }

    protected void PrepareData()
    {
        _data.sectionTitle = _textField.text;

        base.PrepareData();
    }

    public void ShowErrorMessage(string errorText)
    {
        _errorTextGameObject.GetComponent<TextMeshProUGUI>().text = "Error: " + errorText;
        _errorTextGameObject.SetActive(true);
    }
}
