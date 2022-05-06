using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jump = 300f;
    public GameObject playerBodyPrefab;
    private GameObject playerBody;
    private bool canJump;
    private Rigidbody2D _rb;
    public bool isGhost = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            jumpFunc();
        if (Input.GetKeyDown(KeyCode.Space))
            ghostMode();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,_rb.velocity.y);
    }

    private void jumpFunc()
    {
        if (canJump)
        {
            _rb.AddForce(new Vector2(0,jump));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            canJump = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            canJump = false;
        } 
    }

    private void ghostMode()
    {
        if (!isGhost)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,.5f);
            spawnBody(new Vector3(transform.position.x,transform.position.y,transform.position.z));
            isGhost = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            Destroy(playerBody);
            isGhost = false;
        }
    }

    private void spawnBody(Vector3 v)
    {
        playerBody = Instantiate(playerBodyPrefab, v, Quaternion.identity);
    }
}
