using UnityEngine;
public class LoadSmoke : MonoBehaviour
{
    public GameObject Smoke;
    private void Start()
    {
        Instantiate(Smoke);
    }
}