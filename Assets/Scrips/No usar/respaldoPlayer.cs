using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class respaldoPlayer : MonoBehaviour
{
    bool canSalto;
    public GameObject Bullet;
    public Transform BulletSapawner;
    public float fireRate=0.5f;
    float nextfire= 0.0f; //Variable para controlar los tiempos de disparo
    public Quaternion t = Quaternion.identity;
    
    public CameraShake cameraShake;
//    public CameraShake cameraShake2;

    public Image vida ;
    public int CantVida;
    public RectTransform PositionPrimerVida;
    public Canvas MyCanvas;
    public int Offset;
     public AudioSource tp; 
     public AudioSource hit; 
     public AudioSource jump; 
     public AudioSource Shoot;
   
     
      
   

    
    void Start()
    {
         Transform Posvida = PositionPrimerVida;
        for(int i = 0; i< CantVida; i++)
        {
          Image NewVida = Instantiate(vida,Posvida.position, t );
          NewVida.transform.parent = MyCanvas.transform;
          Posvida.position = new Vector2(Posvida.position.x + Offset, Posvida.position.y);
        }
    }
    
    void Update()
    {
        MovePlayer();
        if (Input.GetKey("z")&& Time.time> nextfire )
        {
          nextfire = Time.time + fireRate;
         Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation); //instanciar la bala
        }
        
       
    }

   


    public void MovePlayer()
    {
         /*  if (Input.GetKey("up") )  //levitar
       {
        
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5000f * Time.deltaTime));
        }
        */
        if (Input.GetKey("left") )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true); //llamar al "bool" y selecionar al estado quese quiere cambiar "true"
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if (Input.GetKey("right")  )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false; //voltear el personaje
        }
        if(!Input.GetKey("left") && !Input.GetKey("right")&& !Input.GetKey("a"))// si no se mueven laflechgas = "false"
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("AttackT", false);
        }
        if (Input.GetKey("a")&& Input.GetKey("x"))
        {
            gameObject.GetComponent<Animator>().SetBool("AttackT", true);
        }

        if (Input.GetKeyDown("space")&& canSalto) // cuando salte se ponga "true", para que no salte en el aire
        {
            canSalto = false;
           gameObject.GetComponent<Animator>().SetBool("Jump", true); // llama ala animacion de salto

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700f));// Fuerza de salto
            jump.Play();

            
        }
        
        if (Input.GetKey("f1"))
        {
             Application.Quit(); 
             
        }
        if (Input.GetKey("r")&&Input.GetKey("t") ) //Salir al menu
        {
             SceneManager.LoadScene("Menu");
             
        }
        if(CantVida == 2)
        {
            tp.Play();
        }
        if (CantVida <=0)// cuando la vida sea =0 destruira a personaje y a al obejeto de la vida vida, ademas reiniciara la escena actual
        {
            
            Destroy(gameObject,0.5f);
            Destroy(vida);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }
      
      
    
   
    
    
    private void OnCollisionEnter2D(Collision2D collision) //Detecta la collision 
    {
        // solo salta cuando esta en el suelo.
        if (collision.transform.tag =="ground"||collision.transform.tag =="changeCam"||collision.transform.tag =="PlataformaMove"||collision.transform.tag =="camara3")
        {
           gameObject.GetComponent<Animator>().SetBool("Jump", false);  //cuando toca elsuelo no hara la animacion de salto
             
            canSalto = true;
        }
       

        if (collision.transform.tag =="cambio")// este tag, espara cuando se quiera hacer un cambio de escena
        {
           SceneManager.LoadScene("EdificiosN");
        }
        
        if (collision.gameObject.tag =="Enemy")// cuando choque con el enemigo, perdera una vida
        {
          Destroy(MyCanvas.transform.GetChild(CantVida + 1).gameObject);
          CantVida -= 1;
          StartCoroutine(cameraShake.Shake());
         //StartCoroutine(cameraShake2.Shake());
          hit.Play();

          
        }
       
        if (collision.transform.tag =="PlataformaMove")
        {
           
         transform.parent = collision.transform;

        }

    }
    private void OnCollisionExit2D(Collision2D collision) 
    {

        if (collision.transform.tag =="PlataformaMove")
        {
           
         transform.parent = null;

        }
        
    }
}
