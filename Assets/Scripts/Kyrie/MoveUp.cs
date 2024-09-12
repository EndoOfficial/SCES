using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 50f;
    private Vector3 StartPosition;
    public float Max = 800f;
    // Update is called once per frame

    void Start()
    {
        StartPosition = transform.localPosition;
    }

    private void OnEnable()
    {
        StartPosition = transform.localPosition;
    }

    private void OnDisable()
    {
        transform.localPosition = StartPosition;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed * transform.parent.transform.localScale.x, Space.World);
        if (transform.localPosition.y > Max)
        {
            transform.localPosition = StartPosition;
        }
    }
}
