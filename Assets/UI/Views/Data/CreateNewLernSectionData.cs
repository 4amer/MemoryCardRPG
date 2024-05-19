using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewLernSectionData : ViewData, ICreateNewLearnSectionDataView
{
    public string errorText { get; set; }

    public string sectionTitle { get; set; }
}
