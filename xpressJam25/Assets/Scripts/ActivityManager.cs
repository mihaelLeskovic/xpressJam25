using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{
    public static ActivityManager Instance { get; private set; }

    Stack<GameObject> inactiveStack = new Stack<GameObject>();

    public int taskCounter = 0;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PushToInactiveStack(GameObject gameObject)
    {
        inactiveStack.Push(gameObject);
        gameObject.SetActive(false);
    }

    public void PopFromInactiveStack()
    {
        inactiveStack.Pop().SetActive(true);
    }
}
