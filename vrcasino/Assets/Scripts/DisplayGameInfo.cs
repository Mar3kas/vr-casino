using TMPro;
using UnityEngine;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    GameObject spawnedObject;
    TextMeshProUGUI betAmount;
    TextMeshProUGUI winnings;
    TextMeshProUGUI winningBet;
    Roulette roulette;

    private void Start()
    {
        roulette = GameObject.Find("roulette").GetComponent<Roulette>();
    }

    public void updateRouletteStandText()
    {
        betAmount.text = $"Bet Amount: {roulette.GetTotalPlaced()}";
        winnings.text = $"Won/Lost: {roulette.GetWinnings()}";
        winningBet.text = $"Won Bet: {roulette.GetWinningBet()}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (spawnedObject == null)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                spawnedObject = Instantiate(canvas, spawnPosition, transform.rotation);
            }

            spawnedObject.SetActive(true);

            betAmount = spawnedObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            winnings = spawnedObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            winningBet = spawnedObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

            updateRouletteStandText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnedObject.SetActive(false);
        }
    }
}
