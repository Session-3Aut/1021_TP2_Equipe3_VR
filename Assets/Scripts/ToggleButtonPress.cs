
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleButtonPress : MonoBehaviour
{
    public InputActionReference button;
    public GameObject objectToActivate;

    private void Awake()
    {
        button.action.performed += OnButtonPress;
    }

    private void OnDestroy()
    {
        button.action.performed -= OnButtonPress;

    }
    
    private void OnButtonPress(InputAction.CallbackContext context)
    {
        objectToActivate.SetActive(!objectToActivate.activeSelf);
    }
}
