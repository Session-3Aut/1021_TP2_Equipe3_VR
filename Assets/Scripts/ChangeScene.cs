using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangementScene(string _nameScene)
    {
        SceneManager.LoadScene(_nameScene);
    }
}
