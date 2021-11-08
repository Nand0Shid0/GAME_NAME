using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    //Vector2 pos = posit
    private Rigidbody2D rb2d;
    Vector2 v2P;
    private float speed = (float)100.0;
    private Animator playerAnimator;
    float energy = (float)10.0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        v2P = new Vector2(movex, movey).normalized;

        playerAnimator.SetFloat("Horizontal", v2P.x);
        playerAnimator.SetFloat("Vertical", v2P.y);
        playerAnimator.SetFloat("Speed", v2P.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            StartCoroutine("Correr");

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StartCoroutine("Recuperar");
        }

    }

    IEnumerator Correr()
    {
        if (energy >= 1.0)
        {
            speed = (float)200.0;
            yield return new WaitForSeconds((float)0.5);
            energy -= (float)1.0;
            Debug.Log($"Gastando {energy}");
            StartCoroutine("Correr");
        }
        else if (energy <= 0)
        {
            
            StartCoroutine("Recuperar");
        }

      
    }

    IEnumerator Recuperar()
    {

        if (energy < 9.5)
        {
            speed = (float)100.0;
            yield return new WaitForSeconds((float)0.5);
            energy += (float)0.5;
            Debug.Log($"Recuperando {energy}");
            StartCoroutine("Recuperar");
        }

    }

    private void FixedUpdate()
    {

        rb2d.velocity = (v2P * speed * Time.fixedDeltaTime);

    }
}
