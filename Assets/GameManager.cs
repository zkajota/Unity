using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public  List<Transform> spawnPoints;
    public  List<Transform> areas;

    public List<NPCClass> npcList = new List<NPCClass>();
    public List<NeedClass> needsList = new List<NeedClass>();
    public List<ActionClass> actionsList = new List<ActionClass>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);


        Loader.ImportNPCs();
        Loader.ImportNeeds();
        Loader.ImportActions();

    }

    // Use this for initialization
    void Start() {
        //List<NPCClass> np = new List<NPCClass>() { new NPCClass("nazwa", new List<string>() { "need1", "need2" }, "SP_1", "areaName"),
        //                                            new NPCClass("nazwa2", new List<string>() { "need12", "need22" }, "SP_2", "areaName2"), };

        //Loader.ExportXML(np);
        //List<NeedClass> nds = new List<NeedClass>() { new NeedClass("need1", "food", 1), new NeedClass("need2", "food", 1) };
        //Loader.ExportNeeds(nds);

        //List<ActionClass> act = new List<ActionClass>() { new ActionClass("Action1", "icon1", "Food", Color.red), new ActionClass("Action2", "icon2", "Drink",Color.black) };
        //Loader.ExportActions(act);
    }

    // Update is called once per frame
    void Update () {
		
	}
    
    

}
