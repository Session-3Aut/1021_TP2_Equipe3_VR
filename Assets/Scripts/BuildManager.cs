using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Make the BuildManager instance static to access it globally.
    public static BuildManager instance;

    public GameObject artilleurPrefab;
    public GameObject catapultorPrefab;
    public GameObject lanceAracanePrefab;
    public GameObject ecraseurPrefab;
    
    private GameObject turretToBuild;

void Awake() {
    if (instance != null && instance != this) {
        Destroy(gameObject); // Destroy duplicate BuildManager
        return;
    }
    instance = this;
    DontDestroyOnLoad(gameObject); // Keep BuildManager across scenes
    Debug.Log("BuildManager Initialized!");
}

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}