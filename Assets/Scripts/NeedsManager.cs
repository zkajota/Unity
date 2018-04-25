using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsManager : MonoBehaviour
{
    private  GameObject needsReader;
    private  GameObject owner;
    public List<NeedsTemplate> needs;

    bool initNeedsOwners;

    void Start ()
    {
        initNeedsOwners = false;
       
        //needsReader = GameObject.Find("RoutineReader");
    }
	
	void Update ()
    {
        if (needs != null)
        {
            foreach (var need in needs)
            {
                need.Tick();
            }
        }
    }

    public void AssignNeeds(GameObject god, List<NeedsTemplate> avneeds)
    {
        owner = god;
        needs = avneeds;
        GlobalActions.GeNeedsForNPC(owner, avneeds);
        foreach(var t in avneeds)
        {

            InitOwners(t);
        }
    }

    public void ChooseRandomNeed()
    {

        //needs[0].FireAction();
        Debug.Log("need chose");
    }

    public void InitOwners(NeedsTemplate need)
    {
        need.AssignOwner(owner);
    }
}
