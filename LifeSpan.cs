using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSpan : MonoBehaviour {
    public float BaseTimer;
    public float Timer;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            GetComponent<Text>().text = "";
            Timer = BaseTimer;
            int adf = 234;
        }
    }
}
