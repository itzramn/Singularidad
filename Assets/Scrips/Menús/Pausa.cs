using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
   public GameObject Paneldepausa;

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Paneldepausa.SetActive(true);
        }
        
    }

    
    public void regresar()
    {
        Time.timeScale = 1;
        Paneldepausa.SetActive(false);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;

    }
 
 public void BorrarPos()
	{
	PlayerPrefs.DeleteKey("PosisionX");
        PlayerPrefs.DeleteKey("PosisionY");
        PlayerPrefs.DeleteKey("PosisionX");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
	}



  public void  pausarMusica(){   ScriptMusica.Pausar();}
  public void  despausarMusica(){ ScriptMusica.DesPausar();}


}
