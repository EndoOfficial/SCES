using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleThrow : MonoBehaviour
{
    public Transform Spawn;
    public GameObject CellToThrow;
    private void Launch()
    {
        var obj = Instantiate(CellToThrow, Spawn.position, transform.rotation);
    }
}
