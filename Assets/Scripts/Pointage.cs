using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pointage : MonoBehaviour
{
    [SerializeField] private InfosJoueur _infosJoueur;
    [SerializeField] private TMP_Text _points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _points.text = _infosJoueur.nbPoints.ToString();
    }
}
