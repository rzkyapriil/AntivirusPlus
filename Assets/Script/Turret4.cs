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
            animator.Play("BasofilExplode");
            collision.GetComponent<Enemy>().LoseHealthCustom();
            StartCoroutine(Boom());

        }
    }

    IEnumerator Boom()
    {
        
        yield return new WaitForSeconds(0.7f);
        
        Destroy(gameObject);
    }
}