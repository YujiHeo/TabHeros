using UnityEngine;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager>
{
    public SoundPanel soundPanel;

    private string masterHash = "Master_Value";
    private string bgmHash = "BGM_Value";
    private string sfxHash = "SFX_Value";

    private Dictionary<string, AudioClip> soundDict;    // SFX와 BGM을 저장할 Dictionary
    [SerializeField] private AudioSource bgmPlayer;                       // BGM 재생용 AudioSource
    [SerializeField] private AudioSource sfxPlayer;                       // SFX 재생용 AudioSource

    public int masterVolume;                       // BGM 재생 볼륨 0 ~ 100
    public int bgmVolume;                       // BGM 재생 볼륨 0 ~ 100
    public int sfxVolume;                       // SFX 재생 볼륨 0 ~ 100

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] audioClips;    // 오디오 클립 배열

    private new void Awake()
    {
        base.Awake();
        Init();
        masterVolume = PlayerPrefs.GetInt(masterHash, 100);
        bgmVolume = PlayerPrefs.GetInt(bgmHash, 100);
        sfxVolume = PlayerPrefs.GetInt(sfxHash, 100);
    }

    private void Start()
    {
        SetMasterVolume(masterVolume);
        PlayBGM("BGM_01");
    }

    private void Init()
    {
        soundDict = new Dictionary<string, AudioClip>();
        bgmPlayer.loop = true; // BGM은 기본적으로 반복 재생

        // Dictionary 초기화
        foreach (var clip in audioClips)
        {
            soundDict[clip.name] = clip;
        }
    }

    public void OpenSoundPanel()
    {
        soundPanel.gameObject.SetActive(true);
    }

    public void SetBGMPlayer(AudioSource player)
    {
        bgmPlayer = player;
        bgmPlayer.volume = bgmVolume;
    }

    public void SetSFXPlayer(AudioSource player)
    {
        sfxPlayer = player;
        sfxPlayer.volume = sfxVolume;
    }

    public void SetMasterVolume(int volume)
    {
        PlayerPrefs.SetInt(masterHash, volume);
        masterVolume = volume;
        bgmPlayer.volume = bgmVolume / 100f * (masterVolume / 100f);
        sfxPlayer.volume = sfxVolume / 100f * (masterVolume / 100f);
    }
    public void SetBGMVolume(int volume)
    {
        PlayerPrefs.SetInt(bgmHash, volume);
        bgmVolume = volume;
        bgmPlayer.volume = bgmVolume / 100f * (masterVolume / 100f);
    }
    public void SetSFXVolume(int volume)
    {
        PlayerPrefs.SetInt(sfxHash, volume);
        sfxVolume = volume;
        sfxPlayer.volume = sfxVolume / 100f * (masterVolume / 100f);
    }

    // SFX 재생
    public void PlaySFX(string soundName)
    {
        if (soundDict.TryGetValue(soundName, out var clip))
        {
            sfxPlayer.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX not found.");
        }
    }

    // BGM 재생
    public void PlayBGM(string bgmName)
    {
        if (soundDict.TryGetValue(bgmName, out var clip))
        {
            if (bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.Play();
            }
        }
        else
        {
            Debug.LogWarning("BGM not found.");
        }
    }
}