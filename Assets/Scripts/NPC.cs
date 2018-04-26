//////////////////////////////////////////////////////////////
//NPC class. Queueing of actions, Assigning of needs
//////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour {

    public NPCClass npc;
    public List<ActionClass> actions = new List<ActionClass>();
    public List<NeedClass> needs = new List<NeedClass>();
    public List<ActionClass> queue = new List<ActionClass>();
    Transform area;
    private bool fulfilling;
    Transform target;
    NavMeshAgent agent;
    

    public List<GameObject> availableAreas;

    public NavMeshAgent navmesh;

    void Awake()
    {

    }

    private void Start()
    {
        target = null;
        agent = gameObject.GetComponent<NavMeshAgent>();
        AssignNeeds();
        AssignArea();
        AssignActions();
    }
    // Update is called once per frame
    void Update ()
    {
        AddToQueue();
        DoQueue();
        TickNeeds();
        if (target != null)
        {
            MoveTo(target);
        }
    }

  


    


    void AssignNeeds()
    {
        foreach (NeedClass item in GameManager.instance.needsList)
        {
            if (npc.needList.Contains(item.name))
            {
                needs.Add((NeedClass)item.Clone());
            }
        }
    }

    void AssignActions()
    {
        actions = GameManager.instance.actionsList;

        
    }

    void AssignArea()
    {
        foreach (var item in GameManager.instance.areas)
        {
            if (item.name == npc.areaName)
            {
                area = item;
                break;
            }
        }
    }

    private void AddToQueue()
    {
        foreach (var item in needs)
        {
            if (item.needValue > 20)
            {
                //if need is not already in queue
                if (item.queued == false)
                {
                    //find which action to fulfill and add to queue
                    foreach (var action in actions)
                    {
                            if (action.forNeed == item.name)
                            {
                                Transform aa = action.CheckPlaces(area);
                                if (aa != null)
                                {
                                    queue.Add(action);
                                    UI_Script.instance.CreateActionsUI();
                                    item.queued = true;
                                }
                        }
                    }
                }
            }
        }
    }

    private void DoQueue()
    {
        //check if any item is in Queue
        if (queue.Count != 0)
        {
            ActionClass currentAction = queue[0];
            if (target == null)
            {
                //find which fountain to go to. If all are taken shuffle Queue.
                target = currentAction.FindActionplace(area);
                if (target == null)
                {
                    if (queue.Count > 1)
                    {
                        ShuffleQueue();

                    }
                }
            }
            if (target != null)
            {
                //check if close to correct fountain, and fulfill need
                if (Vector3.Distance(transform.position, target.position) < 1.0f)
                {
                    foreach (var need in needs)
                    {
                        if (need.name == currentAction.forNeed)
                        {
                            bool finished = currentAction.FulfillNeed(need, true, target);
                            gameObject.GetComponent<Renderer>().material.SetColor("_Color", currentAction.color);
                            target.GetComponent<ActionObjectScript>().isTaken = true;

                            //remove from queue
                            if (finished == true)
                            {
                                need.queued = false;
                                target.GetComponent<ActionObjectScript>().isTaken = false;

                                target = null;
                                queue.RemoveAt(0);
                                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                                UI_Script.instance.CreateActionsUI();
                            }
                        }
                    }
                }
            }
        }
    }



    private void MoveTo(Transform _target)
    {
        agent.SetDestination(_target.position);
        Debug.Log("I'm moving to - " + _target.name);
    }

    private void TickNeeds()
    {
        foreach (var need in needs)
        {
            need.Tick();
        }
    }

    private void ShuffleQueue()
    {
        Debug.Log("shuffling");
        for (int i = 0; i < queue.Count; i++)
        {
            ActionClass ac = queue[i];
            int randomIndex = Random.Range(i, queue.Count);
            queue[i] = queue[randomIndex];
            queue[randomIndex] = ac;
        }
    }
}
