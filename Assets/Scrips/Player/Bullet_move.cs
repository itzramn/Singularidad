using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_move : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
       if (Input.GetKey("left") )
        {
            
            player.GetComponent<SpriteRenderer>().flipX = true;
            transform.eulerAngles= new Vector3(0,180,0);
            
        }
        if (Input.GetKey("right")  )
        {
           player.GetComponent<SpriteRenderer>().flipX = false; //voltear el personaje
            transform.eulerAngles= new Vector3(0,0,0);
        }
    }
}
