using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePartice : MonoBehaviour
{    public GameObject particles, Luz;
     public AudioSource checkConfirm; 


   private void OnTriggerEnter2D(Collider2D other)
   {

       if (other.gameObject.tag== "Player")
       {
           particles.SetActive(true);
           Luz.SetActive(true);
           checkConfirm.Play();
       }
   }


}
