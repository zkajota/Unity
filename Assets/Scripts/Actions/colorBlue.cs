using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class colorBlue : ActionTemplate
{

    GameObject owner;
    public NeedsTemplate need;
    GameObject target;
    bool PathSelected = false;
    public float Waiting = 0.0f;
    public string imageName = "food";


    public override void AssignArguments()
    {
        identifier = "colorBlue";
    }

    public override string GetNeedName()
    {
        return need.GetName();
    }

    public override string GetActionImage()
    {
        return imageName;
    }

    public override bool CheckRequirmenets(GameObject owner)
    {
        return true; //temp
        string[] type = owner.GetComponent<NPC>().npcType;
        foreach (string x in type)
        {
            if (x.Contains("blue"))
            {
                return true;
            }
        }
        return false;
    }

    public override void Update()
    {
        find all yellowneedscubes
        if (Waiting > 0)
        {
            Waiting = Waiting - Time.deltaTime;
            need.needValue = -100.0f;

            return;
        }
        if (Waiting < 0)
        {
            owner.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            HaveFired = true;
            return;
        }
        if (!HaveFired)
        {
            if (!PathSelected)
            {
                FindFountain();
            }
            if (PathSelected && !owner.GetComponent<NavMeshAgent>().isStopped)
            {
                float range = (owner.transform.position - owner.GetComponent<NavMeshAgent>().destination).magnitude;
                var dist = owner.GetComponent<NavMeshAgent>().remainingDistance;


                if (dist < 1.0f && dist > 0.0f)
                {
                    Debug.Log("Arriving at Blue destination ");
                    PathSelected = false;
                    need.Fired = false;

                    StopPath();
                    Waiting = 5.0f;
                    owner.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    return;
                }
                if (dist == 0 && range >= 1)
                {
                    RecalculatePath();
                }
            }
        }

    }
    public void StopPath()
    {
        var nw = owner.GetComponent<NavMeshAgent>();

        nw.ResetPath();
        nw.Stop();
    }
    public void RecalculatePath()
    {
        var nw = owner.GetComponent<NavMeshAgent>();

        nw.ResetPath();
        bool uk = nw.SetDestination(target.transform.position);

        nw.Resume();

        PathSelected = true;
    }
    public void FindFountain()
    {

        List<GameObject> go = new List<GameObject>();
        foreach (var t in owner.GetComponent<NPC>().availableAreas)
        {
            foreach (var upka in t.GetComponent<Area>().l_waypoints)
            {
                if (upka.name == "blueNeed")
                {
                    go.Add(upka);
                }
            }
        }
        //   Debug.Log("Found max " + go.Count + " targets");
        target = go[Random.Range(0, go.Count)];
        var nw = owner.GetComponent<NavMeshAgent>();

        nw.ResetPath();
        nw.SetDestination(target.transform.position);
        nw.Resume();

        PathSelected = true;
    }
    public override void Fire(GameObject owner, NeedsTemplate connectedneed)
    {
        this.owner = owner;
        this.HaveFired = false;

        this.target = null;
        this.PathSelected = false;
        need = connectedneed;
    }
}


