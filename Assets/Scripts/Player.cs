using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidad;
    public float salto;
    Rigidbody rb;
    bool grounded;
    bool canMove = true;
    public Timer timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = GameObject.FindObjectOfType<Timer>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }
    void Update()
    {
        Jump();
    }


    void Move()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + m_Input.normalized * Time.deltaTime * velocidad);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            rb.AddForce(new Vector3(0, salto, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC") {
            canMove = false;
            timer.pillado = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = false;
    }
}
