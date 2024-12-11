using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Node : XRBaseInteractable
{
    [SerializeField] private InputActionReference buttonSelect; // Input action for selection
    [SerializeField] private Color hoverColor; // Color when hovered
    [SerializeField] private Vector3 positionOffset; // Offset for turret placement
    private Color defaultColor;

    private GameObject turret; // Reference to the built turret
    private Renderer rend;

    private static Node activeNode; // Tracks the currently active node
    BuildManager buildManager;

 protected  void Start()
{
    base.Awake();
    rend = GetComponent<Renderer>();
    if (rend != null)
    {
        defaultColor = rend.material.color;
    }

    // Safely initialize BuildManager
    if (BuildManager.instance == null)
    {
        Debug.LogError("BuildManager instance is not initialized. Ensure there is a BuildManager in the scene.");
    }
    else
    {
        Debug.Log("BuildManager instance found and assigned.");
        buildManager = BuildManager.instance;
    }
}
    protected override void OnEnable()
    {
        base.OnEnable();
        buttonSelect.action.started += OnButtonSelectDown;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        buttonSelect.action.started -= OnButtonSelectDown;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        activeNode = this; // Set this node as the active one
        if (rend != null)
        {
            rend.material.color = hoverColor; // Change color to hoverColor
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        if (activeNode == this)
        {
            activeNode = null; // Clear the active node if it was this one
        }
        if (rend != null)
        {
            rend.material.color = defaultColor; // Revert to the default color
        }
    }

    private void OnButtonSelectDown(InputAction.CallbackContext context)
    {
        // Ensure only the active node responds to the button press
        if (activeNode != this) return;

        // Check for a valid turret to build
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (turretToBuild == null)
        {
            Debug.Log("No turret selected in BuildManager.");
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build here: Node already has a turret.");
            return;
        }

        // Spawn the turret at the current node with positionOffset
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}