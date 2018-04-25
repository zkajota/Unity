using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass  {

    public string name { get; set; }
    public List<string> needList { get; set; }
    public string spawnPointName { get; set; }
    public string areaName { get; set; }

    public NPCClass(string _name, List<string> _needList, string _spawnPointName, string _areaName)
    {
        name = _name;
        needList = _needList;
        spawnPointName = _spawnPointName;
        areaName = _areaName;

     
    }
    

    //default constructor
    public NPCClass()
    { }

}
