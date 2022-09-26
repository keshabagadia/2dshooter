using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRedPlane : MonoBehaviour
{
    public GameManager gameManager;
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player"){
            // Debug.Log("broke out of prison");
            transform.Find("AudioSignal").gameObject.SetActive(false);
            gameManager.lvlCleared = true;
        }
    }

}
