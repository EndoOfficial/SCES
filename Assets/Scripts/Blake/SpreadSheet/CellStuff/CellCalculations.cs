using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellCalculations : MonoBehaviour
{
    private int First;
    private int Second;
    public int damage;
    public TextMeshPro DamageInt;
    private CellSpawner CellManager;
    public int RndColour;
    void Start()
    {
        CellManager = GameObject.FindWithTag("SpreadSheet").GetComponent<CellSpawner>();

        if (CellManager.State2 == true)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                DamageInt.color = Color.green;
            }
            else if (name == "DealDamageCell(Clone)")
            {
                DamageInt.color = Color.red;
            }
        }

        // checks if the boss is in state 2 or 3 then checks
        // the name of the cell and changes colour accordingly

        if (CellManager.State3 == true)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                DamageInt.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
                // selects a random value from 0 to 1, and assigns it as a colour value
                // the final "1" is alpha and naturally I wanted them to always be visible
            }
            else if (name == "DealDamageCell(Clone)")
            {
                if (Random.value < 0.5f)
                    DamageInt.color = Color.red;
                else DamageInt.color = Color.green;
                // 50/50 chance of spawning as green or red
            }
        }

        // sets the text on the cell as well as damage
        First = Random.Range(11, 15);
        Second = Random.Range(0, 14);
        damage = First - Second;
        DamageInt.text = First + "-" + Second;
    }
}
