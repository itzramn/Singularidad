using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    float tiempo;
    public float Tiempodevida;
    public GameObject Objeto;

    // Update is called once per frame
    void Update()
    {
        tiempo+= Time.deltaTime;
        if(tiempo >=Tiempodevida)
        {
            Destroy(Objeto);
            Debug.Log("objeto destrudio");
        }
        

    }
}
