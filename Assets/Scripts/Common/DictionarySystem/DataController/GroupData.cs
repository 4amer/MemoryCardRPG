using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupData
{
    public string groupName = string.Empty;
    public bool isHiden = false;
    public WordData[] wordDatas = null;

    public GroupData(string groupName, WordData[] wordDatas) 
    {
        this.groupName = groupName;
        this.wordDatas = wordDatas;
    }
}

public class WordData
{
    public string wordOriginal = string.Empty;
    public string wordTranslation = string.Empty;
    public bool isHiden = false;
    public int timesWordWillShown = 0;
    public int wordShownCounter = 0;
    public int rememberCunter = 0;
    public int dontRememberCounter = 0;
    public float wordMemorizationPrecentage = 0; // from 0 to 1
}
