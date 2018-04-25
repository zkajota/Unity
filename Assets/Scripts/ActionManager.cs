using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private static GameObject actionReader;
    [SerializeField]
    public List<ActionTemplate> actions;
    private GameObject owner;

    // Use this for initialization
    void Start ()
    {
        //actionReader = GameObject.Find("RoutineReader");
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
      

    public void AssignActions(GameObject god, List<ActionTemplate> avactions)
    {
        owner =god;
        actions = avactions;
        GlobalActions.GetActionsForNPC(owner,actions);
    }

    
}
