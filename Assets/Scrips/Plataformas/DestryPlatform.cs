using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryPlatform : MonoBehaviour
{
    public AudioSource sonido; 


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
       if (collision.transform.CompareTag("Player"))
       {
           gameObject.GetComponent<Animator>().SetBool("Destruir", true);
        sonido.Play();
        Destroy(gameObject, 0.6f);
       }
       else{
           gameObject.GetComponent<Animator>().SetBool("Destruir", false);
           }
   }
    

}
