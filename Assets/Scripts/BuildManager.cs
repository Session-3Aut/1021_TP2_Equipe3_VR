using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject artilleurPrefab;
    public GameObject catapultorPrefab;
    public GameObject lanceAracanePrefab;
    public GameObject ecraseurPrefab;
    private GameObject turretToBuild;

    void Awake(){
        if(instance != null){
            Debug.Log("More than one BuildManager");
            return;
        }
        instance = this;
    }


    public GameObject GetTurretToBuild(){
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret){
        turretToBuild = turret;
    }
}
