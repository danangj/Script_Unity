using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    [SerializeField]
    float _secondsToLand = 180.0f;

    Animation anim;

    void Start(){
        anim = GetComponentInChildren<Animation>();
        anim ["Flying"].wrapMode = WrapMode.Loop;
        anim ["Landed"].wrapMode = WrapMode.ClampForever;
        anim ["Landing"].wrapMode = WrapMode.ClampForever;
        anim.Blend ("Landing", 1.0f, 0.01f);
        anim.Blend ("Flying", 1.0f, 0.01f);

        anim ["Landing"].speed = 0;
        Invoke ("Land", _secondsToLand);
    }

    public void Land(){
        anim ["Landing"].speed = 1;
    }

    void Update(){
        if (anim["Landing"].normalizedTime >= 1.0f) {
            anim.Blend ("Landed",1.0f, 0.01f);
        }
    }
}
