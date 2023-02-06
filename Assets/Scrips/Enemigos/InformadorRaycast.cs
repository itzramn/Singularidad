using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformadorRaycast : MonoBehaviour
{
    void FixedUpdate()
     {
        float laser = 30f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, laser);
        if(hit.collider!=null)
        {
            if(hit.collider.tag == "Player")
            {

                
            Debug.Log("golpe");
            }
        }
        Debug.DrawRay(transform.position, Vector2.down *laser, Color.red);

     }
}
