using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques : MonoBehaviour
{
   public GameObject Patada;
   bool patada;  
   void Update()
    {
        if(Input.GetKeyDown("x"))
        {
            pat();
           
        }
        
    }
    public void pat()
    {
        if(!patada)
        {
          StartCoroutine(patadaCo());
        }
    }
    IEnumerator patadaCo()
    {
        patada=true;
        Patada.SetActive(true);
      
        yield return new WaitForSeconds(0.3f);
        patada=false;
        Patada.SetActive(false);
        

    }
}
