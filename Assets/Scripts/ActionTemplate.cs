using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ActionTemplate
{
    public abstract void Fire(GameObject owner,NeedsTemplate connectedneed);
    public abstract bool CheckRequirmenets(GameObject owner);
    public abstract void AssignArguments();
    public bool HaveFired = false;
    public abstract void Update();
    public string identifier;
    public abstract string GetNeedName();
    public abstract string GetActionImage();
}




