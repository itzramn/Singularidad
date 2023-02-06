using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool fisicass;
    public Animator anim;

    private void FixedUpdate()
    {

        Vector2 direction =Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        
        if (fisicass)
        {
            rb.AddForce(direction * velocidad * Time.fixedDeltaTime, ForceMode2D.Impulse);
            anim.SetBool("moving", true);
        }
        else
        {
            gameObject.transform.Translate(direction *velocidad *Time.deltaTime);
        }
    }
}
