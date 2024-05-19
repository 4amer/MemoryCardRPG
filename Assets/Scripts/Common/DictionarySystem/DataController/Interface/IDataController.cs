using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataController
{
    public void AddGroup(string groupName);

    public void AddWord(string groupName, WordData wordData);

    public GroupData[] GetAllGroups();

    public string[] GetWordsFromGroup(string groupName);

    public string[] GetWordsStartWith(string characters);

    public string[] GetGroupsStartWith(string characters);
}
