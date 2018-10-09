using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnListPlayerScript : MonoBehaviour {
    public GameObject Player;
    public Image PlayerIcon;
    public Image HPBar;
    float HPMaxWidth = 83.7f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerIcon.sprite = Player.GetComponent<BaseObject>().PlayerImage;
        HPBar.rectTransform.sizeDelta = new Vector2(HPMaxWidth * ((float)Player.GetComponent<BaseObject>().HP / (float)Player.GetComponent<BaseObject>().ModMaxHP), HPBar.rectTransform.sizeDelta.y);
    }
}
