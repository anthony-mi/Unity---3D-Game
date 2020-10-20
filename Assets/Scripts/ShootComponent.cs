using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public event Action<GameObject> ShotHit;

    public void Shoot(Vector3 position, Vector3 dir)
    {
        Ray ray = new Ray(position, Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            ShotHit?.Invoke(hit.collider.gameObject);
        }
    }
}
