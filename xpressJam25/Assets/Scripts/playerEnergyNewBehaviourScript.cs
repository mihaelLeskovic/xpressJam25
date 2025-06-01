using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public int maxEnergy = 100;
    public int currentEnergy;
    public Text energyText; // Ako koristiš UI Text

    void Start()
    {
        currentEnergy = maxEnergy;
        UpdateEnergyUI();
    }

    public bool UseEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            UpdateEnergyUI();
            return true;
        }

        Debug.Log("Nema dovoljno energije!");
        return false;
    }

    void UpdateEnergyUI()
    {
        //if (energyText != null)
        //    energyText.text = "Energy: " + currentEnergy;
        Debug.Log(currentEnergy);

    }
}
