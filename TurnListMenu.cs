using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnListMenu : MonoBehaviour
{
    public GameObject SystemManager;
    public GameObject ParentObject;
    public bool TurnListMenuFlag = true;
    public GameObject PlayerListObject;

    public int MaxPlayerListCount = 0;
    public List<GameObject> TurnList;

    public float sizeajust;
    int PlayerListCount = 0;
    //  public fl
    // Use this for initialization
    void Start()
    {
        foreach (GameObject obj in SystemManager.GetComponent<SystemManager>().ObjectList)
        {
            TurnList.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject obj in TurnList)
        {
            if (PlayerListCount <= MaxPlayerListCount)
            {
                GameObject Clone = Instantiate(PlayerListObject);
                Clone.transform.SetParent(ParentObject.transform);
                Clone.transform.position = new Vector3(Screen.width * 0.37f, (Screen.height * .635f) + (-PlayerListCount * 50), 0);
                //  Clone.transform.localScale = new Vector3(Clone.transform.localScale.x,2, Clone.transform.localScale.z);
                Clone.GetComponent<TurnListPlayerScript>().Player = obj;
                PlayerListCount++;
            }
        }

        if (TurnListMenuFlag == false)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }

    }
    public void RefeshPlayerList()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "TurnListObject(Clone)")
            {
                Destroy(child.gameObject);
            }
        }
        PlayerListCount = 0;
    }
    public void ObjectDestoryed(string ObjectName)
    {
        foreach (GameObject child in TurnList)
        {
            if (child.name == ObjectName)
            {
                TurnList.Remove(child);
            }
        }
        RefeshPlayerList();
    }
}
