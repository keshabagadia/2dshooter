using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject[] asteroids;
    public GameManager gameManager;
    // public AudioSource powerUpAudio;
    void Start(){
        if (asteroids == null)
            asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            // powerUpAudio.Play();
            Pickup();
            gameManager.powerUpCollected = true;
            Destroy(gameObject);
        }
    }

    void Pickup(){
        Debug.Log("Power up picked up");
        foreach (GameObject asteroid in asteroids)
        {
           Health h = asteroid.GetComponent<Health>();
           h.isAlwaysInvincible = false;
           h.useLives = true;
           h.currentLives = 2;
        }
    }
}
