using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera MainCamera ;
    public AudioListener  MainAudio; 
    public Camera cam2 ;
    public AudioListener  Audio2; 
      public Camera cam3 ;
    public AudioListener  Audio3; 
     


    void Update()
    {

        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="ground")
        {
             cam2.enabled = false;
               Audio2.enabled =false;
               MainCamera.enabled = true;
               MainAudio.enabled= true;
        }
    }
    
     private void OnCollisionEnter2D(Collision2D collision) //Detecta la collision // solo salta cuando esta en el suelo.
    {
        
        
         if (collision.transform.tag =="ground")
        {
              MainCamera.enabled = true;
               MainAudio.enabled= true;
               cam2.enabled = false;
               Audio2.enabled =false;
               cam3.enabled = false;
               Audio3.enabled =false;
        }

       
        
        if (collision.transform.tag =="changeCam"||collision.transform.tag =="PlataformaMove")
        {
              cam2.enabled = true;
               Audio2.enabled =true;
               MainCamera.enabled = false;
               MainAudio.enabled = false;
               cam3.enabled = false;
               Audio3.enabled =false;
               
        }
        
        if (collision.transform.tag =="camara3")
        {
              cam3.enabled = true;
              Audio3.enabled =true; 
              MainCamera.enabled = false;
              MainAudio.enabled = false;
              cam2.enabled = false;
              Audio2.enabled =false;

        }

         


    }


}
