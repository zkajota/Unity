using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class yellowNeed : NeedsTemplate
{
    public string name = "yellow";
    public string imageName = "sleep";


    GameObject owner;
    bool initalised;
    bool replenishing;

    public override string GetName()
    {
        return name;
    }

    public override string GetImageName()
    {
        return imageName;
    }

    public override bool CheckRequirements(GameObject owner)
    {
        string[] type = owner.GetComponent<NPC>().npcType;
        foreach (string x in type)
        {
            if (x.Contains(name))
            {
                return true;
            }
        }
        return false;
    }

    public override void SetUpNeeds()
    {
        initalised = false;
        replenishing = false;
        needValue = 0.0f;

    }
    
    public override void AssignOwner(GameObject _owner)
    {
        if (initalised == false)
        {
            owner = _owner;
            if (CheckRequirements(_owner))
            {
                initalised = true;
            }
        }
    }

    public override void FireAction()
    {
        foreach (var action in owner.GetComponent<ActionManager>().actions)
        {
           
            if (action.identifier == "colorYellow")
            {
              
                ActionTemplate pw = (ActionTemplate)Activator.CreateInstance(action.GetType(), new string[] { });
                pw.AssignArguments();
                pw.Fire(owner, this);
                this.owner.GetComponent<NPC>().FireAction(pw);
            }
        }
    }
    
    public override void Tick()
    {
        if (Fired)
        {
            return;
        }
        if (needValue >= 100.0f && !Fired)
        {
            FireAction();
            Fired = true;
           // Debug.Log("Fired yellow ");
        }
        if (owner != null && !Fired)
        {
            this.needValue = this.needValue + UnityEngine.Random.Range(0,25) * Time.deltaTime;
        }
    }

   
}
