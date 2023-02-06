using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boss1 : MonoBehaviour
{
    int vidaBoss=0;
    public int Vida;
    public AudioSource Damage;
    public GameObject Bullet;
    public GameObject particulas;
    public GameObject particulas2;
    public GameObject puerta;
    public Transform BulletSapawner;
     public Quaternion t = Quaternion.identity;
     public float laser = 120f;
     
  private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.CompareTag("BallP1"))
       {
        Destroy(collision.gameObject);
        Damage.Play();
        vidaBoss= vidaBoss + 1;
       
       }
       if (vidaBoss== Vida)
       {
           Damage.Play();
          particulas.SetActive(true);
          Destroy(gameObject);
          Destroy(puerta);
          
       }
       if (vidaBoss== 10)
       {
           
          particulas2.SetActive(true);
       }
  }
   
   void Update()
   {
       //if (Input.GetKey("a")&& Time.time> nextfire )
        
           //instanciar la bala
        
   }

    void FixedUpdate()
     {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, laser);
        if(hit.collider!=null)
        {
            if(hit.collider.tag == "Player")
            {
                
               Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation);
               Debug.Log("golpe");
            }
        }
        Debug.DrawRay(transform.position, Vector2.down *laser, Color.red);

     }

}
