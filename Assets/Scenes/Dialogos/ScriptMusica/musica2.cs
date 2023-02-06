using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class musica2: MonoBehaviour
{
    AudioSource _audioSource;
    public static musica2 inst; //Se crea una instancia para la pista de audio
    
    void Awake()
    {
        if (musica2.inst == null)
        {
            //primera vez. Esta es la instancia única
            musica2.inst = this;
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
if(SceneManager.GetActiveScene().buildIndex == 0 ){
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

