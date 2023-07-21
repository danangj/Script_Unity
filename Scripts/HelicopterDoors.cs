using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterDoors : MonoBehaviour {

    void onCollisionEnter(Collider c){
        if (c.transform.root.tag == "Player") {
            GameManager.winPlayer ();
        }
    }
}