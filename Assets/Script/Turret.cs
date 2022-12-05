using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Animator animator;
    public int health;
    public int cost;
    public TurretContainer turretContainer;
    public GameManager gameManager;

    protected virtual void Start()
    {
    }

    public virtual bool LoseHealth(int amount)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            turretContainer.isFull = false;
            return true;
        }
        return false;
    }
}
