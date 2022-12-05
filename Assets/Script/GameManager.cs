using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject turretDrag;
    public GameObject CurrentContainer;
    public GameObject currencyIcon;

    public HealthSystem healthSystem;
    public CurrencySystem currencySystem;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //GetComponent<HealthSystem>().Init();
        GetComponent<CurrencySystem>().Init();
        StartCoroutine(waveStartDelay());
    }

    IEnumerator waveStartDelay()
    {
        yield return new WaitForSeconds(4f);
        GetComponent<EnemySpawner>().StartSpawning();
    }


    public void PlaceTurret()
    {
        if (turretDrag != null && CurrentContainer != null && currencySystem.EnoughCurrency(5))
        {
            currencySystem.Use(5);
            Instantiate(turretDrag.GetComponent<TurretDragging>().card.actualTurret, CurrentContainer.transform);
            CurrentContainer.GetComponent<TurretContainer>().isFull = true;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneLoader.Load(sceneName);
    }

    public void ProgressLoadScene(string sceneName)
    {
        SceneLoader.ProgressLoad(sceneName);
    }

    public void ReplayScene()
    {
        SceneLoader.Reload();
    }
}
