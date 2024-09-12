using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //----------------------------------------
    // Every time a cell is shot this checks
    // to see what state the boss is in and
    // change eye colour accordingly
    //----------------------------------------

    private CellSpawner CellManager;
    void Start()
    {
        CellManager = GameObject.FindWithTag("SpreadSheet").GetComponent<CellSpawner>();
    }
    private void OnEnable()
    {
        GameEvents.CellsShot += EyeCheck;
    }
    private void OnDisable()
    {

        GameEvents.CellsShot -= EyeCheck;
    }
    private void EyeCheck()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.1f);
        // has to wait before checking to allow changes to be made
        if (CellManager.State2 == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            // first sets both eyes from green to red
        }
        if (CellManager.State3 == true)
        {
            if (name == "Right")
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                // then sets one of the eyes back to green
            }
        }
    }
}
