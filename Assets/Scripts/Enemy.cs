using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Base"))
    {
        Debug.Log("Entered trigger with House! Loading scene: " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}

}
