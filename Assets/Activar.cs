using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activar : MonoBehaviour
{
    public GameObject z;
    public GameObject z1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            z.SetActive(true);
            z1.SetActive(true);
        }
    }
}
