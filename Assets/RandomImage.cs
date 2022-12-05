using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour
{
    [SerializeField] Image currentImage;
    [SerializeField] Sprite[] sprites;

    private void Start()
    {
        currentImage.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
