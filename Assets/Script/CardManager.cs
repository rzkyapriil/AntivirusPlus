using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Canvas canvas;
    public GameObject actualTurret;
    public GameObject turretDragger;
    private GameObject turretDraggerInstance;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        turretDraggerInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        turretDraggerInstance = Instantiate(turretDragger, canvas.transform);
        turretDraggerInstance.transform.position = Input.mousePosition;
        turretDraggerInstance.GetComponent<TurretDragging>().card = this;

        gameManager.turretDrag = turretDraggerInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.PlaceTurret();
        GameManager.instance.turretDrag = null;
        Destroy(turretDraggerInstance);

    }
}