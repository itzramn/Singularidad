using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    void Update()
    {
        //Para pausar y despausar la música con las teclas O/P
        if (Input.GetKeyDown(KeyCode.O)) ScriptMusica.Pausar();
        if (Input.GetKeyDown(KeyCode.P)) ScriptMusica.DesPausar();
    }
}
