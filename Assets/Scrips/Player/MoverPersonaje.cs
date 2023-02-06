using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{

    public float VeloicidadP1; // en 1500 esta bien
    bool canSalto;
    public GameObject Bullet;
    public Transform BulletSapawner;
    public GameObject Bullet2;
    public Transform BulletSapawner2;
    public float fireRate=0.5f;
    float nextfire= 0.0f; //Variable para controlar los tiempos de disparo
    public float fireRate2=0.5f;
    float nextfire2= 0.0f;
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
    public GameObject PanelLost;
    public GameObject zonad1;
    public GameObject zonad2;
    public GameObject zonatrue;
   
     
      
   

    
    void Start()
    {
         Transform Posvida = PositionPrimerVida;
        for(int i = 0; i< CantVida; i++)
        {
          Image NewVida = Instantiate(vida,Posvida.position, t );
          NewVida.transform.parent = MyCanvas.transform;
          Posvida.position = new Vector2(Posvida.position.x + Offset, Posvida.position.y);
        }
        LoadDates();
    }
    
    void Update()
    {
        MovePlayer();
        ShootPlayer();
        if (CantVida <=0)
        {
              gameObject.GetComponent<Animator>().SetBool("dead", true);
             
             PanelLost.SetActive(true);
        }

    }
    
      public void ShootPlayer()
      {
        if (Input.GetKey("left")||Input.GetKey("right")) return;
          if (Input.GetKey("up")&&Input.GetKey("z")&& Time.time> nextfire)
        {
         gameObject.GetComponent<Animator>().SetBool("AttackT", true);
          nextfire = Time.time + fireRate;
         Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation); //instanciar la bala
         Shoot.Play();
        }
        if(!Input.GetKey("z"))
        {
          gameObject.GetComponent<Animator>().SetBool("AttackT", false);
        }
         if (Input.GetKeyDown("a")&& Time.time> nextfire2)
        {
         gameObject.GetComponent<Animator>().SetBool("Ray", true);
          nextfire2 = Time.time + fireRate2;
         Instantiate(Bullet2,BulletSapawner2.position, BulletSapawner2.rotation); //instanciar la bala
         Shoot.Play();
        }
        if(!Input.GetKey("a")&& Time.time> nextfire2)
        {
          gameObject.GetComponent<Animator>().SetBool("Ray", false);
        }
        
      }






    public void MovePlayer()
    {
        if (CantVida<=0) return;
        if (CantVida == 1){ tp.Play();}
         /*  if (Input.GetKey("up") )  //levitar
       {
        
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5000f * Time.deltaTime));
        }
        */
             
        if (Input.GetKey("left") )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-VeloicidadP1 * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true); //llamar al "bool" y selecionar al estado quese quiere cambiar "true"
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
           
        }
        if (Input.GetKey("right")  )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(VeloicidadP1 * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false; //voltear el personaje
        }
        if(!Input.GetKey("left") && !Input.GetKey("right"))// si no se mueven laflechgas = "false"
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            
           
        }
        // if (Input.GetKey("z"))
        // {
            
        // }

        if ( Input.GetKeyDown("space")&& canSalto) // cuando salte se ponga "true", para que no salte en el aire    Input.GetKeyDown("joystick button 0") ||
        {
            canSalto = false;
            gameObject.GetComponent<Animator>().SetBool("Jump", true); // llama ala animacion de salto
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800f));// Fuerza de salto
            jump.Play();

        }
        
        if (Input.GetKey("f1"))
        {
             Application.Quit(); 
             
        }
      
        
        

        // Botones de adroid
        if (right == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true);
                gameObject.GetComponent<SpriteRenderer>().flipX = false; //voltear el personaje
                Debug.Log("avanza");
            }
            if (left == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500f * Time.deltaTime, 0));
                gameObject.GetComponent<Animator>().SetBool("moving", true); //llamar al "bool" y selecionar al estado quese quiere cambiar "true"
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        // Botones de adroid
        }

        public void ReiniciarNivel()
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

      //Variables, Botones de Android
        public bool right =false;
        public bool left =false;
       
        
        public void Avanzarr()
        {
            right=true;
        }
        public void DejarAvanzarr()
        {
            right=false;
        }
        public void Retroceder()
        {
            left=true;
        }
        public void SalirRetroceder()
        {
            left=false;
        }
        public void Saltar()
        {
             canSalto = false;
            gameObject.GetComponent<Animator>().SetBool("Jump", true); // llama ala animacion de salto

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 700f));// Fuerza de salto
            jump.Play(); 
        }
        public void ShootA()
        {
            nextfire = Time.time + fireRate;
         Instantiate(Bullet,BulletSapawner.position, BulletSapawner.rotation); //instanciar la bala
        }
       

        //Variables, Botones de Android
    
      
      
      
      
    
     private void OnTriggerEnter2D(Collider2D collision) 
     {
         if (CantVida<=0) return;
        if (collision.gameObject.tag =="Enemy")// cuando choque con el enemigo, perdera una vida
        {
          Destroy(MyCanvas.transform.GetChild(CantVida + 1).gameObject);
          CantVida -= 1;
          StartCoroutine(cameraShake.Shake());
         //StartCoroutine(cameraShake2.Shake());
          hit.Play(); 
        }   
         if(collision.tag == "checkpoint")
        {
            savePosition();
        }
        if (collision.tag=="desctivarZona")
        {
            zonad1.SetActive(false);
            zonad2.SetActive(false);
            zonatrue.SetActive(true);
        }
       
     }
     
    
    
    private void OnCollisionEnter2D(Collision2D collision) //Detecta la collision 
    {
        // solo salta cuando esta en el suelo.
        if (collision.transform.tag =="PlatforM"||collision.transform.tag =="ground"||collision.transform.tag =="changeCam"||collision.transform.tag =="PlataformaMove"||collision.transform.tag =="camara3"||collision.gameObject.tag == "PlataformaMovible")
        {
           gameObject.GetComponent<Animator>().SetBool("Jump", false);  
             
            canSalto = true;
        }
       

        if (collision.transform.tag =="cambio")// este tag, espara cuando se quiera hacer un cambio de escena
        {
           SceneManager.LoadScene("Ciudad");
        }
        
        if (collision.gameObject.tag =="Enemy")// cuando choque con el enemigo, perdera una vida
        {
            if (CantVida<=0) return;
          Destroy(MyCanvas.transform.GetChild(CantVida + 1).gameObject);
          CantVida -= 1;
          StartCoroutine(cameraShake.Shake());
          ; 
         //StartCoroutine(cameraShake2.Shake());
          hit.Play();
         
          
        }
        
       
        if (collision.transform.tag =="PlataformaMove")
        {
           
         transform.parent = collision.transform;

        }
        if (collision.transform.tag =="PlatforM")
        {
           
         transform.parent = collision.transform;

        }
        
        if(collision.gameObject.tag == "PlataformaMovible")
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
         if (collision.transform.tag =="PlatforM")
        {
           
         transform.parent = null;

        }
         if(collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = null;
        }
       

        
        
    }

   /////////////////////////////////////
    public float PosX;

    public float PosY;
    int EscenaAct;
    public int a;
    public Vector3 Position;

    

    public void savePosition()
    {
        PlayerPrefs.SetFloat("PosisionX", transform.position.x);
        PlayerPrefs.SetFloat("PosisionY", transform.position.y);
        PlayerPrefs.SetInt("EscenaActual", SceneManager.GetActiveScene().buildIndex);
        //SceneManager.GetActiveScene().name
        Debug.Log("Datos Guardados Correctamente");
    }

    public void LoadDates()
    {
        PosX = PlayerPrefs.GetFloat("PosisionX", transform.position.x);
        PosY = PlayerPrefs.GetFloat("PosisionY", transform.position.y);
        EscenaAct = PlayerPrefs.GetInt("EscenaActual", 1);
        a = EscenaAct;
        Position.x = PosX;
        Position.y = PosY;
        transform.position = Position;
       
        Debug.Log("Datos cargados Correctamente");
    }


 public void BorrarPos()
	{
	PlayerPrefs.DeleteKey("PosisionX");
        PlayerPrefs.DeleteKey("PosisionY");
        PlayerPrefs.DeleteKey("PosisionX");
     
	}
     
    
      /////////////////////////////////////




}
