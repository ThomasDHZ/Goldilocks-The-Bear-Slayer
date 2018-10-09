using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectStatMenu : MonoBehaviour {
    public GameObject Player;
    public bool ShowMenu = false;
    
    public Image CharPicture;
    public Image HPBar;
    public Image MPBar;
    public Image EXPBar;
    public Text CharName;
    public Text MaxHP;
    public Text MaxMP;
    public Text HP;
    public Text MP;
    public Text Level;
    public Text ATK;
    public Text DEF;
    public Text INT;
    public Text RES;
    public Text SPD;
    public Text EVD;
    public Text EXP;
    public Text MOV;
    public Text ATKRange;

    float HPMPMaxWidth = 237.7F;
    float EXPMaxWidth = 79.1F;

    // Use this for initialization
    void Start () {
		
	}
    void Update()
    {


        if (Player != null)
        {
            ShowMenu = true;
            CharPicture.GetComponent<Image>().sprite = Player.GetComponent<BaseObject>().PlayerImage;
            CharName.text = Player.GetComponent<BaseObject>().Name;
            MaxHP.text = Player.GetComponent<BaseObject>().ModMaxHP.ToString();
            MaxMP.text = Player.GetComponent<BaseObject>().ModMaxMP.ToString();
            HP.text = Player.GetComponent<BaseObject>().HP.ToString();
            MP.text = Player.GetComponent<BaseObject>().MP.ToString();
            Level.text = Player.GetComponent<BaseObject>().Level.ToString();
            ATK.text = Player.GetComponent<BaseObject>().ModATK.ToString();
            DEF.text = Player.GetComponent<BaseObject>().ModDEF.ToString();
            INT.text = Player.GetComponent<BaseObject>().ModINT.ToString();
            RES.text = Player.GetComponent<BaseObject>().ModRES.ToString();
            SPD.text = Player.GetComponent<BaseObject>().ModSPD.ToString();
            EVD.text = Player.GetComponent<BaseObject>().ModEVD.ToString();
            MOV.text = Player.GetComponent<BaseObject>().ModMOV.ToString();
            EXP.text = (Player.GetComponent<BaseObject>().NextLevel - Player.GetComponent<BaseObject>().EXP).ToString();



            HPBar.rectTransform.sizeDelta = new Vector2(HPMPMaxWidth * ((float)Player.GetComponent<BaseObject>().HP / (float)Player.GetComponent<BaseObject>().ModMaxHP), HPBar.rectTransform.sizeDelta.y);
            MPBar.rectTransform.sizeDelta = new Vector2(HPMPMaxWidth * ((float)Player.GetComponent<BaseObject>().MP / (float)Player.GetComponent<BaseObject>().ModMaxMP), MPBar.rectTransform.sizeDelta.y);
            EXPBar.rectTransform.sizeDelta = new Vector2(EXPMaxWidth * ((float)Player.GetComponent<BaseObject>().EXP / (float)Player.GetComponent<BaseObject>().NextLevel), MPBar.rectTransform.sizeDelta.y);
        }
        else
        {
            ShowMenu = false;
        }

        if(ShowMenu == false)
        {
            foreach(Transform child in transform)
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
}
