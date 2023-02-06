using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptMusica : MonoBehaviour
{
    AudioSource _audioSource;
    public static ScriptMusica inst; //Se crea una instancia para la pista de audio
    
    void Awake()
    {
        if (ScriptMusica.inst == null)
        {
            //primera vez. Esta es la instancia única
            ScriptMusica.inst = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
         
        else
        {    //Para que no se creen multiples instancias de la pista de audio
            //ya hay una instancia. Eliminar esta
            Destroy(gameObject);
        }
    }
    

     void Update ()
{
if(SceneManager.GetActiveScene().buildIndex == 0||SceneManager.GetActiveScene().buildIndex == 4||SceneManager.GetActiveScene().buildIndex == 5){
inst._audioSource.Pause();

}
else{inst._audioSource.UnPause();}


}
    public static void Pausar()
    {
        inst._audioSource.Pause();
    }

    public static void DesPausar()
    {
        inst._audioSource.UnPause();
    }
}
