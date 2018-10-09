using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackingMenu : MonoBehaviour
{
    public int ScreenH;
    public int ScreenW;

    public GameObject GoldilocksAttack;
    public Camera Cam;
    public SystemManager GameManager;
    public Canvas ParentObject;
    public CheckAttackRange GoldilocksAttackRange;
    public GameObject EnemyButton;
    public GameObject DefendingPlayer;

    public bool PlayerListBuildFlag;
    public bool AttackingMenuFlag;
    public bool AttackingFlag;
    public Vector2 MenuOffset;
    public string hover;
    public string TagSearch = "";
    public int LastSelected = -255;
    public Text HelpText;
    public Canvas ParentCanvus;
    public Text DamageText;
    public bool AnimationFlag = false;
    int Damage;

    public List<GameObject> EnemyList;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScreenH = Screen.height;
        ScreenW = Screen.width;
        if (AttackingMenuFlag == false)
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

            HelpText.text = "Choose a enemy to attack.";
            TagSearch = "Enemy";

            GameManager.PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = GoldilocksAttack;

            if (PlayerListBuildFlag == false)
            {
                // BuildPlayerList();
                PlayerListBuildFlag = true;
            }

            if (hover != "")
            {
                GameManager.EnemyStatsMenu.GetComponent<ObjectStatMenu>().Player = GoldilocksAttackRange.ObjectAttackList[int.Parse(hover)].gameObject;
            }
            else
            {
                GameManager.EnemyStatsMenu.GetComponent<ObjectStatMenu>().Player = null;
            }
            if (AttackingFlag == true)
            {
                SendAttackMessage();
                AttackingFlag = false;
            }
        }
        if (AnimationFlag == true)
        {
            DefendingPlayer.GetComponent<Animator>().SetBool("DamageFlag", true);

            DefendingPlayer.GetComponent<BaseObject>().HP -= Damage;

            DamageText.text = DefendingPlayer.GetComponent<BaseObject>().Name + " has taken " + Damage + " damage!";


            DefendingPlayer = null;
            AnimationFlag = false;
            AttackingMenuFlag = false;
            AttackingFlag = false;

            GameManager.Tacticsmenu.MoveButtonActive.GetComponent<Button>().interactable = false;
            GameManager.Tacticsmenu.AttackButtonActive.GetComponent<Button>().interactable = false;
            GameManager.Tacticsmenu.SkillsButtonActive.GetComponent<Button>().interactable = false;
            GameManager.Tacticsmenu.DefendButtonActive.GetComponent<Button>().interactable = false;
            GameManager.Tacticsmenu.ItemButtonActive.GetComponent<Button>().interactable = false;
            GameManager.Tacticsmenu.EquipmentButtonActive.GetComponent<Button>().interactable = false;
        }
    }
    void OnGUI()
    {
        if (AttackingMenuFlag == true)
        {
            GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
            BuildPlayerList();
            hover = GUI.tooltip;
            GUI.EndGroup();
        }
    }
    void BuildPlayerList()
    {
        GUIStyle Style;

        Style = new GUIStyle(GUI.skin.button);
        Style.hover.textColor = Color.cyan;
        int PlayerCount = 0; //If the tagsearch in the for loop doesn't equal the object tag, the count doesn't go up.

        foreach (GameObject enemy in GoldilocksAttackRange.ObjectAttackList)
        {
            if (enemy.tag == "Enemy")
            {
                if (GUI.Button(new Rect(Screen.width - (Screen.width * .15f), (PlayerCount * Screen.height * .05f), Screen.width * .15f, Screen.height * .05f), new GUIContent(enemy.GetComponent<BaseObject>().Name, PlayerCount.ToString()), Style))
                {
                    SelectOption(PlayerCount);
                }
                PlayerCount++;
            }
        }

    }
    public void SelectOption(int Selected)
    {
        AttackingFlag = true;
        DefendingPlayer = GoldilocksAttackRange.ObjectAttackList[Selected].gameObject;
    }
    void SendAttackMessage()
    {
        GoldilocksAttack.GetComponent<Animator>().SetBool("AttackFlag", true);
        AnimationFlag = true;

        Damage = (GoldilocksAttack.GetComponent<BaseObject>().ATK - DefendingPlayer.GetComponent<BaseObject>().DEF);
    }
}
