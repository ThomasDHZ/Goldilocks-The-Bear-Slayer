using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentMenu : MonoBehaviour
{
    public SystemManager GameManger;
    public GameObject Player;
    public Text EquippedWeapon;
    public Text EquippedShield;
    public Text EquippedHelmet;
    public Text EquippedArmor;
    public Text MaxHP;
    public Text MaxMP;
    public Text ATK;
    public Text DEF;
    public Text INT;
    public Text RES;
    public Text SPD;
    public Text EVD;
    public Text MOV;
    public Text ATKRange;
    public Text ModMaxHP;
    public Text ModMaxMP;
    public Text ModHP;
    public Text ModMP;
    public Text ModATK;
    public Text ModDEF;
    public Text ModINT;
    public Text ModRES;
    public Text ModSPD;
    public Text ModEVD;
    public Text ModMOV;
    public Text ModATKRange;
    public Text EquipmentDesc;
    public bool EquipmentMenuFlag = false;
//    int XSpacing = 200; //assigned but never used
    public Vector2 testing = new Vector2(0, 0);
    public GameObject PlayerStats;
    Inventory Inven;
    Items.EquipmentType Equipmenttype;
    public string HoverWeaponNumber = "0";
    public int asd = 0;
    public Equipment HoveredWeapon = null;


    // Use this for initialization
    void Start()
    {
        Inven = GameManger.Itemmenu.GetComponent<Inventory>();
        GameManger.PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = Player;
    }

    // Update is called once per frame
    void Update()
    {

        if (EquipmentMenuFlag == false)
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
            Player = GameManger.ActivePlayer;
            GameManger.PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = Player;
            EquippedWeapon.text = Player.GetComponent<BaseObject>().Weapon.Name;
            EquippedArmor.text = Player.GetComponent<BaseObject>().Armor.Name;
            EquippedHelmet.text = Player.GetComponent<BaseObject>().Helmet.Name;
            EquippedShield.text = Player.GetComponent<BaseObject>().Shield.Name;
            MaxHP.text = Player.GetComponent<BaseObject>().ModMaxHP.ToString();
            MaxMP.text = Player.GetComponent<BaseObject>().ModMaxMP.ToString();
            ATK.text = Player.GetComponent<BaseObject>().ModATK.ToString();
            DEF.text = Player.GetComponent<BaseObject>().ModDEF.ToString();
            INT.text = Player.GetComponent<BaseObject>().ModINT.ToString();
            RES.text = Player.GetComponent<BaseObject>().ModRES.ToString();
            SPD.text = Player.GetComponent<BaseObject>().ModSPD.ToString();
            EVD.text = Player.GetComponent<BaseObject>().ModEVD.ToString();
            MOV.text = Player.GetComponent<BaseObject>().ModMOV.ToString();
            ATKRange.text = Player.GetComponent<BaseObject>().ATKRange.ToString();


           if(HoverWeaponNumber == "255")
            {
                ModMaxHP.text = Player.GetComponent<BaseObject>().MaxHP.ToString();
                ModMaxMP.text = Player.GetComponent<BaseObject>().MaxMP.ToString();
                ModATK.text = Player.GetComponent<BaseObject>().ATK.ToString();
                ModDEF.text = Player.GetComponent<BaseObject>().DEF.ToString();
                ModINT.text = Player.GetComponent<BaseObject>().INT.ToString();
                ModRES.text = Player.GetComponent<BaseObject>().RES.ToString();
                ModSPD.text = Player.GetComponent<BaseObject>().SPD.ToString();
                ModEVD.text = Player.GetComponent<BaseObject>().EVD.ToString();
                ModMOV.text = Player.GetComponent<BaseObject>().MOV.ToString();
                ModATKRange.text = Player.GetComponent<BaseObject>().ATKRange.ToString();
                CheckEquipmentStats(new NoEquipment());
            }
            else if(HoverWeaponNumber == "")
            {
                ModMaxHP.text = Player.GetComponent<BaseObject>().ModMaxHP.ToString();
                ModMaxMP.text = Player.GetComponent<BaseObject>().ModMaxMP.ToString();
                ModATK.text = Player.GetComponent<BaseObject>().ModATK.ToString();
                ModDEF.text = Player.GetComponent<BaseObject>().ModDEF.ToString();
                ModINT.text = Player.GetComponent<BaseObject>().ModINT.ToString();
                ModRES.text = Player.GetComponent<BaseObject>().ModRES.ToString();
                ModSPD.text = Player.GetComponent<BaseObject>().ModSPD.ToString();
                ModEVD.text = Player.GetComponent<BaseObject>().ModEVD.ToString();
                ModMOV.text = Player.GetComponent<BaseObject>().ModMOV.ToString();
                ModATKRange.text = Player.GetComponent<BaseObject>().ATKRange.ToString();

                ModHP.GetComponent<Text>().color = Color.white;
                ModMP.GetComponent<Text>().color = Color.white;
                ModATK.GetComponent<Text>().color = Color.white;
                ModDEF.GetComponent<Text>().color = Color.white;
                ModINT.GetComponent<Text>().color = Color.white;
                ModRES.GetComponent<Text>().color = Color.white;
                ModSPD.GetComponent<Text>().color = Color.white;
            }
            else if (Inven.ItemList[int.Parse(HoverWeaponNumber)] is Equipment)
            {
                Equipment equipment = (Equipment)Inven.ItemList[int.Parse(HoverWeaponNumber)];
                ModMaxHP.text = (Player.GetComponent<BaseObject>().MaxHP + equipment.EquipHP).ToString();
                ModMaxMP.text = (Player.GetComponent<BaseObject>().MaxMP + equipment.EquipMP).ToString();
                ModATK.text = (Player.GetComponent<BaseObject>().ATK + equipment.EquipATK).ToString();
                ModDEF.text = (Player.GetComponent<BaseObject>().DEF + equipment.EquipDEF).ToString();
                ModINT.text = (Player.GetComponent<BaseObject>().INT + equipment.EquipINT).ToString();
                ModRES.text = (Player.GetComponent<BaseObject>().RES + equipment.EquipRES).ToString();
                ModSPD.text = (Player.GetComponent<BaseObject>().SPD + equipment.EquipSPD).ToString();
                ModEVD.text = (Player.GetComponent<BaseObject>().EVD + equipment.EquipEVD).ToString();
                ModMOV.text = (Player.GetComponent<BaseObject>().MOV + equipment.EquipMOV).ToString();
                CheckEquipmentStats(equipment);
                //                ModATKRange.text = Player.GetComponent<BaseObject>().ATKRange + equipment.EquipHP;
            }

            if (int.Parse(HoverWeaponNumber) != 0 && int.Parse(HoverWeaponNumber) != 255)
            {
                EquipmentDesc.text = Inven.ItemList[int.Parse(HoverWeaponNumber)].Desc.ToString();
            }
            else
            {
                EquipmentDesc.text = "";
            }
        }
    }
    void OnGUI()
    {
        if (EquipmentMenuFlag == true)
        {

            GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
            BuildEquipmentList();
           HoverWeaponNumber = GUI.tooltip;

            GUI.EndGroup();
        }
    }
    public void BuildEquipmentList()
    {
        NoEquipment NotEquiped = new NoEquipment();
        int EquipmentID = 0;
        int x = 1;
        int y = 35;
        foreach (Items itemz in Inven.ItemList)
        {
            if(itemz is Equipment)//Checks if it Items is also Equipment.
            {
                Equipment equipment = (Equipment)itemz;//Downcast from Items to Equipment
                if (equipment.Type == Items.ItemType.Equipment)
                {
                    if (equipment.EquipType == Equipmenttype)
                    {
                        if (GUI.Button(new Rect(Screen.width * .1728f, (Screen.height * .325f), Screen.width * .16f, Screen.height * .05f), new GUIContent(NotEquiped.Name, "255")))
                        {
                            if (Equipmenttype == Items.EquipmentType.Weapon) Player.GetComponent<BaseObject>().Weapon = NotEquiped;
                            if (Equipmenttype == Items.EquipmentType.Armor) Player.GetComponent<BaseObject>().Armor = NotEquiped;
                            if (Equipmenttype == Items.EquipmentType.Helmet) Player.GetComponent<BaseObject>().Helmet = NotEquiped;
                            if (Equipmenttype == Items.EquipmentType.Shield) Player.GetComponent<BaseObject>().Shield = NotEquiped;
                        }
                        if (equipment.Amt > 0)
                        {
                            if (GUI.Button(new Rect(Screen.width * .1725f, (Screen.height * .275f) + (Screen.height * .05f) + (x * (Screen.height * .05f)), Screen.width * .16f, Screen.height * .05f), new GUIContent(equipment.Name, EquipmentID.ToString())))
                            {
                                if (equipment.EquipType == Items.EquipmentType.Weapon) Player.GetComponent<BaseObject>().Weapon = equipment;
                                if (equipment.EquipType == Items.EquipmentType.Armor) Player.GetComponent<BaseObject>().Armor = equipment;
                                if (equipment.EquipType == Items.EquipmentType.Helmet) Player.GetComponent<BaseObject>().Helmet = equipment;
                                if (equipment.EquipType == Items.EquipmentType.Shield) Player.GetComponent<BaseObject>().Shield = equipment;
                            }
                            y += 35;
                            x += 1;
                        }
                    }
                }
            }
            EquipmentID++;
        }
    }
    public void CheckEquipmentStats(Equipment equipment)
    {
        if (Player.GetComponent<BaseObject>().ModMaxHP < Player.GetComponent<BaseObject>().MaxHP + equipment.EquipHP)
        {
            ModHP.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModMaxHP > Player.GetComponent<BaseObject>().MaxHP + equipment.EquipHP)
        {
            ModHP.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModHP.GetComponent<Text>().color = Color.white;
        }


        if (Player.GetComponent<BaseObject>().ModMaxMP < Player.GetComponent<BaseObject>().MaxMP + equipment.EquipMP)
        {
            ModMP.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModMaxMP > Player.GetComponent<BaseObject>().MaxMP + equipment.EquipMP)
        {
            ModMP.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModMP.GetComponent<Text>().color = Color.white;
        }

        if (Player.GetComponent<BaseObject>().ModATK < Player.GetComponent<BaseObject>().ATK + equipment.EquipATK)
        {
            ModATK.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModATK > Player.GetComponent<BaseObject>().ATK + equipment.EquipATK)
        {
            ModATK.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModATK.GetComponent<Text>().color = Color.white;
        }

        if (Player.GetComponent<BaseObject>().ModDEF < Player.GetComponent<BaseObject>().DEF + equipment.EquipDEF)
        {
            ModDEF.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModDEF > Player.GetComponent<BaseObject>().DEF + equipment.EquipDEF)
        {
            ModDEF.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModDEF.GetComponent<Text>().color = Color.white;
        }

        if (Player.GetComponent<BaseObject>().ModINT < Player.GetComponent<BaseObject>().INT + equipment.EquipINT)
        {
            ModINT.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModINT > Player.GetComponent<BaseObject>().INT + equipment.EquipINT)
        {
            ModINT.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModINT.GetComponent<Text>().color = Color.white;
        }

        if (Player.GetComponent<BaseObject>().ModRES < Player.GetComponent<BaseObject>().RES + equipment.EquipRES)
        {
            ModRES.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModRES > Player.GetComponent<BaseObject>().RES + equipment.EquipRES)
        {
            ModRES.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModRES.GetComponent<Text>().color = Color.white;
        }

        if (Player.GetComponent<BaseObject>().ModSPD < Player.GetComponent<BaseObject>().SPD + equipment.EquipSPD)
        {
            ModSPD.GetComponent<Text>().color = Color.green;
        }
        else if (Player.GetComponent<BaseObject>().ModSPD > Player.GetComponent<BaseObject>().SPD + equipment.EquipSPD)
        {
            ModSPD.GetComponent<Text>().color = Color.red;
        }
        else
        {
            ModSPD.GetComponent<Text>().color = Color.white;
        }

//        int asdf = 234;	//assigned but never used in multiple scripts??
    }
    public void SearchEquipmentType(Items.EquipmentType choice)
    {
        Equipmenttype = choice;
    }
    public void WeaponButton()
    {
        Equipmenttype = Items.EquipmentType.Weapon;
    }
    public void ArmorButton()
    {
        Equipmenttype = Items.EquipmentType.Armor;
    }
    public void HelmetButton()
    {
        Equipmenttype = Items.EquipmentType.Helmet;
    }
    public void ShieldButton()
    {
        Equipmenttype = Items.EquipmentType.Shield;
    }
}
