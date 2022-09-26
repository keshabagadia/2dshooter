using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonBreak : MonoBehaviour
{
    [Tooltip("The UIManager component which manages the current scene's UI")]
    public UIManager uiManager = null;
    [Tooltip("Page index in the UIManager to go to on breaking out of prison")]
    public int prisonBreakPageIndex = 3;
    [Tooltip("The effect to create upon winning the game")]
    public GameObject prisonBreakEffect;
    public GameObject redPlanet;
    private bool flag = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player"&&flag){
            flag = false;
            // Debug.Log("broke out of prison");
            uiManager.TogglePause2();
            uiManager.GoToPage(prisonBreakPageIndex);
            if (prisonBreakEffect!= null)
            {
                Instantiate(prisonBreakEffect, transform.position, transform.rotation, null);
            }
            if (redPlanet!= null)
            {
                redPlanet.SetActive(true);
            }
        }
    }

}
