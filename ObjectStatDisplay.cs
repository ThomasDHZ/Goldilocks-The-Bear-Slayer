using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatDisplay : MonoBehaviour {
    public GameObject OBJSlot1;
    public GameObject OBJSlot2;
    public bool ShowMenu = false;

    public Vector2 MenuOffset = new Vector2(0, 448.63f);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        if (ShowMenu == true)
        {
            if (OBJSlot1 != null)
            {
                MenuOffset.x = 0;
                GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
                GUI.Box(new Rect(MenuOffset.x, MenuOffset.y, Screen.width * .5f, Screen.height * .25f), "");
             //   GUI.DrawTexture(new Rect(MenuOffset.x, MenuOffset.y, Screen.width * .125f, Screen.height * .25f), OBJSlot1.GetComponent<BaseObject>().PlayerImage);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y, Screen.width / 3.75f, Screen.height / 20), "Name: " + OBJSlot1.GetComponent<BaseObject>().Name + " LV: " + OBJSlot1.GetComponent<BaseObject>().Level);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 25, Screen.width / 3.75f, Screen.height / 20), "HP " + OBJSlot1.GetComponent<BaseObject>().HP + "/" + OBJSlot1.GetComponent<BaseObject>().MaxHP);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 50, Screen.width / 3.75f, Screen.height / 20), "HP " + OBJSlot1.GetComponent<BaseObject>().MP + "/" + OBJSlot1.GetComponent<BaseObject>().MaxMP);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 75, Screen.width / 3.75f, Screen.height / 20), "ATK " + OBJSlot1.GetComponent<BaseObject>().ATK + " DEF " + OBJSlot1.GetComponent<BaseObject>().DEF);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 100, Screen.width / 3.75f, Screen.height / 20), "INT " + OBJSlot1.GetComponent<BaseObject>().INT + " RES " + OBJSlot1.GetComponent<BaseObject>().RES);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 125, Screen.width / 3.75f, Screen.height / 20), "SPD " + OBJSlot1.GetComponent<BaseObject>().SPD + " EXP " + OBJSlot1.GetComponent<BaseObject>().EXP);
                GUI.EndGroup();
            }
            if(OBJSlot1.tag != null)
            {
                MenuOffset.x = 563.46f;
                GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
                GUI.Box(new Rect(MenuOffset.x, MenuOffset.y, Screen.width * .5f, Screen.height * .25f), "");
              //  GUI.DrawTexture(new Rect(MenuOffset.x, MenuOffset.y, Screen.width * .125f, Screen.height * .25f), OBJSlot2.GetComponent<BaseObject>().PlayerImage);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y, Screen.width / 3.75f, Screen.height / 20), "Name: " + OBJSlot2.GetComponent<BaseObject>().Name + " LV: " + OBJSlot2.GetComponent<BaseObject>().Level);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 25, Screen.width / 3.75f, Screen.height / 20), "HP " + OBJSlot2.GetComponent<BaseObject>().HP + "/" + OBJSlot2.GetComponent<BaseObject>().MaxHP);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 50, Screen.width / 3.75f, Screen.height / 20), "HP " + OBJSlot2.GetComponent<BaseObject>().MP + "/" + OBJSlot2.GetComponent<BaseObject>().MaxMP);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 75, Screen.width / 3.75f, Screen.height / 20), "ATK " + OBJSlot2.GetComponent<BaseObject>().ATK + " DEF " + OBJSlot2.GetComponent<BaseObject>().DEF);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 100, Screen.width / 3.75f, Screen.height / 20), "INT " + OBJSlot2.GetComponent<BaseObject>().INT + " RES " + OBJSlot2.GetComponent<BaseObject>().RES);
                GUI.Label(new Rect(MenuOffset.x + 200, MenuOffset.y + 125, Screen.width / 3.75f, Screen.height / 20), "SPD " + OBJSlot2.GetComponent<BaseObject>().SPD + " EXP " + OBJSlot2.GetComponent<BaseObject>().EXP);
                GUI.EndGroup();
            }
        }
    }
}
