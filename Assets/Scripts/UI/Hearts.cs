using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public GameObject player;

    private int lives;
    private Health health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // void Awake(){
    //     health = 3;
    // }

    void Start(){
        Debug.Log(hearts.Length);
        health = player.GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if(player!=null){
            lives = health.currentLives;
        }else{
            lives =0;
        }
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < lives; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}