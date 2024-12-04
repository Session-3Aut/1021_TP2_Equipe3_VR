using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] private float remainingTime;
        [SerializeField] private string SceneNom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        if(remainingTime > 0){
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0){
            remainingTime = 0;
        }
        if(remainingTime < 11){
            timerText.color = Color.green;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(remainingTime == 0){
            SceneManager.LoadScene(SceneNom);
        }
    
    }
}
