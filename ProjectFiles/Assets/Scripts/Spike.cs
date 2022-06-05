using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{

private Scene _scene;

private void Awake()
{
    _scene = SceneManager.GetActiveScene();
}

private void OnTriggerStay2D(Collider2D other)
{
    if(other.gameObject.CompareTag("Player"))
    {

        SceneManager.LoadScene(_scene.name);
    }
}

}
