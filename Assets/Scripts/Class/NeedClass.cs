using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NeedClass : ICloneable
{

    public string name { get; set; }
    public string imageName { get; set; }
    public float needValue { get; set; }
    public float growthRate { get; set; }
    public bool queued { get; set; }
    public bool fulfilling { get; set; }

    public NeedClass(string _name, string _imageName,  float _growthRate)
    {
        name = _name;
        imageName = _imageName;
        needValue = 0;
        growthRate = _growthRate;
        queued = false;
        fulfilling = false;
    }

    //default constructor
    public NeedClass()
    { }


    public bool CheckRequirements()
    {
                return true;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }


    public void Tick()
    {
        if (fulfilling == false)
        {
            if (needValue < 100)
                needValue += growthRate / 10;
        }
        else if (fulfilling)
        {
            if (needValue > 0)
                needValue -= growthRate / 2;
        }
    }

    public void ResetNeedValue()
    {
        needValue = 0;
    }

}
