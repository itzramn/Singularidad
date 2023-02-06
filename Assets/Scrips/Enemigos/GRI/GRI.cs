using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRI : MonoBehaviour
{
     public float laser = 70f;
     public float laser2 = 70f;
    
    void Update()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, laser);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, laser2);
        if(hit.collider!=null)
        {
           
            if(hit.collider.tag == "Player")
            {
             gameObject.GetComponent<Animator>().SetBool("AtaqueGri", true); //llamar al "bool" y selecionar al estado quese quiere cambiar "true"
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
             
            }
           if(hit.collider.tag != "Player"){ gameObject.GetComponent<Animator>().SetBool("AtaqueGri", false);}
         
        }
         
        
        if(hit2.collider!=null)
        {
            if(hit2.collider.tag == "Player")
            {
                 gameObject.GetComponent<Animator>().SetBool("AtaqueGri", true); //llamar al "bool" y selecionar al estado quese quiere cambiar "true"
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
              
            }
             
             if(hit2.collider.tag != "Player"){ gameObject.GetComponent<Animator>().SetBool("AtaqueGri", false);}
        }
       
          
        
         
	


        Debug.DrawRay(transform.position, Vector2.left *laser, Color.red);
        Debug.DrawRay(transform.position, Vector2.right *laser2, Color.blue);

     }
}
