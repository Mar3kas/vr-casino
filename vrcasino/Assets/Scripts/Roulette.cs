using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private DisplayGameInfo infoDisplay;
    [SerializeField]
    private AudioSource winAudioSource;
    [SerializeField]
    private AudioSource lossAudioSource;
    public Dictionary<string, int> bets = new Dictionary<string, int>();
    public Dictionary<string, int> winningMultipliers = new Dictionary<string, int>();
    private WheelSpinner wheelSpinner;
    private int winnings;
    string[] splitWinningCell = { };

    // Start is called before the first frame update
    void Start()
    {
        wheelSpinner = GetComponentInChildren<WheelSpinner>();
        loadMultipliers();
    }

    // Update is called once per frame
    void Update()
    {
        if (wheelSpinner.finishedSpinning)
        {
            wheelSpinner.finishedSpinning = false;
            calculateWinnings();
            infoDisplay.updateRouletteStandText();
            if (winnings == 0)
            {
                lossAudioSource.Play();
            }
            else
            {
                winAudioSource.Play();
            }
        }
    }

    private void loadMultipliers()
    {
        for (int i = 0; i < 37; i++)
        {
            winningMultipliers.Add("Table." + i, 35);
        }
        winningMultipliers.Add("red", 2);
        winningMultipliers.Add("black", 2);
        winningMultipliers.Add("even", 2);
        winningMultipliers.Add("odd", 2);
        winningMultipliers.Add("1To18", 2);
        winningMultipliers.Add("19To36", 2);
        winningMultipliers.Add("first12", 3);
        winningMultipliers.Add("second12", 3);
        winningMultipliers.Add("third12", 3);
    }

    private void calculateWinnings()
    {
        winnings = 0;
        winnings += calculateStraightUpWinnings();
        winnings += calculateColorWinnings();
        winnings += calculateEvenOddWinnings();
        winnings += calculateThirdsWinnings();
        winnings += calculateHalfWinnings();
        wheelSpinner.winningCell = "";
    }

    private int calculateStraightUpWinnings()
    {
        int winnings = 0;

        splitWinningCell = wheelSpinner.winningCell.Split(".");
        string number = splitWinningCell[1];

        foreach(KeyValuePair<string, int> kvp in bets)
        {
            if (kvp.Key.Split(".")[1].Equals(number))
            {
                winnings += kvp.Value * winningMultipliers[kvp.Key];
            }
        }

        return winnings;
    }

    private int calculateColorWinnings()
    {
        int winnings = 0;

        splitWinningCell = wheelSpinner.winningCell.Split(".");
        string color = splitWinningCell[2];

        foreach (KeyValuePair<string, int> kvp in bets)
        {
            if (kvp.Key.Split(".")[1].Equals(color))
            {
                winnings += kvp.Value * winningMultipliers[color];
            }
        }

        return winnings;
    }

    private int calculateEvenOddWinnings()
    {
        int winnings = 0;

        splitWinningCell = wheelSpinner.winningCell.Split(".");
        string evenOdd = int.Parse(splitWinningCell[1]) % 2 == 0 ? "even" : "odd";

        foreach (KeyValuePair<string, int> kvp in bets)
        {
            if (kvp.Key.Split(".")[1].Equals(evenOdd))
            {
                winnings += kvp.Value * winningMultipliers[evenOdd];
            }
        }

        return winnings;
    }

    private int calculateThirdsWinnings()
    {
        int winnings = 0;

        splitWinningCell = wheelSpinner.winningCell.Split(".");
        int number = int.Parse(splitWinningCell[1]);
        string third = "";

        if (number >= 1 && number <= 12)
        {
            third = "first12";
        }
        else if (number >= 13 && number <= 24)
        {
            third = "second12";
        }
        else if (number >= 25 && number <= 36)
        {
            third = "third12";
        }


        foreach (KeyValuePair<string, int> kvp in bets)
        {
            if (kvp.Key.Split(".")[1].Equals(third))
            {
                winnings += kvp.Value * winningMultipliers[third];
            }
        }

        return winnings;
    }

    private int calculateHalfWinnings()
    {
        int winnings = 0;

        splitWinningCell = wheelSpinner.winningCell.Split(".");
        int number = int.Parse(splitWinningCell[1]);
        string half = "";

        if (number >= 1 && number <= 18)
        {
            half = "1To18";
        }
        else if (number >= 19 && number <= 36)
        {
            half = "19To36";
        }


        foreach (KeyValuePair<string, int> kvp in bets)
        {
            if (kvp.Key.Split(".")[1].Equals(half))
            {
                winnings += kvp.Value * winningMultipliers[half];
            }
        }

        return winnings;
    }

    public int GetWinnings()
    {
        return winnings;
    }

    public int GetTotalPlaced()
    {
        int totalPlaced = 0;

        foreach (KeyValuePair<string, int> kvp in bets)
        {
            totalPlaced += kvp.Value;
        }

        return totalPlaced;
    }

    public string GetWinningBet()
    {
        string result = string.Join(" ", splitWinningCell.Skip(1));

        if (string.IsNullOrEmpty(result))
        {
            return "TBD";
        }

        return result;
    }
}
