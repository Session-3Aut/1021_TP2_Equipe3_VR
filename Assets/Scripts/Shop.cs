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

    public void PurcahseLevel1Turret(){
        if(infosJoueur.nbPoints < 99){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("StandardTurret");
        buildManager.SetTurretToBuild(buildManager.artilleurPrefab);
        infosJoueur.nbPoints -= 100;
    }
    public void PurcahseLevel2Turret(){
        if(infosJoueur.nbPoints < 229){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.catapultorPrefab);
        infosJoueur.nbPoints -= 230;
    }
    public void PurcahseLevel3Turret(){
        if(infosJoueur.nbPoints < 299){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.lanceAracanePrefab);
        infosJoueur.nbPoints -= 300;
    }
    public void PurcahseLevel4Turret(){
        if(infosJoueur.nbPoints < 499){
            Debug.Log("Not enough Money");
            return;
        }
        Debug.Log("AnotherTurret");
        buildManager.SetTurretToBuild(buildManager.ecraseurPrefab);
        infosJoueur.nbPoints -= 500;
    }
}
