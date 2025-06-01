using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject firstScreenCanvasPrefab;
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer.Instance.PlaySound("mainmenu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayClicked()
    {
        Instantiate(firstScreenCanvasPrefab);
        Destroy(this.gameObject);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
