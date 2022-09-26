using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    public GameManager gameManager;
private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy"){
            // Debug.Log("enemy entered");
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

}
