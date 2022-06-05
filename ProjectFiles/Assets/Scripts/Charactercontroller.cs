using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charactercontroller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    public GameObject playerBodyPrefab;
    private GameObject playerBody;
    private bool grounded;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sprite;
    public bool isGhost = false;
    [SerializeField] private AudioSource jumpSoundEffect;
   
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * speed,_rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.W) && grounded)
            jumpFunc();
        if (Input.GetKeyDown(KeyCode.Space))
            ghostMode();

            _animator.SetBool("walk", horizontalInput != 0);
            _animator.SetBool("grounded", grounded);

            if (horizontalInput > 0.01f)
            {
                _sprite.flipX = false;
            }
            else if (horizontalInput < -0.01)
            {
                _sprite.flipX = true;
            }
    }


    private void jumpFunc()
    {
        jumpSoundEffect.Play();
        _rb.velocity = new Vector2(_rb.velocity.x, jump);
        _animator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zemin")
        {
            grounded = true;
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

       //space'e basınca tag değişimi//
       if (isGhost)
       {
           transform.gameObject.tag = "Ghost";
       }
       else
       {
           transform.gameObject.tag = "Player";
           
       }
    }

    private void spawnBody(Vector3 v)
    {
        playerBody = Instantiate(playerBodyPrefab, v, Quaternion.identity);
    }

   
}
