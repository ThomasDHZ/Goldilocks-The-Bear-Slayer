using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public delegate void Item();


public class Inventory : MonoBehaviour {
   // public static Item BaseItem;
    public List<Items> ItemList = new List<Items>();
    // Use this for initialization
    void Awake()
    {

        AddItem(new Potion(), 2,false);
        AddItem(new HiPotion(), 1, false);
        AddItem(new Gold(), 0, false);
        AddItem(new Silver(), 0, false);
        AddItem(new Bronze(), 0, false);
        AddItem(new BeastClaw(), 0, false);
        AddItem(new BoneHead(), 0, false);
        AddItem(new Iron(), 0, false);
        AddItem(new Stone(), 0, false);
        AddItem(new Key(), 0, false);
        AddItem(new BattleAxe(), 1, false);
        AddItem(new BronzeSword(), 1, false);
        AddItem(new LeatherHelmet(), 1, false);
        AddItem(new LeatherShield(), 1, false);
        AddItem(new LeatherArmor(), 1, false);
        AddItem(new SteelArmor(), 1, false);
        AddItem(new Elixir(), 1, false);
    }
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	    foreach(Items items in ItemList)
        {
            /*if(items.Amt <= 0)
            {
                ItemList.
                (items);
                break;
            }*/
        }
	}
    public void AddItem(Items item, int ItemAMT = 1, bool ShowMessage = true)
    {
        bool FoundItem = false;

        foreach (Items itemlist in ItemList)
        {
            if (item.Name == itemlist.Name)
            {
                itemlist.Amt += ItemAMT;
                FoundItem = true;
                break;
            }
        }
        if (FoundItem == false)
        {
            item.Amt += ItemAMT;
            ItemList.Add(item);
        }
    }
    public void AddItem(Items.ItemList item, int ItemAMT = 1, bool ShowMessage = true)
    {
        foreach (Items Itemz in ItemList)
        {
            if (item.ToString() == Itemz.Name)
            {
                Itemz.Amt += ItemAMT;
            }
        }
    }
    public void UseItem(Items ItemChoosen, GameObject Target)
    {
        foreach(Items Itemz in ItemList)
        {
            if(ItemChoosen.Name == Itemz.Name)
            {
                Itemz.UseItem(Target);
            }
        }
    }
    public void UseItem(Items.ItemList ItemChoosen)
    {
        foreach (Items Itemz in ItemList)
        {
            if (ItemChoosen.ToString() == Itemz.Name)
            {
                Itemz.UseItem();
            }
        }
    }
    public List<Items> GetItemList()
    {
        return ItemList;
    }
}
