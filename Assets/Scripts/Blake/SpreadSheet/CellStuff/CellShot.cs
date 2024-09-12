using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellShot : Enemy
{
    public GameObject Spreadsheet;
    public int Damage;
    private void Start()
    {
        Spreadsheet = GameObject.FindWithTag("SpreadSheet");
    }
    private void Update()
    {
        Damage = GetComponent<CellCalculations>().damage;
    }
    protected override void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                GameEvents.DamagePlayer?.Invoke(Damage);
            }
            else if(name == "DealDamageCell(Clone)")
            {
                GameEvents.DamageEnemy?.Invoke(Damage, Spreadsheet);
            }
            GameEvents.CellsShot?.Invoke();
        }
    }
    private void OnEnable()
    {
        GameEvents.CellsShot += CellDie;
        GameEvents.DamageEnemy += TakeDamage; // required to be shot
    }

    private void OnDisable()
    {
        GameEvents.CellsShot -= CellDie;
        GameEvents.DamageEnemy -= TakeDamage; // required to be shot
    }
    void CellDie()
    {

        transform.parent.tag = ("SpawnLocation");
        // allows cells to spawn in this location

        Destroy(gameObject);
    }
}