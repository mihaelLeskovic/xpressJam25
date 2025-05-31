using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCanvas : MonoBehaviour
{
    public GameObject computerScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnComputerScreenClick()
    {
        Instantiate(computerScreen);
        ActivityManager.Instance.PushToInactiveStack(this.gameObject);
    }
}
