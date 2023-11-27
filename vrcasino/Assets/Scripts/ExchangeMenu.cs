using UnityEngine;

public class ExchangeMenu : MonoBehaviour
{
    [SerializeField]
    private Canvas exchangeMenuCanvas;
    [SerializeField]
    private Canvas moneyExchangeMenuCanvas;
    [SerializeField]
    private Canvas chipExchangeMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        DisableMoneyExchangeMenuCanvas();
        DisableChipExchangeMenuCanvas();
    }

    void EnableExchangeMenuCanvas()
    {
        exchangeMenuCanvas.enabled = true;
    }

    void DisableExchangeMenuCanvas()
    {
        exchangeMenuCanvas.enabled = false;
    }

    void EnableMoneyExchangeMenuCanvas()
    {
        moneyExchangeMenuCanvas.enabled = true;
    }

    void DisableMoneyExchangeMenuCanvas()
    {
        moneyExchangeMenuCanvas.enabled = false;
    }

    void EnableChipExchangeMenuCanvas()
    {
        chipExchangeMenuCanvas.enabled = true;
        chipExchangeMenuCanvas.GetComponent<ExchangeChipScript>().SetInitialChipAmounts();
    }

    void DisableChipExchangeMenuCanvas()
    {
        chipExchangeMenuCanvas.enabled = false;
    }

    public void EnableMoneyExchangeMenu()
    {
        DisableExchangeMenuCanvas();
        EnableMoneyExchangeMenuCanvas();
    }

    public void EnableChipExchangeMenu()
    {
        DisableExchangeMenuCanvas();
        EnableChipExchangeMenuCanvas();
    }

    public void BackToExchangeMenu()
    {
        DisableChipExchangeMenuCanvas();
        DisableMoneyExchangeMenuCanvas();
        EnableExchangeMenuCanvas();
    }
}