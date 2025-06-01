using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerCanvas : MonoBehaviour
{
    public GameObject computerScreen;
    public int energyCost = 40;
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

        PlayerEnergy energy = FindObjectOfType<PlayerEnergy>();
        if (energy != null)
        {
            if (energy.UseEnergy(energyCost))
            {
                Debug.Log("Objekt kliknut! Energija potrošena.");
                Debug.Log(energyCost);
                // Dodaj svoju logiku ovdje (animacija, efekt, itd.)
            }
        }
    }

}
