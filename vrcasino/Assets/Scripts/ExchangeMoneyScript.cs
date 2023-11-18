using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExchangeMoneyScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        wallet.Add(5, 0);
        wallet.Add(10, 0);
        wallet.Add(15, 0);
        wallet.Add(20, 0);
    }

    public void addToWallet(int amount)
    {
        if (player.getMoney() >= amount)
        {
            wallet[amount] += 1;
            changeTotalAmountTextField(amount);
            player.setMoney(player.getMoney() - amount);
            player.UpdatePlayerMoney();
        }
    }

    public void removeFromWallet(int amount)
    {
        if (wallet[amount] > 0)
        {
            wallet[amount] -= 1;
            changeTotalAmountTextField(amount);
            player.setMoney(player.getMoney() + amount);
            player.UpdatePlayerMoney();
        }
    }

    private void changeTotalAmountTextField(int amount)
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

    public void confirmMoneyExchange()
    {
        fiveUIAmount.text = "Total: 0";
        tenUIAmount.text = "Total: 0";
        fifteenUIAmount.text = "Total: 0";
        twentyUIAmount.text = "Total: 0";
        player.setWallet(wallet);
        wallet[5] = 0;
        wallet[10] = 0;
        wallet[15] = 0;
        wallet[20] = 0;

        if (playerChipText.IsActive() || playerCashText.IsActive())
        {
            player.UpdatePlayerChipText();
            player.UpdatePlayerMoney();
        }
    }
}
