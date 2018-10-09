using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{

    public bool PlayerTurnFlag = true;
    public GameObject PlayerHovered;
    public GameObject ActivePlayer;
    public Camera ActivePlayerCamera;
    public Vector3 ActivePlayerCameraOffset;

    
    public TacticsMenu Tacticsmenu;
    public MoveMenu Movemenu;
    public GameObject PlayerStatsMenu;
    public GameObject EnemyStatsMenu;
    public TurnListMenu TurnListMenu;
    public GameObject AttackingMenu;
    public ItemMenu Itemmenu;
    public EquipmentMenu Equipmentmenu;

    public float CameraSpeed;

    public List<GameObject> ObjectList;
    public int PlayerCount;
    public int EnemyCount;
    public bool UsingController = false;

    public bool EnemyTurn;


    public float MouseWheel = 0;
	// Use this for initialization
	void Start ()
    {
        PlayerStatsMenu = GameObject.Find("SelectedPlayerPanel");
        EnemyStatsMenu = GameObject.Find("SelectedEnemyPanel");

        GameObject[] PlayerList = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        PlayerCount = PlayerList.Length;
        EnemyCount = EnemyList.Length;

        for (int x = 0; x <= PlayerList.Length - 1; x++)
        {
            ObjectList.Add(PlayerList[x]);
        }
        for (int x = 0; x <= EnemyList.Length - 1; x++)
        {
            ObjectList.Add(EnemyList[x]);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {


        // float MouseWheel = Input.GetAxis("Mouse ScrollWheel");
        // ActivePlayerCamera.transform.localPosition += new Vector3(0, MouseWheel, -MouseWheel) * Time.fixedDeltaTime;
        if (ActivePlayer.tag == "Enemy")
        {
            EnemyTurn = true;
        }
        else
        {
            EnemyTurn = false;
        }
        UpdatePlayerList();
        CheckForMouseHover();
    }
    void UpdatePlayerList()
    {
        ActivePlayer = TurnListMenu.TurnList[0];
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
//        float RotateCamera = Input.GetAxis("Rotate Camera"); //assigned but never used

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        ActivePlayerCamera.transform.position += movement * CameraSpeed;
      

        for (int x = 0; x <= ObjectList.Count -1; x++)
        {
            if(ObjectList[x] == null)
            {
                ObjectList.Remove(ObjectList[x]);
            }
        }

        if (PlayerCount == 0)
        {
           // SceneManager.LoadScene("GameOver");
        }
        else if (EnemyCount == 0)
        {
          //  SceneManager.LoadScene("NextLevel");
        }
    }
    void CheckForMouseHover()
    {
        if (Tacticsmenu.MenuFlag == false && AttackingMenu.GetComponent<AttackingMenu>().AttackingMenuFlag == false &&  Equipmentmenu.GetComponent<EquipmentMenu>().EquipmentMenuFlag == false)
        {
            PlayerStatsMenu.GetComponent<ObjectStatMenu>().Player = PlayerHovered;
        }
    }
}
