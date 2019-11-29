using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject ActiveImage;
    public Sprite[] ControllerActives = new Sprite[4];
    public Button ControllerUp;
    public Button ControllerRight;
    public Button ControllerDown;
    public Button ControllerLeft;
    void Start()
    {


    }




    // Update is called once per frame
    void Update()
    {
        
    }
    public void doAction(string action)
    {
        ActiveImage.SetActive(true);
        switch (action)
        {
            case "up":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[0];
                break;
            case "right":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[1];
                break;
            case "down":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[2];
                break;
            case "left":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[3];
                break;
            default:
                break;
        }
    }
    public void cancelAction ()
    {
        ActiveImage.SetActive(false);
    }
}
