using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupButton : MonoBehaviour
{
    [SerializeField] private Sprite _hide;
    [SerializeField] private Sprite _show;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _image;

    public event Action<GroupData> VisibilityChanged;
    public event Action<GroupData> ButtonClicked;

    private GroupData _data;

    public void Init(GroupData data)
    {
        _data = data;

        if (_data.isHiden)
        {
            ChangeVisibilityOff();
        } else
        {
            ChangeVisibilityOn();
        }
        _name.text = _data.groupName;
    }

    public void OnButtonClicked()
    {
        ButtonClicked?.Invoke(_data);
    }

    public void OnSwitchVisibility()
    {
        VisibilityChanged?.Invoke(_data);
    }

    public void ChangeVisibilityOff()
    {
        _image.sprite = _hide;
    }

    public void ChangeVisibilityOn()
    {
        _image.sprite = _show;
    }
}
