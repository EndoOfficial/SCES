using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyOptions : MonoBehaviour
{
    [SerializeField] Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            Load();
        }
    }

    public void OnDifficultyChange()
    {
        Save();
        GameEvents.OnDificultyChanged?.Invoke();
    }

    private void Load()
    {
        dropdown.value = PlayerPrefs.GetInt("Difficulty");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Difficulty", dropdown.value);
    }
}
