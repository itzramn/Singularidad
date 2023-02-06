using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartilcesActive : MonoBehaviour
{
    public GameObject Particles;
    private void OnTriggerEnter2D(Collider2D other)
     {
         if(other.gameObject.tag =="Player")
         {
            Particles.SetActive(true);
         }
        
    }
}
