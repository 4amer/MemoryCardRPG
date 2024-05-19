using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryData
{
    public SearchFilters searchFilters { get; set; } = SearchFilters.None;
    public GameModes gameMode { get; set; }  = GameModes.Classic;
    public List<string> groupNames { get; set; }  = new List<string>();
}
