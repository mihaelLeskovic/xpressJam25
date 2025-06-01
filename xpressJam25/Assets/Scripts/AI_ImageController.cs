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
        //dohvati pomocu sanityja
        float magicNumber = 0.1f;

        return (int)magicNumber * sprites.Length;
    }
}
