using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseObject : MonoBehaviour {

    public RuntimeAnimatorController FistAnimatiorController;
    public RuntimeAnimatorController GreatSwordAnimatorController;
    public bool MoveFlag = false;
    public bool AttackFlag = false;
    public bool SkillsFlag = false;
    public bool DefendFlag = false;
    public bool EquipmentFlag = false;

    public bool Defending = false;

    public GameObject GameManager;
    public float PlayerSpeed;
    public GameObject CharWeapon;
    public Sprite PlayerImage;
    public string Name = "";
    public int Level = 1;
    public int MaxHP = 0;
    public int MaxMP = 0;
    public int HP = 0;
    public int MP = 0;
    public int ATK = 0;
    public int DEF = 0;
    public int INT = 0;
    public int RES = 0;
    public int SPD = 0;
    public int EVD = 0;
    public int MOV = 0;
    public int ATKRange = 1;
    public int EXP = 0;
    public int NextLevel = 0;
    public int ModMaxHP = 0;
    public int ModMaxMP = 0;
    public int ModATK = 0;
    public int ModDEF = 0;
    public int ModINT = 0;
    public int ModRES = 0;
    public int ModSPD = 0;
    public int ModEVD = 0;
    public int ModMOV = 0;
    public float GrowthRateHP = 0;
    public float GrowthRateMP = 0;
    public float GrowthRateATK = 0;
    public float GrowthRateDEF = 0;
    public float GrowthRateINT = 0;
    public float GrowthRateRES = 0;
    public float GrowthRateSPD = 0;
    public float GrowthRateEVD = 0;
    public float GrowthRateEXP = 0;

    public Equipment Weapon = new NoEquipment();
    public Equipment Armor = new LeatherArmor();
    public Equipment Helmet = new NoEquipment();
    public Equipment Shield = new NoEquipment();

    public bool StatsMenu = false;
    public bool ObjectSelectedFlag = false;

    public GameObject FloaterDamage;

    public bool WeaponShown = false;
    public GameObject Axe;

    public Text DamageText;
    // Use this for initialization
    void Start ()
    {

        if (gameObject.tag == "Enemy")
        {
            Level = Random.Range(1, 4);
            MaxHP = Random.Range(700,1300);
            MaxMP = Random.Range(600, 1100);
            ATK = Random.Range(500, 700);
            DEF = Random.Range(400, 700);
            INT = Random.Range(500, 800);
            RES = Random.Range(500, 600);
            SPD = Random.Range(300, 600);
            EVD = Random.Range(300, 500);
            EXP = Random.Range(300, 500);

            for (int x = 1; x < Level; x++)
            {
                MaxHP = Mathf.RoundToInt((float)MaxHP * 1.3f);
                MaxMP = Mathf.RoundToInt((float)MaxMP * 1.2f);
                HP = MaxHP;
                MP = MaxMP;
                ATK = Mathf.RoundToInt((float)ATK * 1.2f);
                DEF = Mathf.RoundToInt((float)DEF * 1.1f);
                INT = Mathf.RoundToInt((float)INT * 1.1f);
                RES = Mathf.RoundToInt((float)RES * 1.2f);
                SPD = Mathf.RoundToInt((float)SPD * 1.2f);
                EVD = Mathf.RoundToInt((float)EVD * 1.1f);
                EXP = Mathf.RoundToInt((float)EXP * 1.2f);
            }
            HP = MaxHP;
            MP = MaxMP;
        }
    }

    // Update is called once per frame
    List<Transform> FindGameObject()
    {
        List<Transform> ChildObjectList = new List<Transform>();
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int x = 0; x <= children.Length - 1; x++)
        {
            ChildObjectList.Add(children[x]);
        }
        return ChildObjectList;
    }
	void Update ()
    {
     
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        gameObject.transform.position += movement * PlayerSpeed;



        ModMaxHP = MaxHP + Weapon.EquipHP + Armor.EquipHP + Helmet.EquipHP + Shield.EquipHP;
        ModMaxMP = MaxMP + Weapon.EquipMP + Armor.EquipMP + Helmet.EquipMP + Shield.EquipMP;
        ModATK = ATK + Weapon.EquipATK + Armor.EquipATK + Helmet.EquipATK + Shield.EquipATK;
        ModDEF = DEF + Weapon.EquipDEF + Armor.EquipDEF + Helmet.EquipDEF + Shield.EquipDEF;
        ModINT = INT + Weapon.EquipINT + Armor.EquipINT + Helmet.EquipINT + Shield.EquipINT;
        ModRES = RES + Weapon.EquipRES + Armor.EquipRES + Helmet.EquipRES + Shield.EquipRES;
        ModSPD = SPD + Weapon.EquipSPD + Armor.EquipSPD + Helmet.EquipSPD + Shield.EquipSPD;
        ModEVD = EVD + Weapon.EquipEVD + Armor.EquipEVD + Helmet.EquipEVD + Shield.EquipEVD;
        ModMOV = MOV + Weapon.EquipMOV + Armor.EquipMOV + Helmet.EquipMOV + Shield.EquipMOV;
        if (tag == "Player")
        {
            if(Weapon is BattleAxe)
            {
                if (WeaponShown == false)
                {
                    foreach(Transform child in FindGameObject())
                    {
                        if (child.name == "WeaponHand")
                        {
                            WeaponShown = true;
                            GameObject Clone = Instantiate(Axe);
                            Clone.transform.parent = child.transform;
                            Clone.transform.localPosition = Vector3.zero;
                            Clone.transform.localRotation = new Quaternion(5,5,5,0);
                            Clone.transform.localScale = new Vector3(75, 75, 75);
                            GetComponent<Animator>().runtimeAnimatorController = GreatSwordAnimatorController;
                        }
                    }
                    
                }
            }
            else
            {
                WeaponShown = false;
                foreach (Transform child in FindGameObject())
                {
                    if(child.name == "GoldiAxe(Clone)")
                    if (child.name == "WeaponHand")
                    {
                            foreach (Transform child2 in FindGameObject())
                            {
                                if (child.name == "GoldiAxe(Clone)")
                                {
                                    Destroy(child2.GetChild(0).gameObject);
                                    GetComponent<Animator>().runtimeAnimatorController = FistAnimatiorController;
                                }
                            }
                    }
                }
            }
            if (EXP >= NextLevel)
            {
                LevelUp();
            }
        }
            if (HP <= 0)
        {
            GameManager.GetComponent<SystemManager>().TurnListMenu.GetComponent<TurnListMenu>().ObjectDestoryed(gameObject.name);
            if (tag == "Player")
            {
                GameManager.GetComponent<SystemManager>().PlayerCount -= 1;
            }
            else if (tag == "Enemy")
            {
                GameManager.GetComponent<SystemManager>().ActivePlayer.GetComponent<BaseObject>().EXP += EXP;
                GameManager.GetComponent<SystemManager>().EnemyCount -= 1;
            }
            DamageText.text = Name + " has died!";
            Destroy(gameObject);
//            int adsf = 234; //assigned but never used.
        }

	}
    void LevelUp()
    {
        EXP -= NextLevel;
        Level += 1;
        MaxHP = (int)(MaxHP * GrowthRateHP);
        MaxMP = (int)(MaxMP * GrowthRateMP);
        HP = MaxHP;
        MP = MaxMP;
        ATK = (int)(ATK * GrowthRateATK);
        DEF = (int)(DEF * GrowthRateDEF);
        INT = (int)(INT * GrowthRateINT);
        RES = (int)(RES * GrowthRateRES);
        SPD = (int)(SPD * GrowthRateSPD);
        EVD = (int)(EVD * GrowthRateEVD);
        NextLevel+= NextLevel * (int)GrowthRateEXP;
    }
    void OnMouseOver()
    {
        ObjectSelectedFlag = true;
      //  GameManager.GetComponent<SystemManager>().PlayerHovered = gameObject;
    }
    void OnMouseExit()
    {
        ObjectSelectedFlag = false;
      //  GameManager.GetComponent<SystemManager>().PlayerHovered = null;
    }
    void OnMouseDown()
    {
        if (GameManager.GetComponent<SystemManager>().Tacticsmenu.AttackFlag == true)
        {
            
            GameManager.GetComponent<SystemManager>().Tacticsmenu.DefendingPlayer = gameObject;
        }
        else if(GameManager.GetComponent<SystemManager>().Tacticsmenu.ItemMenuFlag == true)
        {
            GameManager.GetComponent<SystemManager>().Tacticsmenu.SelectedPlayer = gameObject;
        }
    }
    void OnMouseUp()
    {
    }
}
