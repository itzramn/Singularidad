using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    void Start()
    {
        transform.eulerAngles= new Vector3(180,0,0); // que la bala voltee su direccion al el eje "Y" // ojo, tambien hay que modificar la rotacion del RBody
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right *Speed * Time.deltaTime;
        Destroy(gameObject, 5f);
    }
void OnTriggerEnter2D(Collider2D other) 
    {
        
if (other.transform.tag== "changueCam")
       {
        Destroy(gameObject, 0.1f);
        
       }
    }


}
