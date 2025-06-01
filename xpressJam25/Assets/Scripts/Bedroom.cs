using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedroom : MonoBehaviour
{
    public GameObject mouseholePrefab;

    public void OnBedClick()
    {

    }

    public void OnMouseholeClick()
    {
        Instantiate(mouseholePrefab);
        ActivityManager.Instance.PushToInactiveStack(this.gameObject);
    }
}
