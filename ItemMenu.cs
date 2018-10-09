using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemMenu : MonoBehaviour
{
    public SystemManager GameManager;
    public bool ItemMenuFlag;
    public GUISkin Skin;
    public string[] MenuText;
    public int LineSpacing = 35;
    public Items.ItemType SearchItemType = 0;
    public bool UseItemFlag = false;
    public string TagSearch = "";
    Inventory Inven;
    public string hover;

    public Items SelectedItem;
    public Items PointedItem;
  
    public Text DescText;
    public string DesctingText;
    // Use this for initialization
    void Start()
    {
       // MenuOverlay = GetComponent<InterfaceOverLays>().MenuOverLay;
        Inven = GetComponent<Inventory>();

//        int adf = 234; //assigned but never used mult scripts
    }
    // Update is called once per frame
    void Update()
    {

        if (ItemMenuFlag == false)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            ItemMenuFlag = false;
            UseItemFlag = false;
            SelectedItem = null;
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            if (hover != "")
            {
                GameManager.EnemyStatsMenu.GetComponent<ObjectStatMenu>().Player = GameManager.ObjectList[int.Parse(hover)];
            }
            else
            {
                GameManager.EnemyStatsMenu.GetComponent<ObjectStatMenu>().Player = null;
            }
        }
    }
    void OnGUI()
    {
        if (ItemMenuFlag == true)
        {
                GUI.skin = Skin;
                GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
                BuildItemList();
                DescText.text = GUI.tooltip;
            
                GUI.EndGroup();
            
            
            if (UseItemFlag == true)
            {
                DescText.text = "Select a player to use the item on.";
                BuildPlayerList();
            }
        }
    }
    public void BuildItemList()
    {
        bool LeftRight = false;
        int x = 0;
        float y = 0;
        foreach (Items Itemz in Inven.ItemList)
        {
            if (Itemz.Type == SearchItemType)
            {
                if (Itemz.Amt > 0)
                {
                    if (GUI.Button(new Rect((Screen.width * .125f) + (x * (Screen.width * .37f)), y, (Screen.width * .37f), Screen.height * .05f), new GUIContent(Itemz.Name + " x " + Itemz.Amt, Itemz.Desc)))
                    {
                        UseItemFlag = true;
                        SelectedItem = Itemz;
                        FindItemUsedType(SelectedItem.Usage);
                    }
                    if (LeftRight == true)
                    {
                        LeftRight = false;
                        x = 0;
                        y += Screen.height * .05f;
                    }
                    else
                    {
                        LeftRight = true;
                        x += 1;
                    }
                }
            }
        }
    }
    void BuildPlayerList()
    {
        GUIStyle Style;

        Style = new GUIStyle(GUI.skin.button);
        Style.hover.textColor = Color.cyan;
        int PlayerCount = 0; //If the tagsearch in the for loop doesn't equal the object tag, the count doesn't go up.
        
        for (int x = 0; x <= GameManager.GetComponent<SystemManager>().ObjectList.Count - 1; x++)
        {
            if (GameManager.GetComponent<SystemManager>().ObjectList[x].tag == TagSearch || TagSearch == "All")
            {
                if (GUI.Button(new Rect(Screen.width - (Screen.width * .15f), (PlayerCount * Screen.height * .05f), Screen.width * .15f, Screen.height * .05f), new GUIContent(GameManager.GetComponent<SystemManager>().ObjectList[x].GetComponent<BaseObject>().Name, x.ToString()), Style))
                {

                    UseItem(SelectedItem, GameManager.GetComponent<SystemManager>().ObjectList[x]);
                }
                PlayerCount++;
            }
        }
        hover = GUI.tooltip;
    }
    public void UseItem(Items ItemChoosen, GameObject Target)
    {
        Inven.UseItem(ItemChoosen, Target);   
        UseItemFlag = false;

        GameManager.Tacticsmenu.MoveButtonActive.GetComponent<Button>().interactable = false;
        GameManager.Tacticsmenu.AttackButtonActive.GetComponent<Button>().interactable = false;
        GameManager.Tacticsmenu.SkillsButtonActive.GetComponent<Button>().interactable = false;
        GameManager.Tacticsmenu.DefendButtonActive.GetComponent<Button>().interactable = false;
        GameManager.Tacticsmenu.ItemButtonActive.GetComponent<Button>().interactable = false;
        GameManager.Tacticsmenu.EquipmentButtonActive.GetComponent<Button>().interactable = false;

    }
    void SelectOption(int Selected)
    {
        //DefendingPlayer = GameManager.GetComponent<SystemManager>().ObjectList[Selected];
    }
    public void SearchItem(Items.ItemType Type)
    {
        SearchItemType = Type;
    }
    public void FindItemUsedType(Items.UsableTo itemtype)
    {
        if (itemtype == Items.UsableTo.Player)
        {
            TagSearch = "Player";
        }
        else if (itemtype == Items.UsableTo.Enemy)
        {
           TagSearch = "Enemy";
        }
        else
        {
            TagSearch = "All";
        }
    }
}
