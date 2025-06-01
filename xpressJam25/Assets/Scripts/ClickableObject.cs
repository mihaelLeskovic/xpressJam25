using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public int energyCost = 40;

    void OnMouseDown()
    {
        PlayerEnergy energy = FindObjectOfType<PlayerEnergy>();
        if (energy != null)
        {
            if (energy.UseEnergy(energyCost))
            {
                Debug.Log("Objekt kliknut! Energija potro�ena.");
                Debug.Log(energyCost);
                // Dodaj svoju logiku ovdje (animacija, efekt, itd.)
            }
        }
    }
}
