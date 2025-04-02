using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundPanel : MonoBehaviour
{
    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    void Start()
    {
        // 수치가 변경될 때 마다 사운드 설정
        masterSlider.onValueChanged.AddListener(volume => SoundManager.instance.SetMasterVolume(Mathf.RoundToInt(volume)));
        bgmSlider.onValueChanged.AddListener(volume => SoundManager.instance.SetBGMVolume(Mathf.RoundToInt(volume)));
        sfxSlider.onValueChanged.AddListener(volume => SoundManager.instance.SetSFXVolume(Mathf.RoundToInt(volume)));
    }

    void OnEnable()
    {
        StartCoroutine(OpenPannel());
    }

    IEnumerator OpenPannel()
    {
        yield return null;
        masterSlider.value = SoundManager.instance.masterVolume;
        bgmSlider.value = SoundManager.instance.bgmVolume;
        sfxSlider.value = SoundManager.instance.sfxVolume;
    }
}
