using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret4 : Turret
{
    public int damage;

    public void Init(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
    }
}