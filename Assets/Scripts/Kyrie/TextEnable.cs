using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextEnable : MonoBehaviour
{
    [SerializeField] private string sceneName;
    bool Clicked = false;
    public GameObject Canvas;
    public GameObject Loading;
    public GameObject Text;
    public GameObject TextDisable;
    // Update is called once per frame
    void Update()
    {
        if (Clicked == true && Input.GetKeyDown("space"))
        {
            Loading.SetActive(true);
            Canvas.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }
        
        if (Input.GetKeyDown("space"))
        {
            
            Text.SetActive(true);
            TextDisable.SetActive(false);
            Clicked = true;
        }



    }
}
