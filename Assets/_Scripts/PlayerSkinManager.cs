using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// manages skins on the player
/// </summary>
public class PlayerSkinManager : MonoBehaviour {
    public SkinIDReference[] SkinList;

    /// <summary>
    /// struct to hold skin ID information
    /// </summary>
    [Serializable]
    public struct SkinIDReference {
        public int PlayerID;
        public int ID;
        public Sprite Skin;

        public SkinIDReference(int pid, int id, Sprite s) {
            PlayerID = pid;
            ID = id;
            Skin = s;
        }
    }

    public Sprite GetSkinbyID(int pid, int ID) {
        foreach (var SkinIter in SkinList){
            if(SkinIter.PlayerID == pid && SkinIter.ID == ID) {
                return SkinIter.Skin;
            }
        }
        return null;
    }
}
