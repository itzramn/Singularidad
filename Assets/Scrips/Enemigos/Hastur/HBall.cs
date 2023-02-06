using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    void Start()
    {
      transform.eulerAngles= new Vector3(0,180,0); 
     gameObject.GetComponent<SpriteRenderer>().flipX = true;
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right *Speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
        {
         if(other.gameObject.tag == "BallP1")
         {
             Destroy(gameObject);
         }
        }

}
