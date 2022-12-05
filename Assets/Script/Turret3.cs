using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : Turret
{
    public override bool LoseHealth(int amount)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            turretContainer.isFull = false;
            return true;
        }
        else
        {
            animator.Play("tankositHurtIdle");
        }
        return false;
    }
}
