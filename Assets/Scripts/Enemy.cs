using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;


private void OnCollisionEnter(Collision other)
{
    Debug.Log("Collision detected with: " + other.gameObject.name);
    if (other.gameObject.CompareTag("Base"))
    {
        Debug.Log("Entered trigger with House! Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
}
