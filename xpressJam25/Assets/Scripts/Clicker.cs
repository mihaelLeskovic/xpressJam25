using UnityEngine;
public class Clicker : MonoBehaviour
{
    Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Use the hit variable to determine what was clicked on.
                OnButtonClick();
            }
        }
    }
    public void OnButtonClick()
    {
        // Code here is called when the Button is clicked on.
        Debug.Log("kliknut");
    }
}