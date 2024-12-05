using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour

{

  [SerializeField] private AudioSource audioSource;   
  [SerializeField] private string nomScene;   

  public void ChangeScene()
    { 
     SceneManager.LoadScene(nomScene);
      audioSource.Play();
    }
}
