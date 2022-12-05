using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSplash : MonoBehaviour
{
    public float screenSplashTime = 5f;

    private void Start() {
        Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);

        StartCoroutine(ScreenSplashTime());
    }

    IEnumerator ScreenSplashTime()
    {
        yield return new WaitForSeconds(screenSplashTime);

        SceneManager.LoadScene("Mainmenu");
    }

}
