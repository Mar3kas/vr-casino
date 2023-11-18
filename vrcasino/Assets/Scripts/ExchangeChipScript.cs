using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExchangeChipScript : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI playerChipText;

    [SerializeField]
    TextMeshProUGUI playerCashText;

    [SerializeField]
    TextMeshProUGUI fiveUIAmount;

    [SerializeField]
    TextMeshProUGUI tenUIAmount;

    [SerializeField]
    TextMeshProUGUI fifteenUIAmount;

    [SerializeField]
    TextMeshProUGUI twentyUIAmount;

    [SerializeField]
    Player player;

    Dictionary<int, int> wallet = new Dictionary<int, int>();
    int totalExchangeMoney = 0;

    // Start is called before the first frame update
    void Start()
    {
        wallet.Add(5, 0);
        wallet.Add(10, 0);
        wallet.Add(15, 0);
        wallet.Add(20, 0);
        SetWallet(player.GetWallet());

        for (int i = 1; i <= 4; i++)
        {
            ChangeTotalAmountTextField(i*5);
        }
    }

    public void SetWallet(Dictionary<int, int> source)
    {
        foreach (KeyValuePair<int, int> kvp in source)
        {
            wallet[kvp.Key] += kvp.Value;
        }
    }

    private void ChangeTotalAmountTextField(int amount)
    {
        switch (amount)
        {
            case 5:
                fiveUIAmount.text = "Total: " + wallet[amount];
                break;
            case 10:
                tenUIAmount.text = "Total: " + wallet[amount];
                break;
            case 15:
                fifteenUIAmount.text = "Total: " + wallet[amount];
                break;
            case 20:
                twentyUIAmount.text = "Total: " + wallet[amount];
                break;
        }
    }

    public void AddToWallet(int amount)
    {
        if (wallet[amount] < player.GetValue(amount))
        {
            wallet[amount] += 1;
            totalExchangeMoney -= amount;
            ChangeTotalAmountTextField(amount);
            player.UpdatePlayerChipText();
        }
    }

    public void RemoveFromWallet(int amount)
    {
        if (wallet[amount] > 0)
        {
            wallet[amount] -= 1;
            totalExchangeMoney += amount;
            ChangeTotalAmountTextField(amount);
            player.UpdatePlayerChipText();
        }
    }

    public void ConfirmChipExchange()
    {
        fiveUIAmount.text = "Total: " + player.GetValue(5);
        tenUIAmount.text = "Total: " + player.GetValue(10);
        fifteenUIAmount.text = "Total: " + player.GetValue(15);
        twentyUIAmount.text = "Total: " + player.GetValue(20);

        player.setWallet(wallet);
        player.setMoney(totalExchangeMoney);

        if (playerChipText.IsActive() || playerCashText.IsActive())
        {
            player.UpdatePlayerChipText();
            player.UpdatePlayerMoney();
        }
    }
}
