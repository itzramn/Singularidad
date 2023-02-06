using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Resolucion : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolotuionDorp;
    Resolution[] resoluciones; 

    void Start()
    {
        if(Screen.fullScreen)
        {
         toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        RevisarResolucion();
    }

   public void RevisarResolucion()
   {
       resoluciones = Screen.resolutions ;
       resolotuionDorp.ClearOptions();
       List<string> opciones = new List<string>();
       int ResolucionActual = 0;
      
       for( int i=0; i <resoluciones.Length; i++ )
       {
            string opcion =resoluciones [i].width + "x" + resoluciones [i].height;
            opciones.Add(opcion);
            
            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                ResolucionActual = i;
            }

       }
       
     resolotuionDorp.AddOptions(opciones);
     resolotuionDorp.value = ResolucionActual;
     resolotuionDorp.RefreshShownValue();
     resolotuionDorp.value = PlayerPrefs.GetInt("numeroResolucion", 0); 
   }
  public void CambiarResolucion(int indiceresolucion)
  {
    PlayerPrefs.SetInt("numeroResolucion", resolotuionDorp.value); 
   Resolution resolucion = resoluciones[indiceresolucion];
   Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
  }  
}
