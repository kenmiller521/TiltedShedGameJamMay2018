using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerFaceChange : MonoBehaviour {
    public enum FaceType {
        idle,
        charge,
        hurt,
        miss
    }
    [Serializable]
    public struct FaceReference {
        public FaceType state;
        public Sprite face;

        public FaceReference(FaceType s, Sprite f) {
            state = s;
            face = f;
        }
    }

    public FaceReference[] Faces;
    public SpriteRenderer render;

    void Start() {
        render = GetComponent<SpriteRenderer>();
        
    }

    public void ChangeFace(int state) {
        foreach(var sp in Faces) {
            if((int)sp.state == state) {
                render.sprite = sp.face;
                break;
            }
        }
    }
}
