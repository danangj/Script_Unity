using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    float _secondsToWin = 180.0f;

    static bool _hasPlayerWon = false;
    public static bool HasPlayerWon {get{ return _hasPlayerWon;}}

    PlayerHealth _playerrHealth;

    public static void winPlayer(){
        _hasPlayerWon = true;
    }
    
    void Start () {
        Invoke ("CheckWin", _secondsToWin);

        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        _playerrHealth = player.GetComponent<PlayerHealth> ();
    }

    void CheckWin () {
        if (!_playerrHealth.isDeath ()) {
            _hasPlayerWon = true;
        }
    }
}
