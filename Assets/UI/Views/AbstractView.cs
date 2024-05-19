using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractView : MonoBehaviour
{
    public event Action DataChanget;

    protected void PrepareData()
    {
        DataChanget?.Invoke();
    }

    public void Construct(AbstractViewModel viewModel) { }
    public void Display(ViewData data) { }
}
