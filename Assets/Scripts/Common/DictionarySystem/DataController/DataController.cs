using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataController : IDataController
{
    private GroupData[] _groupDatas = null;
    private string _currentSectionName = "English";
    public void SaveData(GroupData groupData)
    {
        string data = JsonUtility.ToJson(groupData);
        string filePath = Application.persistentDataPath + "/" + _currentSectionName + "/" + groupData.groupName + ".json";
        Debug.Log(filePath);
        File.WriteAllText(filePath, data);
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/" + _currentSectionName;
        var info = new DirectoryInfo(filePath);
        var fileInfo = info.GetFiles();
        foreach (var file in fileInfo)
        {
            Debug.Log(file.FullName);
        }
    }

    public void AddGroup(string groupName)
    {

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
