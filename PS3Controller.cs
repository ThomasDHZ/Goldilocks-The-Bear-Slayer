using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS3Controller : MonoBehaviour {
    public bool RoundToNextNumber = false;
    public float DPadXButton;
    public float DPadYButton;

    public float LeftStickXMove;
    public float LeftStickYMove;
    public float RightStickXMove;
    public float RightStickYMove;

    public bool L1Button;
    public bool R1Button;
    public float L2R2Button;
    public bool L3Button;
    public bool R3Button;

    public bool XButton;
    public bool OButton;
    public bool SquareButton;
    public bool TriangleButton;
    public bool MenuTriangleButton;

    public bool SelectButton;
    public bool StartButton;

    public bool ButtonDelay = false;
    public float ButtonDelayMaxTime = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	void Update ()
    {
        if (RoundToNextNumber == true)
        {
            DPadXButton = Mathf.Round(Input.GetAxis("PS3_DPadX"));
            DPadYButton = Mathf.Round(Input.GetAxis("PS3_DPadY"));

            LeftStickXMove = Mathf.Round(Input.GetAxis("PS3_LeftStickX"));
            LeftStickYMove = Mathf.Round(Input.GetAxis("PS3_LeftStickY"));
            RightStickXMove = Mathf.Round(Input.GetAxis("PS3_RightStickX"));
            RightStickYMove = Mathf.Round(Input.GetAxis("PS3_RightStickY"));

            L2R2Button = Mathf.Round(Input.GetAxis("PS3_L2R2"));
        }
        else
        {
            DPadXButton = Input.GetAxis("PS3_DPadX");
            DPadYButton = Input.GetAxis("PS3_DPadY");

            LeftStickXMove = Input.GetAxis("PS3_LeftStickX");
            LeftStickYMove = Input.GetAxis("PS3_LeftStickY");
            RightStickXMove = Input.GetAxis("PS3_RightStickX");
            RightStickYMove = Input.GetAxis("PS3_RightStickY");

            L2R2Button = Input.GetAxis("PS3_L2R2");
        }
        


        if (Input.GetButtonDown("PS3_L1"))
        {

                L1Button = true;
        }
        else if (Input.GetButtonUp("PS3_L1"))
        {
            L1Button = false;
            ButtonDelay = false;
        }
        if (Input.GetButtonDown("PS3_R1"))
        {
            R1Button = true;
        }
        else if (Input.GetButtonUp("PS3_R1"))
        {
            R1Button = false;
        }
        if (Input.GetButtonDown("PS3_L3"))
        {
            L3Button = true;
        }
        else if (Input.GetButtonUp("PS3_L3"))
        {
            L3Button = false;
        }
        if (Input.GetButtonDown("PS3_R3"))
        {
            R3Button = true;
        }
        else if (Input.GetButtonUp("PS3_R3"))
        {
            R3Button = false;
        }
        if (Input.GetButtonDown("PS3_X"))
        {
            XButton = true;
        }
        else if (Input.GetButtonUp("PS3_X"))
        {
            XButton = false;
        }
        if (Input.GetButtonDown("PS3_O"))
        {
            OButton = true;
        }
        else if (Input.GetButtonUp("PS3_O"))
        {
            OButton = false;
        }
        if (Input.GetButtonDown("PS3_Square"))
        {
            SquareButton = true;
        }
        else if (Input.GetButtonUp("PS3_Square"))
        {
            SquareButton = false;
        }
        if (Input.GetButtonDown("PS3_Triangle"))
        {
                TriangleButton = true;
                ButtonDelay = true;

        }
        else if (Input.GetButtonUp("PS3_Triangle"))
        {
            TriangleButton = false;
        }
        if (Input.GetButtonDown("PS3_Start"))
        {
            StartButton = true;
        }
        else if (Input.GetButtonUp("PS3_Start"))
        {
            StartButton = false;
        }
        if (Input.GetButtonDown("PS3_Select"))
        {
            SelectButton = true;
        }
        else if (Input.GetButtonUp("PS3_Select"))
        {
            SelectButton = false;
        }


    }
}
