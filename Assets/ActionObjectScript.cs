using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObjectScript : MonoBehaviour {

    [SerializeField] public string actionName;
    public bool isTaken;
    public ActionClass action;


	// Use this for initialization
	void Start () {
        isTaken = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setAction()
    {
        foreach (var item in GameManager.instance.actionsList)
        {
            if (actionName == item.name)
                action = item;
        }
    }
}
