using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinApplier : MonoBehaviour {
    public int PlayerID = 0;
    public SpriteRenderer PlayerSpriteObject;
    public PlayerSkinManager SkinManager;
    void Awake() {
        PlayerSpriteObject.sprite = SkinManager.GetSkinbyID(1, PlayerPrefs.GetInt("P1SkindID", 0));
    }
}
