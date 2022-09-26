using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class moves the attached object in the direction specified
/// </summary>
public class DirectionalMover : MonoBehaviour
{
    [Header("Settings")]
    //[Tooltip("The direction to move in")]
    public Vector3 direction1 = Vector3.down;
    private Vector3 direction2;
    //private Vector3 direction3, direction4;

    [Tooltip("The speed to move at")]
    public float speed = 5.0f;
    // private bool flag = false;
    private int count = 0;


    void Start(){
        transform.position = new Vector3(-155,0,-10);
        direction2 = direction1;
        direction2[1] = -direction1[1];
        // direction3 = direction1;
        // direction3[0] = -direction1[0];
        // direction4 = direction3;
        // direction4[1] = -direction3[1];
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called every frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void Update()
    {
        if(transform.position.x<155&&transform.position.x>-156){
            if(count<50){
                Move(direction1);
            } else{
                Move(direction2);
            }
        } else{
            direction2[0]=-direction2[0];
            direction1[0]=-direction1[0];
            Move(direction1);
        //     if(count<50){
        //         Move(direction3);
        //     } else{
        //         Move(direction4);
        //     }

        }
    }

    /// <summary>
    /// Description:
    /// Moves this object the speed and in the direction specified
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void Move(Vector3 direction)
    {
        if(count<100){
            count ++;
        }else{
            count = 0;
        }
        transform.position = transform.position + direction.normalized * speed * Time.deltaTime;
    }
 
}
