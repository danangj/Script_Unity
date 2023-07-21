using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    int _zombiekilled = 0;
    public int ZombieKilled {
        get{return _zombiekilled; }
        set{ _zombiekilled = value;}
    }
}