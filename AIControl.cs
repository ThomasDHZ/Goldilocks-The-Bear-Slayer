using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {
    NavMeshAgent agent;
    public TurnListMenu turnListMenu;
    public Camera Cam;
    public Canvas ParentCanvus;
    public SystemManager Systemmanager;
    public GameObject TargetPlayer;
    public bool WakeUpFlag;
    public bool MovedFlag;
    public bool AttackRangeFlag;
    public bool AttackedFlag;
    int Damage;
    public bool AnimationFlag = false;
    public Text DamageText;
    public int MoveSpeed;
    public TurnListMenu TurnListMenu;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //  bool Systemmanager.ActivePlayer = gameObject;
        Debug.Log(Systemmanager.ActivePlayer.GetComponent<IDNum>().ID + " = " + gameObject.GetComponent<IDNum>().ID);
        if (Systemmanager.ActivePlayer.GetComponent<IDNum>().ID == gameObject.GetComponent<IDNum>().ID)
        {
            AttackRangeFlag = GetComponentInChildren<CheckAttackRange>().InRangeToAttack;
            if (WakeUpFlag == true)
            {

                if (MovedFlag == false)
                {
                    agent.SetDestination(TargetPlayer.transform.position);
                    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    MovedFlag = true;
               
                }

                if (MovedFlag == true && GetComponentInChildren<CheckAttackRange>().InRangeToAttack == true)
                {
                    AnimationFlag = true;
                    Damage = (GetComponent<BaseObject>().ATK - TargetPlayer.GetComponent<BaseObject>().DEF);
                    Damage = Random.Range(Damage - 100, Damage + 100);
                }
                else if (MovedFlag == true && GetComponentInChildren<CheckAttackRange>().InRangeToAttack == false)
                {
                    GetComponent<Animator>().SetBool("AttackFlag", true);
                    AttackedFlag = true;
                }

                if (AnimationFlag == true && GetComponent<Animator>().GetBool("AttackFlag") == false)
                {
                    if(Damage < 0)
                    {
                        Damage = 0;
                    }
                    TargetPlayer.GetComponent<Animator>().SetBool("DamageFlag", true);

                    TargetPlayer.GetComponent<BaseObject>().HP -= Damage;

                    DamageText.text = "Goldilocks has taken " + Damage + " damage!";

                    AttackedFlag = true;
                    TargetPlayer.GetComponent<Animator>().SetBool("DamageFlag", false);
                }

                if(MovedFlag == true && AttackedFlag == true)
                {
                    EndTurn();
                }
            }
            else
            {
                EndTurn();
            }
        }
    }
    void EndTurn()
    {
        TurnListMenu.GetComponent<TurnListMenu>().TurnList.Add(TurnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
        TurnListMenu.GetComponent<TurnListMenu>().TurnList.Remove(TurnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
        // turnListMenu.GetComponent<TurnListMenu>().TurnList.Add(turnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
        //  turnListMenu.GetComponent<TurnListMenu>().TurnList.Remove(turnListMenu.GetComponent<TurnListMenu>().TurnList[0]);
        // turnListMenu.GetComponent<TurnListMenu>().RefeshPlayerList();
        // Systemmanager.ActivePlayer = turnListMenu.GetComponent<TurnListMenu>().TurnList[0];
    }
    void OnTriggerStay(Collider collided)
    {
        if (collided.gameObject.tag == "Player")
        {
            WakeUpFlag = true;
        }
    }
    void OnTriggerExit(Collider collided)
    {
        if (collided.gameObject.tag == "Player")
        {
            WakeUpFlag = false;
        }
    }
}

