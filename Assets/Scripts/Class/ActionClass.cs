using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ActionClass : ICloneable
{

    public string name { get; set; }
    public string imageName { get; set; }
    public string forNeed { get; set; }
   [SerializeField] public Color color { get; set; }

    public ActionClass(string _name, string _imageName, string _forNeed, Color _color)
    {
        name = _name;
        imageName = _imageName;
        forNeed = _forNeed;
        color = _color;
    }


    //default constructor
    public ActionClass()
    { }



    public bool CheckRequirements()
    {
        return true;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public Transform FindActionplace(Transform _area)
    {
        Transform target = _area;
        foreach (Transform child in _area)
        {
            if (child.GetComponent<ActionObjectScript>())
            {
                ActionObjectScript areaObject = child.GetComponent<ActionObjectScript>();
                if (forNeed == areaObject.actionName)
                {
                    if (areaObject.isTaken == false)
                    {
                        areaObject.isTaken = true;
                        target = areaObject.transform;
                        return target;
                    }
                }
            }
        }
        target = null;
        return target;
    }

    public bool FulfillNeed(NeedClass _need, bool _fulfill, Transform _fountain)
    {
        _need.fulfilling = _fulfill;
        if (_need.needValue <= 0)
        {
            //_fountain.GetComponent<ActionObjectScript>().isTaken = false;
            _need.fulfilling = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
