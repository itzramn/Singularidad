using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
  public GameObject PantallaDecarga;
  public Slider Slider;
  public MoverPersonaje m;
  public int z;
  
     void Start() 
    {
      Debug.Log("hello");
      m.LoadDates();
       z = m.a;
    }


    public void PlayGame()
    {
      StartCoroutine(CargarAsyc());
    }
    
    IEnumerator CargarAsyc()
    {
       PantallaDecarga.SetActive(true);
      AsyncOperation Operacion = SceneManager.LoadSceneAsync(z); //cargar escena sin quitar recursos a la escena actual
      while(!Operacion.isDone)
      {
        float Progreso = Mathf.Clamp01(Operacion.progress / .9f);
        Slider.value = Progreso;
        yield return null;
      }
    }




     public void Quit()
     {
         Debug.Log("Salio de juego");
         Application.Quit();
     }

      
      public void play()
      {
        Debug.Log(z);
      }
      
       public void BorrarPos()
	{
	PlayerPrefs.DeleteKey("PosisionX");
        PlayerPrefs.DeleteKey("PosisionY");
        PlayerPrefs.DeleteKey("PosisionX");
     
	}


        public void borrarTodo(){  PlayerPrefs.DeleteAll();}

}
