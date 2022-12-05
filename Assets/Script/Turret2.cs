using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : Turret
{
    public int damage;
    public float interval;
    public GameObject bulletPrefabs;

    protected override void Start()
    {
        StartCoroutine(ShootDelay());
    }

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
            animator.Play("LeukositHurtIdle");
        }
        return false;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        BulletPrefabs();
        StartCoroutine(ShootDelay());
    }

    void BulletPrefabs()
    {
        GameObject bulletItem = Instantiate(bulletPrefabs, transform);
        bulletItem.GetComponent<ShootItem>().Init(damage);
    }
}
