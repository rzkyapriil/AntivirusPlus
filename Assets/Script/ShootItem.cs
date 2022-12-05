using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootItem : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float speed;
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
        if(collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        graphics.Rotate(new Vector3(0, 0, -speed*Time.deltaTime));
    }

    void Move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
