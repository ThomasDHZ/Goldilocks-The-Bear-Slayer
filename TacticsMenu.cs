using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TacticsMenu : MonoBehaviour
{
    public SystemManager GameManager;
    public GameObject TurnListMenu;

    public bool MenuFlag = false;
    public bool MovingFlag = false;
    public bool AttackFlag = false;
    public bool ItemMenuFlag = false;
    public bool EquipmentMenuFlag = false;
    public bool SkillsMenuFlag = false;
    public bool TurnListFlag = true;

    public GameObject MoveButtonActive;
    public GameObject AttackButtonActive;
    public GameObject SkillsButtonActive;
    public GameObject DefendButtonActive;
    public GameObject ItemButtonActive;
    public GameObject EquipmentButtonActive;

	public GameObject AttackingPlayer;
    public GameObject DefendingPlayer;
    public GameObject SelectedPlayer;

    public Text DescptionText;

	private Unit unitScript;

    // Use this for initialization
    void Start ()
    {
		unitScript = GameObject.Find ("Player").GetComponent<Unit> ();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (MenuFlag == false)
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
            if (Input.GetButtonDown("KeyMouse_TacticsMenu"))
        {
            if (GameManager.ActivePlayer.tag == "Player")
            {
                if (MenuFlag == true)
                {
                    MenuFlag = false;
                    GameManager.PlayerStatsMenu.GetComponent<ObjectStatMenu>().ShowMenu = false;
                    GameManager.PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = null;
                }
                else
                {
                    if (GameManager.Itemmenu.GetComponent<ItemMenu>().UseItemFlag == false)
                    {
                        if (GameManager.AttackingMenu.GetComponent<AttackingMenu>().AttackingMenuFlag == false)
                        {
                            GameManager.PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = GameManager.ActivePlayer;
                        }
                        if (GameManager.Itemmenu.GetComponent<ItemMenu>().UseItemFlag == false)
                        {
                            GameManager.Itemmenu.GetComponent<ItemMenu>().ItemMenuFlag = false;
                        }

                        MenuFlag = true;
                        GameManager.Movemenu.MoveFlag = false;
                        GameManager.AttackingMenu.GetComponent<AttackingMenu>().AttackingMenuFlag = false;
                        GameManager.Equipmentmenu.GetComponent<EquipmentMenu>().EquipmentMenuFlag = false;
                        GameManager.PlayerStatsMenu.GetComponent<ObjectStatMenu>().ShowMenu = true;
                        GameManager.ActivePlayerCamera.transform.position = new Vector3(GameManager.ActivePlayer.transform.position.x, GameManager.ActivePlayerCamera.transform.position.y, GameManager.ActivePlayerCamera.transform.position.z);
                    }
                    else
                    {
                        GameManager.Itemmenu.GetComponent<ItemMenu>().UseItemFlag = false;
                    }
                }
            }
        }
    }

    public void MoveButton()
    {
        MenuFlag = false;
        GameManager.Movemenu.MoveFlag = true;
    }
    public void AttackButton()
    {
        MenuFlag = false;
        GameManager.AttackingMenu.GetComponent<AttackingMenu>().AttackingMenuFlag = true;
    }
    public void SkillButton()
    {
        Debug.Log("Used Skill");
    }
    public void DefendButton()
    {
        GameManager.ActivePlayer.GetComponent<Animator>().SetBool("DefendFlag", true);
        GameManager.ActivePlayer.GetComponent<BaseObject>().DefendFlag = true;
        GameManager.ActivePlayer.GetComponent<BaseObject>().Defending = true;
        MoveButtonActive.GetComponent<Button>().interactable = false;
        AttackButtonActive.GetComponent<Button>().interactable = false;
        SkillsButtonActive.GetComponent<Button>().interactable = false;
        DefendButtonActive.GetComponent<Button>().interactable = false;
        ItemButtonActive.GetComponent<Button>().interactable = false;
        EquipmentButtonActive.GetComponent<Button>().interactable = false;
        Debug.Log("Used Defend");
    }
    public void ItemButton()
    {
        MenuFlag = false;
        GameManager.Itemmenu.GetComponent<ItemMenu>().ItemMenuFlag = true;
    }
    public void EquipmentButton()
    {
        MenuFlag = false;
        GameManager.Equipmentmenu.GetComponent<EquipmentMenu>().EquipmentMenuFlag = true;
    }
    public void OptionsButton()
    {
        Debug.Log("Used Options");
    }
    public void EndTurnButton()
    {
        GameManager.PlayerTurnFlag = false;
        GameManager.ActivePlayer.GetComponent<BaseObject>().MoveFlag = false;
        GameManager.ActivePlayer.GetComponent<BaseObject>().AttackFlag = false;
        GameManager.ActivePlayer.GetComponent<BaseObject>().SkillsFlag = false;
        GameManager.ActivePlayer.GetComponent<BaseObject>().DefendFlag = false;
        GameManager.ActivePlayer.GetComponent<BaseObject>().EquipmentFlag = false;
        MoveButtonActive.GetComponent<Button>().interactable = true;
        AttackButtonActive.GetComponent<Button>().interactable = true;
        SkillsButtonActive.GetComponent<Button>().interactable = true;
        DefendButtonActive.GetComponent<Button>().interactable = true;
        ItemButtonActive.GetComponent<Button>().interactable = true;
        EquipmentButtonActive.GetComponent<Button>().interactable = true;
        TurnListMenu.GetComponent<TurnListMenu>().TurnList.Add(TurnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
        TurnListMenu.GetComponent<TurnListMenu>().TurnList.Remove(TurnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
       // GameManager.ActivePlayer = TurnListMenu.GetComponent<TurnListMenu>().TurnList[0];
        //TurnListMenu.GetComponent<TurnListMenu>().RefeshPlayerList();
        //  GameManager.ActivePlayer = TurnListMenu.GetComponent<TurnListMenu>().TurnList[0];
        MenuFlag = false;
    }
}
