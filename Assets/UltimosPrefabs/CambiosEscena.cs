using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiosEscena : MonoBehaviour
{

public int NumeroEscena;
  
 private void OnTriggerEnter2D(Collider2D collision)   
{
 if (collision.tag =="Player")
        {
           SceneManager.LoadScene(NumeroEscena);
        }


}
}
