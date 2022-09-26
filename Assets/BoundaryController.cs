using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    private Vector3 leftEdge, rightEdge, pos;
    // Start is called before the first frame update
    void Start()
    {
    leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
    rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
   
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>rightEdge.x){
            pos = transform.position;
            pos.x = rightEdge.x;
            transform.position = pos;
        }

        if(transform.position.x<leftEdge.x){
            pos = transform.position;
            pos.x = leftEdge.x;
            transform.position = pos;
        }
    }
}
