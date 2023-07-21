using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    int _maximumHealth = 100;

    int _currentHealth = 0;

    Renderer _renderer;

    public bool isDeath(){
        return _currentHealth <= 0;
    }

    PlayerStats _playerStats;
    
    public void Start () {
        _renderer = GetComponentInChildren<Renderer> ();
        _currentHealth = _maximumHealth;

        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        _playerStats = player.GetComponent<PlayerStats> ();
    }

    void Update(){
        if (isDeath() && !_renderer.isVisible) {
            Destroy (gameObject);
        }
    }

    public void Damage (int damageValue) {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0) {
            Animation anim = GetComponentInChildren<Animation> ();
            anim.Stop ();

            _playerStats.ZombieKilled++;
            EnemySpawnManager.onEnemyDeath ();
            Destroy(GetComponent<EnemyMovement>());
            Destroy (GetComponent<CharacterController> ());
            Destroy (gameObject, 8.0f);

            Ragdoll r = GetComponent<Ragdoll> ();
            if (r != null) {
                r.onDeath ();
            }
        }
    }
}