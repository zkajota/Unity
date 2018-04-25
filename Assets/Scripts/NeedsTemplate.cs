using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract public class NeedsTemplate
{

    public abstract void SetUpNeeds();
   
    public abstract void AssignOwner(GameObject _owner);
    public abstract void FireAction();
    public abstract void Tick();
    public abstract bool CheckRequirements(GameObject owner);
    public bool Fired = false;
    public float needValue = 0f;
    public abstract string GetName();
    public abstract string GetImageName();

}



