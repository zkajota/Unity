using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalActions {

    [SerializeField]
    private static List<ActionTemplate> l_Actions;
    private static List<NeedsTemplate> l_Needs;
    public static bool HaveInitializated = false;
    public static void Init()
    {
        l_Actions = new List<ActionTemplate>();
        foreach(var up in GetAllSubclassOf(typeof(ActionTemplate)))
        {
            l_Actions.Add((ActionTemplate)Activator.CreateInstance(up,new string[] { }));
        }

        l_Needs = new List<NeedsTemplate>();
        foreach (var up in GetAllSubclassOf(typeof(NeedsTemplate)))
        {
            l_Needs.Add((NeedsTemplate)Activator.CreateInstance(up, new string[] { }));
        }
        //Debug.Log(l_Actions.Count);
        HaveInitializated = true;
    }
    // Use this for initialization
    public static IEnumerable<Type> GetAllSubclassOf(Type parent)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            foreach (var t in a.GetTypes())
                if (t.IsSubclassOf(parent)) yield return t;
    }
    public static void GetActionsForNPC(GameObject npc,List<ActionTemplate> availableActions)
    {
        if (!HaveInitializated)
        {
            Init();
        }
        if(availableActions != null)
        {
            foreach (var action in l_Actions)
            {
                if (action.CheckRequirmenets(npc))
                {
                    action.AssignArguments();
                    availableActions.Add(action);
                }
            }
        }
    }
    public static void GeNeedsForNPC(GameObject npc, List<NeedsTemplate> availableNeeds)
    {
        if (!HaveInitializated)
        {
            Init();
        }
        if (availableNeeds != null)
        {
            foreach (var need in l_Needs)
            {
                if (need.CheckRequirements(npc))
                {
                    need.SetUpNeeds();
                    availableNeeds.Add((NeedsTemplate)Activator.CreateInstance(need.GetType()));
                }
            }
        }
    }
}
