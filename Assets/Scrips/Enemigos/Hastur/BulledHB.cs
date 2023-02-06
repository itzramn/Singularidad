using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulledHB : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed;
    void Start()
    {
      transform.eulerAngles= new Vector3(0,0,0); 
    
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right *Speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }

}
