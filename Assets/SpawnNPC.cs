using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC : MonoBehaviour {

    public static SpawnNPC instance;

    [SerializeField] GameObject npcPrefab;
    [SerializeField] Transform  npcContainer;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Use this for initialization
    void Start () {

        foreach (var item in GameManager.instance.npcList)
        {
            Spawn(item.spawnPointName, item);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn(string _spawnPointName, NPCClass _npcclass)
    {
        foreach (var item in GameManager.instance.spawnPoints)
        {
            if (item.name == _spawnPointName)
            {
                GameObject _npc = Instantiate(npcPrefab);
                _npc.transform.parent = npcContainer;
                _npc.transform.position = item.position;
                _npc.GetComponent<NPC>().npc = _npcclass;
            }
        }
    }
}
