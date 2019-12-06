using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public PlayerLogic controller;
    public GameObject Player;
    private Animator PlayerAnimator;
    public GameObject ActiveImage;
    public Sprite[] ControllerActives = new Sprite[4];
    public float WalkingSpeed = 0.2f;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private bool isJumping = false;
    public bool AreControllsEnabled = true;
    void Start()
    {
        PlayerAnimator = Player.transform.GetChild(0).GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMovingLeft) controller.Move(-(WalkingSpeed*Time.fixedDeltaTime), false, false);
        if (isMovingRight) controller.Move(WalkingSpeed*Time.fixedDeltaTime, false, false);
        if (isJumping)
        {
            controller.Move(0, false, isJumping);
            isJumping = false;
        }
    }
    public void doAction(string action)
    {
        ActiveImage.SetActive(true);
        switch (action)
        {
            case "up":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[0];
                if (AreControllsEnabled) { 
                    PlayerAnimator.SetBool("IsJumping", true);
                    isJumping = true;
                }
                break;
            case "right":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[1];
                if (AreControllsEnabled)
                {
                    PlayerAnimator.SetBool("Right", true);
                    PlayerAnimator.SetBool("IsMoving", true);
                    isMovingRight = true;
                    PlayerAnimator.SetBool("Left", false);
                }
                break;
            case "down":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[2];
                break;
            case "left":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[3];
                if (AreControllsEnabled)
                {
                    PlayerAnimator.SetBool("Left", true);
                    PlayerAnimator.SetBool("IsMoving", true);
                    isMovingLeft = true;
                    PlayerAnimator.SetBool("Right", false);
                } 
                break;
            case "leftUp":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[3];
                if (AreControllsEnabled)
                {
                    PlayerAnimator.SetBool("Right", false);
                    PlayerAnimator.SetBool("IsJumping", true);
                    PlayerAnimator.SetBool("Left", true);
                    isJumping = true;
                    isMovingLeft = true;
                }
                break;
            case "rightUp":
                ActiveImage.GetComponent<Image>().sprite = ControllerActives[3];
                if (AreControllsEnabled)
                {
                    PlayerAnimator.SetBool("Left", false);
                    PlayerAnimator.SetBool("IsJumping", true);
                    PlayerAnimator.SetBool("Right", true);
                    isJumping = true;
                    isMovingRight = true;
                }
                break;
            default:
                break;
        }
    }
    public void cancelAction ()
    {
        if (AreControllsEnabled)
        {
            isMovingLeft = false;
            isMovingRight = false;
            ActiveImage.SetActive(false);
            PlayerAnimator.SetBool("IsMoving", false);
            PlayerAnimator.SetBool("IsJumping", false);
        }
    }
}
