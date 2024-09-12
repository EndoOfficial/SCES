using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllVolume : MonoBehaviour
{
    [SerializeField] Slider volume;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("GameVolume"))
        {
            Load();
        }
    }
    public void VolumeChanged()
    {
        AudioListener.volume = volume.value;
        Save();
    }

    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("GameVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("GameVolume", volume.value);
    }

}
