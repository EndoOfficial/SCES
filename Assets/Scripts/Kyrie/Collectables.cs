using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    
    public GameObject Presentable;
    public GameObject Panel;

    public void Start()
    {
        Panel = GameObject.Find("Canvas").transform.Find("ImageOfText").gameObject;
        Panel.SetActive(false); 
        
    }
    public void PresentCollect()
    {
        Panel.SetActive(true);
        Presentable.SetActive(true);

    }
    public void DisableCollect()
    {
        Panel.SetActive(false);
        Presentable.SetActive(false);
    }
}