using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logan : MonoBehaviour
{
     bool canSalto;
     public Rigidbody2D rg;
   void  Update()   
   {
       MoverPersonaje();
   }


  public void  MoverPersonaje()
   {
        if (Input.GetKey("left") )
        {
            rg.AddForce(new Vector2(-1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if (Input.GetKey("right")  )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false; //voltear el personaje
        }
       

        if (Input.GetKeyDown("space")&& canSalto) // cuando salte se ponga "true", para que no salte en el aire
        {
            canSalto = false;
           

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700f));// Fuerza de salto
            

            
        }
        
        if (Input.GetKey("f1"))
        {
             Application.Quit(); 
             
        }
        if (Input.GetKey("r")&&Input.GetKey("t") ) //Salir al menu
        {
             SceneManager.LoadScene("Menu");
             
        }
         if(!Input.GetKey("left") && !Input.GetKey("right"))
         {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            
        }
   }




}
