using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour{
    SpriteRenderer rend;
    void Start(){
        rend = GetComponent<SpriteRenderer>();
        Color c = rend. material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    void Update(){
        StartCoroutine("FadeRoutine");
    }

    // IEnumerator FadeIn(){
    //     for(float f = 0.05f; f<=1; f+=0.05f){
    //         Color c = rend.material.color;
    //         c.a = f;
    //         rend.material.color = c;
    //         yield return new WaitForSeconds(0.05f);
    //     }
    // }

    IEnumerator FadeRoutine(){
        for(float f = 1f; f>=-0.05f; f-=0.05f){
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);

        for(float f = 0.05f; f<=1; f+=0.05f){
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    // public void startFadingIn(){
    //     StartCoroutine("FadeIn");
    // }

    // public void startFadingOut(){
    //     StartCoroutine("FadeOut");
    // }
}