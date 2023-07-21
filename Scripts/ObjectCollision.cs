using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "ObjectCube"){
            Debug.Log("Collide!");
            AudioSource aud = gameObject.GetComponent<AudioSource> ();
            aud.Play();
            col.gameObject.SetActive(false);
        }
    }
}

