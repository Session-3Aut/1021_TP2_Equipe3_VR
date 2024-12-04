using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnJoueur", menuName = "SO/Joueur")]
public class InfosJoueur : ScriptableObject
{
 
    [Header("Pointage total")]
    public int nbPoints;
}
