using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Node : MonoBehaviour
{
    [SerializeField] private InputActionReference buttonSelect;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color defaultColor;

    private GameObject turret;
    private Renderer rend;

    BuildManager buildManager;

    void Start() {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnEnable() {
        buttonSelect.action.started += OnButtonSelectDown;
    }

    void OnDisable() {
        buttonSelect.action.started -= OnButtonSelectDown;
    }

    private void OnButtonSelectDown(InputAction.CallbackContext context) {
        if(buildManager.GetTurretToBuild() == null){
            return;
        }

        if (turret != null) {
            Debug.Log("Can't build here");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void HoverEnterEventArgs(){
        rend.material.color = hoverColor;
    }
    void HoverExitEventArgs(){
        rend.material.color = defaultColor;
    }
}