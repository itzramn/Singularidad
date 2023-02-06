using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArañaChild : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator; 

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;
    
    public AudioSource hitA;

    private float waitTime;

    public Transform[] moveSpots;

    private float starwaitTime;

    private int i = 0;

    private Vector2 actualPos;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag== "Player")
        {
            hitA.Play();
            

        }
    }


    void Start()
    {
        waitTime = starwaitTime; 
    }
    void Update()
    {
        StartCoroutine(CheckEnemymoving());


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed *Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i]!= moveSpots[ moveSpots.Length - 1])
                {
                    i++;
                }
                else { i = 0; }
                waitTime = starwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
     

   

    //comparar las pococciones y cambiar el eje "X"
    IEnumerator CheckEnemymoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f*Time.deltaTime);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < actualPos.x)
            {
                spriteRenderer.flipX = true;
            }
        
    }   
             
    
   










}
