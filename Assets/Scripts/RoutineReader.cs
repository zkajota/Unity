using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RoutineReader : MonoBehaviour
{
    // Use this for initialization
    public List<string> actions = new List<string>();
    public List<string> needs = new List<string>();

    void Start()
    {
        GetFiles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetFiles()
    {
        //       string actionsPath = Application.streamingAssetsPath + "/Actions";
        //       string needsPath = Application.streamingAssetsPath + "/Needs";
        string actionsPath = Application.dataPath + "/Scripts/Actions";
        string needsPath = Application.dataPath + "/Scripts/Needs";
        ReadFiles(actionsPath, actions);
        ReadFiles(needsPath, needs);

        
    }

    public void ReadFiles(string path, List<string> list)
    {
        int i = 0;
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.cs");
        foreach (FileInfo f in info)
        {
            string name = f.Name;
            int length = name.Length;
            name = name.Substring(0, name.IndexOf('.'));
            list.Add(name);
            //Debug.Log(list[i]);
            i++;
        }
    }
}
