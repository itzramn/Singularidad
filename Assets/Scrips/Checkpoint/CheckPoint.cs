using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
public class GuardarPosicion : MonoBehaviour
{
    public float PosX;

    public float PosY;

    public Vector3 Position;

    void Start()
    {
        LoadDates();
    }

    public void savePosition()
    {
        PlayerPrefs.SetFloat("PosisionX", transform.position.x);
        PlayerPrefs.SetFloat("PosisionY", transform.position.y);
        Debug.Log("Datos Guardados Correctamente");
    }

    public void LoadDates()
    {
        PosX = PlayerPrefs.GetFloat("PosisionX", transform.position.x);
        PosY = PlayerPrefs.GetFloat("PosisionY", transform.position.y);
        Position.x = PosX;
        Position.y = PosY;
        transform.position = Position;
        Debug.Log("Datos cargados Correctamente");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Save")
        {
            savePosition();
        }
        
        if(col.tag == "Load")
        {
            LoadDates();
        }
    }
}
}
