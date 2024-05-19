using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractViewModel
{
    public abstract ViewData GetData();

    public abstract ViewData GetDataFromModel();
}
