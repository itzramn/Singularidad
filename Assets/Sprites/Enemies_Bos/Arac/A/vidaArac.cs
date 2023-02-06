using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaArac : MonoBehaviour
{
      public GameObject fhather;
      public GameObject pos;
      public GameObject pos1;
     int vidaEnemy=0;
      public float vida;
      public GameObject particles;


    
  
   private void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.transform.CompareTag("BallP1"))
       {
        Destroy(collision.gameObject);
        vidaEnemy= vidaEnemy + 1;
        
       }
       
       if (vidaEnemy== vida)
       {
           particles.SetActive(true);   
           Destroy(gameObject);
           Destroy(pos);
           Destroy(pos1);
           Destroy(fhather, 3f);
       }
       
   }
}
