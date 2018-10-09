using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Items
{
    /*
    Mama Bear's Porridge : Restores 30% of the player's HP and MP.
    Papa Bear's Porridge : Restores 60% of the player's HP and MP.
Baby Bear's Porridge : Restores all of the player's HP and MP.







    Maybe berries for the HP healing items?







    Though what should we do the MP healing items...







    I've got it, let's go with candy as MP healing items.

    We'll use a BearClaw as the item that restores all of the player's MP
*/
    public enum EquipmentType
    {
        Weapon,
        Armor,
        Helmet,
        Shield,
        NumberOfEquipmentTypes
    }
    public enum ItemType
    {
        Useable,
        Equipment,
        Material,
        Key,
        NumberOfItemTypes
    }
    public enum UsableTo //Defines which objects the item can be used on.
    {
        Player,
        Enemy,
        All,
        None
    }
    public enum ItemList
    {
        Potion,
        HiPotion,
        Elixir,
        Gold,
        Silver,
        Bronze,
        BeastClaw,
        BoneHead,
        Iron,
        Stone,
        BronzeSword,
        LeatherArmor,
        SteelArmor,
        LeatherHelmet,
        LeatherShield,
        Key
}
    public ItemType Type;
    public UsableTo Usage; 
    public string Name;
    public string Desc;
    public int Amt = 0;
    public Items(ItemType type, UsableTo usage,  string name, string desc)
    {
        Type = type;
        Name = name;
        Desc = desc;
        Usage = usage;
    }
    virtual public void UseItem(GameObject Target)
    {
        if(Amt > 0)
        {
            Amt -= 1;
        }
    }
    virtual public void UseItem()
    {
        if (Amt > 0)
        {
            Amt -= 1;
        }
    }
    public void AddAMT()
    {
        Amt += 1;
    }
    public void AddAMT(int amt)
    {
        Amt += amt;
    }
    public string GetName()
    {
        return Name;
    }
    public string GetDesc()
    {
        return Desc;
    }
    public int GetAmt()
    {
        return Amt;
    }
  
}

[Serializable]
public class Equipment : Items
{
    public EquipmentType EquipType;
    public int EquipHP = 0;
    public int EquipMP = 0;
    public int EquipATK = 0;
    public int EquipDEF = 0;
    public int EquipINT = 0;
    public int EquipRES = 0;
    public int EquipSPD = 0;
    public int EquipEVD = 0;
    public int EquipMOV = 0;

    public Equipment(EquipmentType Equiptype, string EquipmentName, string EquipmentDesc) : base(ItemType.Equipment, UsableTo.None, EquipmentName, EquipmentDesc)
    {
        EquipType = Equiptype;
        Name = EquipmentName;
        Desc = EquipmentDesc;
    }
}
public class NoEquipment : Equipment
{
    public NoEquipment() : base(EquipmentType.Weapon, "None", "")
    {
    }
}

public class BattleAxe : Equipment
{
    public BattleAxe() : base(EquipmentType.Weapon, "Battle Axe", "For attacking")
    {
        base.EquipATK = 700;
    }
}
public class BronzeSword : Equipment
{
    public BronzeSword() : base(EquipmentType.Weapon, "Bronze Sword", "For attacking")
    {
        base.EquipATK= 30;
    }
}
public class LeatherArmor : Equipment
{
    public LeatherArmor() : base(EquipmentType.Armor, "Leather Armor", "Protects you")
    {
        base.EquipDEF = 30;
    }
}
public class SteelArmor : Equipment
{
    public SteelArmor() : base(EquipmentType.Armor, "Steel Armor", "Protects you")
    {
        base.EquipDEF = 35;
    }
}
public class LeatherHelmet : Equipment
{
    public LeatherHelmet() : base(EquipmentType.Helmet, "Leather Helmet", "Protects you")
    {
        base.EquipDEF = 10;
    }
}
public class LeatherShield : Equipment
{
    public LeatherShield() : base(EquipmentType.Shield, "LeatherShield", "Protects you")
    {
        base.EquipDEF = 4;
    }
}
public class Potion : Items
{
    public Potion() : base(ItemType.Useable, UsableTo.All, "Potion","Heals You")
    {

    }
    public override void UseItem(GameObject Target)
    {
        HealthCheck(Target);
    }
    private void HealthCheck(GameObject Target)
    {
        if (Target.GetComponent<BaseObject>().HP < Target.GetComponent<BaseObject>().MaxHP)
        {
            Target.GetComponent<BaseObject>().HP += 10;
            base.UseItem(Target);
        }
        if(Target.GetComponent<BaseObject>().HP > Target.GetComponent<BaseObject>().MaxHP)
        {
            Target.GetComponent<BaseObject>().HP = Target.GetComponent<BaseObject>().MaxHP;
        }
    }
}
public class HiPotion : Items
{
    public HiPotion() : base(ItemType.Useable, UsableTo.Player, "HiPotion", "Heals You more")
    {
    }
    public override void UseItem(GameObject Target)
    {
        HealthCheck(Target);
    }
    private void HealthCheck(GameObject Target)
    {
        if (Target.GetComponent<BaseObject>().HP < Target.GetComponent<BaseObject>().MaxHP)
        {
            Target.GetComponent<BaseObject>().HP += 20;
            base.UseItem(Target);
        }
        if (Target.GetComponent<BaseObject>().HP > Target.GetComponent<BaseObject>().MaxHP)
        {
            Target.GetComponent<BaseObject>().HP = Target.GetComponent<BaseObject>().MaxHP;
        }
    }
}
public class Elixir : Items
{
    public Elixir() : base(ItemType.Useable, UsableTo.Player, "Elixir", "Fully heals you.")
    {

    }
    public override void UseItem(GameObject Target)
    {
        if (Target.GetComponent<BaseObject>().HP < Target.GetComponent<BaseObject>().MaxHP)
        {
            Target.GetComponent<BaseObject>().HP = Target.GetComponent<BaseObject>().MaxHP;
            base.UseItem(Target);
        }
    }
}
public class Gold : Items
{
    public Gold() : base(ItemType.Material, UsableTo.None, "Gold", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class Silver : Items
{
    public Silver() : base(ItemType.Material, UsableTo.None, "Silver", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class Bronze : Items
{
    public Bronze() : base(ItemType.Material, UsableTo.None, "Bronze", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class BeastClaw : Items
{
    public BeastClaw() : base(ItemType.Material, UsableTo.None, "BeastClaw", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class BoneHead : Items
{
    public BoneHead() : base(ItemType.Material, UsableTo.None, "BoneHead", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class Iron : Items
{
    public Iron() : base(ItemType.Material, UsableTo.None, "Iron", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class Stone : Items
{
    public Stone() : base(ItemType.Material, UsableTo.None, "Stone", "For making stuff")
    {

    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}
public class Key : Items
{
    public Key() : base(ItemType.Key, UsableTo.None, "Key", "Opens Boxs")
    {
        
    }
    public override void UseItem(GameObject Target)
    {
        base.UseItem(Target);
    }
}