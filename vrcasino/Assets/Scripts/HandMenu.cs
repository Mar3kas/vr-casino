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
    [SerializeField]
    private Canvas walletMenuCanvas;
    [SerializeField]
    private Player player;

    private InputAction menuInputAction;

    // Start is called before the first frame update
    void Start()
    {
        menuInputAction = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menuInputAction.Enable();
        menuInputAction.performed += toggleMenu;
        disableHandMenuCanvas();
        disableSettingsMenuCanvas();
        DisableWalletMenuCanvas();
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

    void EnableWalletMenuCanvas()
    {
        walletMenuCanvas.enabled = true;
    }

    void DisableWalletMenuCanvas()
    {
        walletMenuCanvas.enabled = false;
    }

    void toggleMenu(InputAction.CallbackContext context)
    {
        if (!handMenuCanvas.enabled && !settingsMenuCanvas.enabled && !walletMenuCanvas.enabled)
        {
            enableHandMenuCanvas();
        }
        else if (handMenuCanvas.enabled && !settingsMenuCanvas.enabled && !walletMenuCanvas.enabled)
        {
            disableHandMenuCanvas();
        }
        else if (!handMenuCanvas.enabled && settingsMenuCanvas.enabled && !walletMenuCanvas.enabled)
        {
            disableSettingsMenuCanvas();
        }
        else if (!handMenuCanvas.enabled && !settingsMenuCanvas.enabled && walletMenuCanvas.enabled)
        {
            DisableWalletMenuCanvas();
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

    public void EnableWalletMenu()
    {
        disableHandMenuCanvas();
        EnableWalletMenuCanvas();
        player.UpdatePlayerChipText();
    }

    public void backToHandMenu()
    {
        disableSettingsMenuCanvas();
        DisableWalletMenuCanvas();
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
