using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    public GameObject TP;
     
     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Player")
        {
            other.transform.position =TP.transform.GetChild(1).transform.position;
            //musica.Play(1);
        }
    }

}
