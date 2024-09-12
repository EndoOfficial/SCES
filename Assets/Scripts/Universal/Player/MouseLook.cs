using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private bool _paused;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        }
    }

    private void OnEnable()
    {
        GameEvents.OnPauseGame += OnPauseGame;
        GameEvents.OnSensitivityChanged += OnSensitivityChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnPauseGame -= OnPauseGame;
        GameEvents.OnSensitivityChanged -= OnSensitivityChanged;
    }

    private void OnSensitivityChanged()
    {
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");

        }
    }

    private void OnPauseGame(bool paused)
    {
        _paused = paused;
    }

    // Update is called once per frame
    void Update()
    {
        // get the mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity /* Time.deltaTime*/;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity /* Time.deltaTime*/;

        // set mouse clamp (cant look further up or down than 90 degrees)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (!_paused)
        {
            //sets rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
