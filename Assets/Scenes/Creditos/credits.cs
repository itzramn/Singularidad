using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
    public int TimeS;

    public int NumEscena;
    void Start()
    {
        Invoke("tiempo", TimeS);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
     {
        SceneManager.LoadScene(NumEscena);
      }
    }

    public void tiempo()
{SceneManager.LoadScene(NumEscena);
}


}
