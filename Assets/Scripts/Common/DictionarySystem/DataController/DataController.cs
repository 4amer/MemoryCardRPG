using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Zenject;

public class DataController : IDataController, IInitializable
{
    private List<GroupData> _groupDatas = new List<GroupData>();
    private string _currentSectionName = "English";

    public void Initialize()
    {
        LoadGroupData();
    }

    public void SaveGroupData(GroupData groupData)
    {
        string data = JsonUtility.ToJson(groupData);
        string filePath = Application.persistentDataPath + "/" + groupData.groupName + ".json";
        //string filePath = Application.persistentDataPath + "/" + _currentSectionName + "/" + groupData.groupName + ".json";
        Debug.Log(filePath);
        File.WriteAllText(filePath, data);
    }

    public void LoadGroupData()
    {
        string filePath = Application.persistentDataPath;
        //string filePath = Application.persistentDataPath + "/" + _currentSectionName;
        var info = new DirectoryInfo(filePath);
        var fileInfo = info.GetFiles();
        Debug.Log("LOAD GROUPS");
        foreach (var file in fileInfo)
        {
            //Debug.Log(file);
            string text = File.ReadAllText(file.FullName);
            GroupData myObject = JsonUtility.FromJson<GroupData>(text);
            _groupDatas.Add(myObject);
        }
    }

    public void AddGroup(GroupData data)
    {
        SaveGroupData(data);
        _groupDatas.Add(data);
    }

    public void AddWord(string groupName, WordData wordData)
    {

    }

    public GroupData[] GetAllGroups()
    {
        return _groupDatas.ToArray();
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
