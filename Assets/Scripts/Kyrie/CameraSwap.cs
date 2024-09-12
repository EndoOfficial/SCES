using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    int i = 2;
    public Camera CameraSlums;
    public Camera CameraApartment;
    public Camera CameraFarm;
    public Camera CameraCorpo;

    public Camera OptionsCamera;
    public Camera CreditCamera;
    public GameObject MainCanvas;
    public GameObject OptionsCanvas;
    public GameObject CreditCanvas;
    public void Start()
    {
        
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(false);
        RandomArea();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
    }
    public void SwaptoOptions()
        {

            OptionsCamera.enabled = true;
            CreditCamera.enabled = false;
            TurnOffAreas();
            OptionsCanvas.SetActive(true);
            CreditCanvas.SetActive(false);

    }
        public void SwaptoMain()
        {

        RandomArea();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = false;
        MainCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(false);
    }
        public void SwaptoCredits()
        {

        TurnOffAreas();
        OptionsCamera.enabled = false;
        CreditCamera.enabled = true;
        TurnOffAreas();
        OptionsCanvas.SetActive(false);
        CreditCanvas.SetActive(true);
    }


    public void RandomArea()
    {
        i = Random.Range(1, 5);
        if (i == 1)
        {
            CameraSlums.enabled = true;
            CameraApartment.enabled = false;
            CameraFarm.enabled = false;
            CameraCorpo.enabled = false;
        }
        if (i == 2)
        {
            CameraSlums.enabled = false;
            CameraApartment.enabled = true;
            CameraFarm.enabled = false;
            CameraCorpo.enabled = false;
        }
        if (i == 3)
        {
            CameraSlums.enabled = false;
            CameraApartment.enabled = false;
            CameraFarm.enabled = true;
            CameraCorpo.enabled = false;
        }
        if (i == 4)
        {
             CameraSlums.enabled = false;
             CameraApartment.enabled = false;
             CameraFarm.enabled = false;
             CameraCorpo.enabled = true;
        }



    }
    
    public void TurnOffAreas()
    {
        CameraSlums.enabled = false;
        CameraApartment.enabled = false;
        CameraFarm.enabled = false;
        CameraCorpo.enabled = false;
        MainCanvas.SetActive(false);
    }
       

}
