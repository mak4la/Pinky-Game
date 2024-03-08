using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{ 

    [SerializeField] private ScreenFader screenFader;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() {

       //SceneManager.LoadScene("MainGame");
       screenFader.FadeToColor("MainGame");

    }

    public void Quit()
    {
        Application.Quit();

    }
}
