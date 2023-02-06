using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_p1 : MonoBehaviour
{
    // public AudioSource DestruccionRay;
    private Rigidbody2D rb;
    public float Speed;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right *Speed * Time.deltaTime;
        Destroy(gameObject, 4f);
    }

    
      private void OnTriggerEnter2D(Collider2D other)
   {

       if (other.gameObject.tag!= null && other.gameObject.tag!="Player" )
       {
       
    //   DestruccionRay.Play();
        Debug.Log("destruccionBala");
        Destroy(gameObject,1.1f);
       }
   }

   
}
