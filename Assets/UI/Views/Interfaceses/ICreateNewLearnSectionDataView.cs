using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreateNewLearnSectionDataView : IBaseViewData
{
    public string errorText { get; }
    public string sectionTitle { get; set; }
}
