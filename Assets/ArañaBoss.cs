using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArañaBoss : MonoBehaviour
{
     
     public GameObject Bullet;
    public GameObject Bullet2;
  
    public Transform BulletSapawner;
    public Transform BulletSapawner2;


     public GameObject Particulas;

     int vidaAraña =0;
     public int VIDAS =19;

    public float laser=120;
    public float laser2=170;
     
    void FixedUpdate()
     {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, laser);
        if(hit.collider!=null)
        {
            if(hit.collider.tag == "Player")
            {  
                Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation);
               Debug.Log("izuierda");
               gameObject.GetComponent<SpriteRenderer>().flipX = true;
           
            }
        }
        Debug.DrawRay(transform.position, Vector2.left *laser, Color.red);

         RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, laser2);
        if(hit2.collider!=null)
        {
            if(hit2.collider.tag == "Player")
            {
                
               Instantiate(Bullet2,BulletSapawner2.position, BulletSapawner2.rotation);
            
               Debug.Log("derecha");
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        Debug.DrawRay(transform.position, Vector2.right *laser2, Color.blue);
       

    }

   ///// VIDA DE LA ARAÑA

      private void OnTriggerEnter2D(Collider2D other)
     {
           if (other.gameObject.tag =="BallP1")
           {
               Destroy(other.gameObject);
               vidaAraña = vidaAraña +1;
               Debug.Log(vidaAraña);
           }
      }

   void Update ()
   {
       if( vidaAraña == 4)
       {
           Particulas.SetActive(true);
       }
       if (vidaAraña== 9)
       {
           Particulas.SetActive(false);
           
       }
       if(vidaAraña == 9)
       {
           //Teleport
       }
        if(vidaAraña == 10)
       {
           //Teleport
       }
       if(vidaAraña == 12)
       {
           //Teleport
       }
        if(vidaAraña == 15)
       {
            
       }
       
       if(vidaAraña == VIDAS)
       {
           Destroy(gameObject, 2f);
       }




  }


}
