using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerCashText;
    [SerializeField]
    TextMeshProUGUI playerChipText;
    [SerializeField]
    int money;

    Dictionary<int, int> wallet = new Dictionary<int, int> ();

    // Start is called before the first frame update
    void Start()
    {
        playerCashText.text = "Cash: " + money;
        wallet.Add(5, 0);
        wallet.Add(10, 0);
        wallet.Add(15, 0);
        wallet.Add(20, 0);
        UpdatePlayerChipText();
    }

    public void UpdatePlayerChipText()
    {
        playerChipText.text = "";

        foreach (var entry in wallet)
        {
            playerChipText.text += $"{entry.Key} chip: {entry.Value}\n";
        }
    }

    public void setWallet(Dictionary<int, int> source)
    {
        wallet = source;
        foreach (KeyValuePair<int, int> pair in wallet)
        {
            Debug.Log(pair.Key + ":" + pair.Value);
        }
    }

    public void setMoney(int money)
    {
        this.money = money;
    }

    public int getMoney()
    {
        return money;
    }
}
