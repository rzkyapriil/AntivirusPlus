using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform graphics;
    public int health, damage;
    public float moveSpeed, rotateSpeed;
    public float attackInterval;
    Coroutine attackOrder;
    Turret detectedTurret;

    Timer timer;
    private object winPanel;

    void Update()
    {
        if(!detectedTurret)
        {
            Move();
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackInterval);
        FindObjectOfType<AudioManager>().PlayAudio("VirusEaten"); 
        attackOrder = StartCoroutine(Attack());
        //bool TowerDie = detectedTurret.LoseHealth(damage);
        if(detectedTurret)
        {
            detectedTurret.LoseHealth(damage);
        }
        else
        {
            detectedTurret = null;
            StopCoroutine(attackOrder);
            Move();
        }
    }

    void Move()
    {
        graphics.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        transform.Translate(-transform.right*moveSpeed*Time.deltaTime);
    }

    public void InflictDamage()
    {
        bool TowerDie = detectedTurret.LoseHealth(damage);

        if ( TowerDie )
        {
            detectedTurret = null;
            StopCoroutine(attackOrder);
        }
    }

    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator enemyDie()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    public void LoseHealthCustom()
    {
        StartCoroutine(enemyDie());
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            detectedTurret = collision.GetComponent<Turret>();
            attackOrder = StartCoroutine(Attack());
            return;
        }
        if(collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }        
    }

    public void showLosePanel()
    {
        timer.losePanel.SetActive(true);
    }
}
