using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionBox : MonoBehaviour {
//   Vector2 MenuOffset = new Vector2(0, 554.31f); //assigned but never used
    public string Message = "";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        
        GUI.EndGroup();
    }
    public void SendDescriptionBoxMessage(string message)
    {
        Message = message;
    }
}
