using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
      int vidaEnemy=0;
      public float vida;


    
  
   private void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.transform.CompareTag("BallP1"))
       {
        Destroy(collision.gameObject);
        vidaEnemy= vidaEnemy + 1;
        gameObject.GetComponent<Animator>().SetBool("hit", true);
       }
       else
       {
        gameObject.GetComponent<Animator>().SetBool("hit", false);
       }

       if (vidaEnemy== vida)
       {
           gameObject.GetComponent<Animator>().SetBool("hit", false);
           gameObject.GetComponent<Animator>().SetBool("muere", true);
           Destroy(gameObject, 3f);
       }
       
   }
}
