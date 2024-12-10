using UnityEngine;

public class Shop : MonoBehaviour
{
  
    BuildManager buildManager;  
    [SerializeField] private InfosJoueur infosJoueur;

    void Awake(){
        infosJoueur.nbPoints = 150;
    }
    void Start(){
        buildManager = BuildManager.instance;
    }

    public void PurcahseArtilleurTurret(){
        if(infosJoueur.nbPoints < 99){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("StandardTurret");
        buildManager.SetTurretToBuild(buildManager.artilleurPrefab);
    }
    public void PurcahseCatapultorTurret(){
        if(infosJoueur.nbPoints < 229){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.catapultorPrefab);
    }
    public void PurcahseLanceAracaneTurret(){
        if(infosJoueur.nbPoints < 299){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.lanceAracanePrefab);
    }
    public void PurcahseEcraseurTurret(){
        if(infosJoueur.nbPoints < 499){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.ecraseurPrefab);
    }
}
