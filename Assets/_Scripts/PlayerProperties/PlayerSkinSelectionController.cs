﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSkinSelectionController : MonoBehaviour {
    private bool p1Ready;
    private bool p2Ready;
    private int p1Count = 0;
    private int p2Count = 0;
    [SerializeField]
    private Sprite[] p1SpriteArray;
    [SerializeField]
    private Sprite[] p2SpriteArray;
    [SerializeField]
    private Image player1SkinSelction;
    [SerializeField]
    private Image player2SkinSelction;
    [SerializeField]
    private Button p1PrevButton, p1NextButton;
    [SerializeField]
    private Button p2PrevButton, p2NextButton;
    [SerializeField]
    private Animator p1AnimationController;
    [SerializeField]
    private Animator p2AnimationController;
    [SerializeField]
    private Image p1Face;
    [SerializeField]
    private Image p2Face;
    [SerializeField]
    private Sprite happyFace;
    [SerializeField]
    private Sprite neutralFace;

    private void Start() {
        //Both player are not ready when the players first go to the skin selection screen
        p1Ready = false;
        p2Ready = false;
        p1Count = PlayerPrefs.GetInt("P1SkinID", 0);
        p2Count = PlayerPrefs.GetInt("P2SkinID", 0);
        player1SkinSelction.sprite = p1SpriteArray[p1Count];
        player2SkinSelction.sprite = p2SpriteArray[p2Count];
        p1AnimationController.SetInteger("SkinID", p1Count);
        p2AnimationController.SetInteger("SkinID", p2Count);
    }
    private void Update() {
        if(p1Ready == true && p2Ready == true) {
            SceneManager.LoadScene("Arena");
        }
    }
    public void p1SkinChoiceNext() {
        p1Count++;
        if(p1Count == 3) {
            p1Count = 0;
        }
        player1SkinSelction.sprite = p1SpriteArray[p1Count];
        p1AnimationController.SetInteger("SkinID", p1Count);
        PlayerPrefs.SetInt("P1SkinID", p1Count);
    }
    public void p2SkinChoiceNext() {
        p2Count++;
        if(p2Count == 3) {
            p2Count = 0;
        }
        player2SkinSelction.sprite = p2SpriteArray[p2Count];
        p2AnimationController.SetInteger("SkinID", p2Count);
        PlayerPrefs.SetInt("P2SkinID", p2Count);
    }
    public void p1SkinChoicePrev() {
        p1Count--;
        if (p1Count == -1) {
            p1Count = 2;
        }
        player1SkinSelction.sprite = p1SpriteArray[p1Count];
        p1AnimationController.SetInteger("SkinID", p1Count);
        PlayerPrefs.SetInt("P1SkinID", p1Count);
    }
    public void p2SkinChoicePrev() {
        p2Count--;
        if (p2Count == -1) {
            p2Count = 2;
        }
        player2SkinSelction.sprite = p2SpriteArray[p2Count];
        p2AnimationController.SetInteger("SkinID", p2Count);
        PlayerPrefs.SetInt("P2SkinID", p2Count);
    }
    public void player1ReadyButton(Image buttonImage) {
        p1Ready = !p1Ready;
        buttonImage.color = (p1Ready) ? Color.green : Color.white;
        p1PrevButton.interactable = !p1Ready;
        p1NextButton.interactable = !p1Ready;
        p1Face.sprite = (p1Ready) ? happyFace : neutralFace;
    }
    public void player2ReadyButton(Image buttonImage) {
        p2Ready = !p2Ready;
        buttonImage.color = (p2Ready) ? Color.green : Color.white;
        p2PrevButton.interactable = !p2Ready;
        p2NextButton.interactable = !p2Ready;
        p2Face.sprite = (p2Ready) ? happyFace : neutralFace;
    }
}
