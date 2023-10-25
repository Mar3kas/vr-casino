using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSnapper : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private bool positionSet = false;

    void Update()
    {
        if (!positionSet)
        {
            Collider nearestCollider = getNearestCollider();
            if (nearestCollider != null)
            {
                snapToColliderCenter(nearestCollider);
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BetCell"))
        {
            positionSet = false;
        }
    }
}
