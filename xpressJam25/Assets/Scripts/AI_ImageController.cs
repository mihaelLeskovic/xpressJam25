using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AI_ImageController : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;

    void LateUpdate()
    {
        image.sprite = sprites[GetSpriteNumber()];
    }

    int GetSpriteNumber()
    {

        return ActivityManager.Instance.taskCounter;
    }
}
