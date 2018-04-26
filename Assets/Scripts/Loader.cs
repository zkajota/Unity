//////////////////////////////////////////////////////////////
//This script is responsible for loading XML files.
//Saving is implemented too, but not used.
//////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

using System.Text;

public class Loader : MonoBehaviour
{

    /***************************      Save NPC To XML     ***********************************************************/
    public static void ExportNPCs(List<NPCClass> npcList)
    {
        foreach (var item in npcList)
        {
            string file = Application.dataPath + "/Data/NPCs/" + item.name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(NPCClass));

            using (StreamWriter sw1 = new StreamWriter(file, false, Encoding.GetEncoding("ISO-8859-2")))
            {
                serializer.Serialize(sw1, item);
            }
        }

    }

    /***************************      LOAD NPCs   ***********************************************************/
    public static void ImportNPCs()
    {
        string dirpath = Application.dataPath + "/Data/NPCs";
        DirectoryInfo d = new DirectoryInfo(dirpath);

        foreach (var item in d.GetFiles("*.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NPCClass));
            string file = item.FullName;
            using (StreamReader sw1 = new StreamReader(file, Encoding.GetEncoding("ISO-8859-2")))
            {
                NPCClass _npc = serializer.Deserialize(sw1) as NPCClass;
                GameManager.instance.npcList.Add(_npc);
                
            }

        }
        Debug.Log("Load Complete -  NPC amount: " + GameManager.instance.npcList.Count);
    }



    //// NEEDS

    /***************************      Save NEEDS to XML     ***********************************************************/
    public static void ExportNeeds(List<NeedClass> needsList)
    {
        foreach (var item in needsList)
        {
            string plik = Application.dataPath + "/Data/Needs/" + item.name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(NeedClass));

            using (StreamWriter sw1 = new StreamWriter(plik, false, Encoding.GetEncoding("ISO-8859-2")))
            {
                serializer.Serialize(sw1, item);
            }
        }

    }

    public static void ImportNeeds()
    {
        string dirpath = Application.dataPath + "/Data/Needs";
        DirectoryInfo d = new DirectoryInfo(dirpath);

        foreach (var item in d.GetFiles("*.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(NeedClass));
            string file = item.FullName;
            using (StreamReader sw1 = new StreamReader(file, Encoding.GetEncoding("ISO-8859-2")))
            {
                NeedClass _need = serializer.Deserialize(sw1) as NeedClass;
                GameManager.instance.needsList.Add(_need);

            }

        }
        Debug.Log("Load Complete -  Needs amount: " + GameManager.instance.needsList.Count);
    }


    //// Actions

    /***************************      Save Actions to XML (Serialisation)    ***********************************************************/
    public static void ExportActions(List<ActionClass> actions)
    {
        foreach (var item in actions)
        {
            string file = Application.dataPath + "/Data/Actions/" + item.name + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ActionClass));

            using (StreamWriter sw1 = new StreamWriter(file, false, Encoding.GetEncoding("ISO-8859-2")))
            {
                serializer.Serialize(sw1, item);
            }
        }

    }

    public static void ImportActions()
    {
        string dirpath = Application.dataPath + "/Data/Actions";
        DirectoryInfo d = new DirectoryInfo(dirpath);

        foreach (var item in d.GetFiles("*.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ActionClass));
            string file = item.FullName;
            using (StreamReader sw1 = new StreamReader(file, Encoding.GetEncoding("ISO-8859-2")))
            {
                ActionClass _act = serializer.Deserialize(sw1) as ActionClass;
                GameManager.instance.actionsList.Add(_act);

            }

        }
        Debug.Log("Load Complete -  Actions amount: " + GameManager.instance.actionsList.Count);
    }


}

