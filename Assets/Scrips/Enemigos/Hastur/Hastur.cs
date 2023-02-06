using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hastur : MonoBehaviour
{
     int vidaBoss = 0;
     public int Vida;
   public GameObject particulas;
    public AudioSource Damage;
    public AudioSource risaH1;
    public GameObject Bullet;
    public GameObject Bullet2;
    public GameObject pilar;
    public Transform BulletSapawner;
    public Transform BulletSapawner2;
     public Quaternion t = Quaternion.identity;
     public float laser = 70;
     public AI_BASIC vel;
     


private void OnTriggerEnter2D(Collider2D collision) 
        {
         if(collision.gameObject.tag == "BallP1")
         {
             Destroy(collision.gameObject);
        Damage.Play();
        Debug.Log("daño al ememigo");
        vidaBoss= vidaBoss + 1;
         }
        }




   
   void Update()
   {
      
        if (vidaBoss== Vida)
       {
          Destroy(pilar);
          Destroy(gameObject,5f);
           Debug.Log("enemigo derrotado");
       }
     if (vidaBoss== 12)
       { 
           vel.speed = 75f; 
          particulas.SetActive(true);
       }


          
   }

    void FixedUpdate()
     {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, laser);
        if(hit.collider!=null)
        {
            if(hit.collider.tag == "Player")
            {
                
               Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation);
               risaH1.Play();
               Debug.Log("golpe");
            }
        }
        Debug.DrawRay(transform.position, Vector2.left *laser, Color.red);

         RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right, laser);
        if(hit2.collider!=null)
        {
            if(hit2.collider.tag == "Player")
            {
                
               Instantiate(Bullet2,BulletSapawner2.position, BulletSapawner2.rotation);
               risaH1.Play();
               Debug.Log("golpe");
            }
        }
        Debug.DrawRay(transform.position, Vector2.right *laser, Color.blue);

    }
}
