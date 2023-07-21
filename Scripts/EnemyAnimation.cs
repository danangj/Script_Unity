using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
    Animation _animation;

    void Start() {
        _animation = GetComponentInChildren<Animation> ();

        string animationToPlay = "";
        switch (Random.Range (0, 3)) {
            case 0:
                animationToPlay = "Move1";
                break;
            case 1:
                animationToPlay = "Move2";
                break;
            case 2:
                animationToPlay = "Move3";
                break;
            default:
                animationToPlay = "Move1";
                break;
        }

        _animation ["Move1"].wrapMode = WrapMode.Loop;
        _animation.Play ("Move1");
        _animation ["Move1"].normalizedTime = Random.value;
    }
}