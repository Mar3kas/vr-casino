using System.Collections.Generic;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> chips = new List<GameObject>();
    [SerializeField]
    Player player;

    bool isSpawned = false;
    Dictionary<int, int> wallet;
    List<GameObject> spawned = new List<GameObject>();

    float initialX = -8.07f;
    float initialY = 2.741f;
    float initialZ = 14.98f;

    float zOffset = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        wallet = player.GetWallet();
        if (other.CompareTag("Player") && !isSpawned)
        {
            isSpawned = true;
            SpawnChips();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isSpawned)
        {
            isSpawned = false;
            DestroySpawnedChips();
        }
    }

    private void SpawnChips()
    {
        foreach (var chip in chips)
        {
            int chipValue = chip.GetComponent<ChipSnapper>().GetChipValue();

            if (wallet.ContainsKey(chipValue))
            {
                int chipCount = wallet[chipValue];

                for (int i = 0; i < chipCount; i++)
                {
                    float spawnY = initialY + i * 0.15f;
                    GameObject spawnedChip = Instantiate(chip, new Vector3(initialX, spawnY, initialZ), Quaternion.identity);
                    spawned.Add(spawnedChip);
                }

                initialZ += zOffset;
            }
        }
    }

    public void DestroySpawnedChips()
    {
        foreach(var chip in spawned)
        {
            Destroy(chip);
        }
    }

    public List<GameObject> GetSpawnedChips()
    {
        return spawned;
    }
}