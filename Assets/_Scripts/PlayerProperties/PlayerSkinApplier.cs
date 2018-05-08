using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinApplier : MonoBehaviour {
    public int PlayerID = 0;
    public Animator anim;
    void Start() {
        Debug.Log(PlayerPrefs.GetInt("P1SkinID"));
        Debug.Log(PlayerPrefs.GetInt("P2SkinID"));
        anim.SetInteger("SkinID", (PlayerID==1)?PlayerPrefs.GetInt("P1SkinID"): PlayerPrefs.GetInt("P2SkinID"));
        //PlayerSpriteObject.sprite = SkinManager.GetSkinbyID(1, PlayerPrefs.GetInt("P1SkindID", 0));
    }
}
