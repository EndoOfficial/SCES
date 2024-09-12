using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class TextTyper : MonoBehaviour
{
    // Is the text
    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] private string sceneName;
    public GameObject Loading;
    public GameObject Canvas;
    //is the array all the characters 
    public string[] stringArray;
    //is the count FOR the array
    int i = 0;

    void Start()
    {
        //starts function on frame 1 
        EndCheck();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && i >= stringArray.Length)
        {
            Loading.SetActive(true);
            Canvas.SetActive(false);
            Debug.Log("Tester");
            SceneManager.LoadScene(sceneName);
        }
    }



    public void EndCheck()
    {
        //if the array lerngth is higher then ARRAY -1 by away and start coroutine
        //this will happen for each string of the array
        if (i <= stringArray.Length - 1)
        {
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        //makes the text update
        _textMeshPro.ForceMeshUpdate();
        //Caculates the amount of character count that is needed for it to finish
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount; 
        //count is 0 and will go alway to the max of the array and will be stopped by Endcheck count
        int counter = 0;

        while (true)
        {
            //Using the already built in MaxVisibleChararacters we are allowed to show the first i amount of character
            int visibleCount = counter;
            _textMeshPro.maxVisibleCharacters = visibleCount;

            //simple count to allow us to go up by each letter, change the 1 to change how many letters to show.
            if (visibleCount >= totalVisibleCharacters)
            {
                i += 1;
            }



            counter += 1;
            yield return new WaitForSeconds(0f);
            //chang the 0 to change how slow it is 0.02 could work


        }




    }


}