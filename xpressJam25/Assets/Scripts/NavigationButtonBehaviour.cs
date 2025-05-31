using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtonBehaviour : MonoBehaviour
{
    public GameObject nextPrefab;
    public GameObject previousPrefab;
    public bool showExitButton = true;

    public void OnButtonExitPress()
    {
        ActivityManager.Instance.PopFromInactiveStack();
        Destroy(this.gameObject);
    }

    public void OnButtonNextPress()
    {
        GoToCanvas(nextPrefab);
    }

    public void OnButtonPreviousPress()
    {
        GoToCanvas(previousPrefab);
    }

    public void GoToCanvas(GameObject prefab)
    {
        if (prefab == null) return;
        Instantiate(prefab);
        Destroy(this.gameObject);
    }
}
