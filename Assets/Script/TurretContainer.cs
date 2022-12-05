using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretContainer : MonoBehaviour
{
    public bool isFull;
    public GameManager gameManager;
    public Image backGroundImage;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.turretDrag != null & isFull == false && collision.gameObject.layer == 6)
        {
            gameManager.CurrentContainer = this.gameObject;
            backGroundImage.enabled = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.CurrentContainer = null;
        backGroundImage.enabled = false;
    }
}
