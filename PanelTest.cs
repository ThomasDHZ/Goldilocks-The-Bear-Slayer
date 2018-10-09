using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTest : MonoBehaviour {
    public Texture LifeBarimage;
    public Vector2 LifeBar;
    public Vector2 MagicBar;
    public Vector2 EXPBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(LifeBar.x, LifeBar.y, 100, 20), LifeBarimage);
    }
}
