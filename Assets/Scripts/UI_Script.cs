using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour {

    public static UI_Script instance;

    [SerializeField] Camera cam;


    [Header("NPC")]
    public NPC selectedNPC;
    public Transform NPCContainer;
    public Text npcNameText;
    int npcAmount;

    [Header("Needs")]
    public Transform needsContainer;
    public GameObject needPrefab;

    [Header("Actions")]
    public Transform actionContainer;
    public GameObject actionPrefab;
    Dictionary<string, GameObject> actions = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // cam position
        if (selectedNPC != null)
        {
            cam.transform.position = new Vector3(selectedNPC.transform.position.x, selectedNPC.transform.position.y + 5, selectedNPC.transform.position.z - 6);
            cam.transform.LookAt(selectedNPC.transform.position);
            
        }
    }

    void CreateNeedsUI()
    {

        foreach (Transform item in needsContainer) // clear container
        {
            Destroy(item.gameObject);
        }

        foreach (NeedClass item in selectedNPC.needs)  /// create needs prefabs
        {
            GameObject _need = Instantiate(needPrefab);
            _need.transform.parent = needsContainer;
            _need.GetComponent<UI_PrefabNeed>().need = item;
        }

    }

    public void CreateActionsUI()
    {

        foreach (Transform item in actionContainer) // clear container
        {
            Destroy(item.gameObject);
            actions.Clear();
        }

        foreach (ActionClass item in selectedNPC.queue)  /// create needs prefabs
        {
            if (!actions.ContainsKey(item.name))
            {
                GameObject _action = Instantiate(actionPrefab);
                _action.transform.parent = actionContainer;
                _action.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/" + item.imageName);
                actions.Add(item.name, _action);
            }
        }

    }
    

    public void EndActionUI(string _actionName)
    {
      //  print("remove: " + _actionName);

        if (actions.ContainsKey(_actionName))
        {
            Destroy(actions[_actionName]);
            actions.Remove(_actionName);
        }
    }


    int i = 0;
    /// SELECT NPC
    
    public void NextNPC()
    {
        npcAmount = NPCContainer.childCount;

        i++;
        if (i > npcAmount - 1)
            i = 0;
        
        selectNPC();
    }

    public void PrevNPC()
    {
        npcAmount = NPCContainer.childCount;

        i--;
        if (i < 0)
            i = npcAmount - 1;
        
        selectNPC();
    }

    void selectNPC()
    {
        selectedNPC = NPCContainer.GetChild(i).GetComponent<NPC>();
        npcNameText.text = selectedNPC.npc.name;
        CreateNeedsUI();
        CreateActionsUI();
        
    }
}
