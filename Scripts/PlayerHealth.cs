using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    int _maximumHealth = 100;

    [SerializeField]
    Texture2D _crosshair;

    [SerializeField]
    Texture2D _gameOverImage;

    [SerializeField]
    Texture2D _winImage;

    public int _currentHealth = 0;
    Renderer _renderer;
    PlayerStats _playerStats;

    public string health () {
        return _currentHealth + " / " + _maximumHealth;
    }

    public bool isDeath(){
        return _currentHealth <= 0;
    }

    public void Start () {
        _renderer = GetComponentInChildren<Renderer> ();
        _currentHealth = _maximumHealth;
        _crosshair = new Texture2D (2, 2);
        _playerStats = GetComponent<PlayerStats> ();
    }

    void Update(){
        if (isDeath() && !_renderer.isVisible) {
            Destroy (gameObject);
        }
    }

    public void Damage (int damageValue) {
        _currentHealth -= damageValue;
        if (_currentHealth < 0) {
            _currentHealth = 0;
        }
        if (_currentHealth == 0) {
            Animation anim = GetComponentInChildren<Animation> ();
            anim.Stop ();
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<PlayerAnimation>());
            Destroy(GetComponentInChildren<LookX> ());
            Destroy(GetComponentInChildren<Rifle> ());

            Ragdoll r = GetComponent<Ragdoll> ();
            if (r != null) {
                r.onDeath ();
            }
        }
    }

    void OnGUI(){
        if (isDeath ()) {
            float x = (Screen.width - _gameOverImage.width) /2;
            float y = (Screen.height - _gameOverImage.height) / 2;
            GUI.DrawTexture (new Rect (x, y, _gameOverImage.width, _gameOverImage.height), _gameOverImage);
            GUI.Label (new Rect(x+100, y+200, 100,100), "Bertahan Hidup: "+_playerStats.ZombieKilled);
        } else if(GameManager.HasPlayerWon){
            float x = (Screen.width - _winImage.width) / 2;
            float y = (Screen.width - _winImage.height) / 2;
            GUI.DrawTexture (new Rect (x,y,_winImage.width, _winImage.height), _winImage);
            GUI.Label ( new Rect(x+100, y+200, 100,100), "Bertahan Hidup: "+_playerStats.ZombieKilled);
        } else {
            GUI.Label( new Rect( 5, 5, 100, 100 ), "Health: " + health() +" | Bertahan Hidup: "+_playerStats.ZombieKilled);
            float x = (Screen.width - _crosshair.width ) / 2;
            float y = (Screen.height - _crosshair.height ) / 2;
            GUI.DrawTexture( new Rect( x, y, _crosshair.width, _crosshair.height ), _crosshair);
        }
    }
}