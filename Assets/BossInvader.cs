using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInvader : MonoBehaviour
{
    private Vector3 _direction = Vector3.right;
    // public AnimationCurve speed = new AnimationCurve();
    public float speed = 1.5f;
    private void Update()
    {
        transform.position += _direction*speed*Time.deltaTime;
        
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

         foreach (Transform invader in transform)
        {
            // Skip any invaders that have been killed
            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            // Check the left edge or right edge based on the current direction
            if (invader.position.x >= (rightEdge.x - 1f))
            {
                speed = -speed;
                break;
            }
            else if (invader.position.x <= (leftEdge.x + 1f))
            {
                speed = -speed;
                break;
            }
        }
        
    }
}

