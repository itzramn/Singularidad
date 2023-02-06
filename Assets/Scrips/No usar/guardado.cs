using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guardado : MonoBehaviour
{
    public Text textoPuntaje;
    public Text textoRecord;
    
    public int numPuntaje;


    // Start is called before the first frame update
    void Start()
    {
        numPuntaje = 0;
        textoRecord.text = PlayerPrefs.GetInt("PuntajeRecord",0).ToString(); //guardar el dato en una variable usanod playerprefs
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void aZar() //numero aleatorio
{
    numPuntaje=Random.Range(0,11);
    textoPuntaje.text = numPuntaje.ToString();
    if(numPuntaje >PlayerPrefs.GetInt("PuntajeRecord",0))
    {
        PlayerPrefs.SetInt("PuntajeRecord", numPuntaje);
        textoRecord.text= numPuntaje.ToString();
    }
}

public void borrar()
{
    PlayerPrefs.DeleteKey("PuntajeRecord");
    textoRecord.text= "0";
}

}
