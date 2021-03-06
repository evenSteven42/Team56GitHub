using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

private Scene _scene;
[SerializeField] private AudioSource nextLevelSoundEffect;


private void Awake()
{
    _scene = SceneManager.GetActiveScene();
}

private void OnTriggerStay2D(Collider2D other)
{
    if(other.gameObject.CompareTag("Player"))
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}

}
