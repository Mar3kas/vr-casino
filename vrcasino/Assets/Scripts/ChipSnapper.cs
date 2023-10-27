using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSnapper : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private bool positionSet = false;
    [SerializeField]
    private int chipValue = 5;

    private Roulette roulette;

    private void Start()
    {
        roulette = GameObject.Find("roulette").GetComponent<Roulette>();
    }

    void Update()
    {
        if (!positionSet)
        {
            Collider nearestCollider = getNearestCollider();
            if (nearestCollider != null)
            {
                snapToColliderCenter(nearestCollider);
                addToBets(nearestCollider.gameObject.name);
                positionSet = true;
            }
        }
    }

    private Collider getNearestCollider()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.01f, layerMask);
        if (colliders.Length == 0)
        {
            return null;
        }
        Collider nearest = colliders[0];
        float nearestDistance = Vector3.Distance(transform.position, nearest.bounds.center);
        foreach (Collider collider in colliders)
        {
            float distance = Vector3.Distance(transform.position, collider.bounds.center);
            if (distance < nearestDistance)
            {
                nearest = collider;
                nearestDistance = distance;
            }
        }
        return nearest;
    }

    private void snapToColliderCenter(Collider collider)
    {
        Vector3 center = collider.bounds.center;
        transform.position = new Vector3(center.x, transform.position.y, center.z);
    }

    private void addToBets(string betCellName)
    {
        Debug.Log("Adding");
        if (!roulette.bets.ContainsKey(betCellName))
        {
            roulette.bets.Add(betCellName, chipValue);
        }
        else
        {
            roulette.bets[betCellName] = roulette.bets[betCellName] + chipValue;
        }
        foreach (KeyValuePair<string, int> kvp in roulette.bets)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }

    private void removeFromBets(string betCellName)
    {
        Debug.Log("Removing");
        if (roulette.bets[betCellName] - chipValue <= 0)
        {
            roulette.bets.Remove(betCellName);
        }
        else
        {
            roulette.bets[betCellName] = roulette.bets[betCellName] - chipValue;
        }
        foreach (KeyValuePair<string, int> kvp in roulette.bets)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BetCell"))
        {
            positionSet = false;
            removeFromBets(other.gameObject.name);
        }
    }
}
