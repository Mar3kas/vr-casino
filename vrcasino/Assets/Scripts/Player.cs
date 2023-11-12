using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI playerMoneyText;

    [SerializeField]
    int money;

    Dictionary<int, int> wallet = new Dictionary<int, int> ();

    // Start is called before the first frame update
    void Start()
    {
        playerMoneyText.text = "Cash: " + money;
        wallet.Add(5, 0);
        wallet.Add(10, 0);
        wallet.Add(15, 0);
        wallet.Add(20, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
