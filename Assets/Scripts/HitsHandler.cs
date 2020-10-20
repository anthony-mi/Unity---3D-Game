using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitsHandler : MonoBehaviour
{
    [SerializeField] ShootComponent shootComponent;
    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        shootComponent.ShotHit += ShootComponent_ShotHit;
    }

    private void ShootComponent_ShotHit(GameObject hitedObj)
    {
        Debug.Log("Shot hit");

        var enemy = hitedObj.GetComponent<EnemyController>();

        if(enemy == null)
        {
            return;
        }

        enemy.TakeDamage(playerController.GetDamage());

        Debug.Log($"Enemy health: {enemy.GetHealth()}");
    }
}
