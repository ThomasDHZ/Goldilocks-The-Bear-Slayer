using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text DescriptionText;
    public string Description;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseOver()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        DescriptionText.GetComponent<Text>().text = Description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescriptionText.GetComponent<Text>().text = "";
    }
}
