using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityOption : MonoBehaviour
{
    [SerializeField] Slider sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MouseSensitivity"))
        {
            Load();
        }
    }
    public void SensitivityChanged()
    {
        GameEvents.OnSensitivityChanged?.Invoke();
        Save();

    }

    private void Load()
    {
        sensitivity.value = PlayerPrefs.GetFloat("MouseSensitivity");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity.value);
    }


}
