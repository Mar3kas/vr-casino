using UnityEngine;
using UnityEngine.InputSystem;

public class HandMenu : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;
    [SerializeField]
    private Canvas handMenuCanvas;
    [SerializeField]
    private Canvas settingsMenuCanvas;
    private InputAction menuInputAction;

    // Start is called before the first frame update
    void Start()
    {
        menuInputAction = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menuInputAction.Enable();
        menuInputAction.performed += toggleMenu;
        disableHandMenuCanvas();
        disableSettingsMenuCanvas();
    }

    void enableHandMenuCanvas()
    {
        handMenuCanvas.enabled = true;
    }

    void disableHandMenuCanvas()
    {
        handMenuCanvas.enabled = false;
    }

    void enableSettingsMenuCanvas()
    {
        settingsMenuCanvas.enabled = true;
    }

    void disableSettingsMenuCanvas()
    {
        settingsMenuCanvas.enabled = false;
    }

    void toggleMenu(InputAction.CallbackContext context)
    {
        if (!handMenuCanvas.enabled && !settingsMenuCanvas.enabled)
        {
            enableHandMenuCanvas();
        }
        else if (handMenuCanvas.enabled && !settingsMenuCanvas.enabled)
        {
            disableHandMenuCanvas();
        }
        else if (!handMenuCanvas.enabled && settingsMenuCanvas.enabled)
        {
            disableSettingsMenuCanvas();
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void enableSettingsMenu()
    {
        disableHandMenuCanvas();
        enableSettingsMenuCanvas();
    }

    public void backToHandMenu()
    {
        disableSettingsMenuCanvas();
        enableHandMenuCanvas();
    }

    public void applySettings()
    {
        //Logic to apply settings
        disableSettingsMenuCanvas();
        enableHandMenuCanvas();
    }

    private void OnDestroy()
    {
        menuInputAction = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menuInputAction.performed -= toggleMenu;
    }
}
