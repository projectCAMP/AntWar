using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //bgmとseのコンポーネントを取得
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    //BGMやSEの中身を保持
    public List<AudioClip> bgmList;
    public List<AudioClip> seList;
    public enum BGM
    {
        MainMenu,
        GamePlay
    }

    public enum SE
    {
        ButtonTap,
        Any
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGM(BGM index)
    {
        bgmAudioSource.clip = bgmList[(int)index];
        bgmAudioSource.Play();
    }

    public void PlaySE(SE index)
    {
        seAudioSource.clip = seList[(int)index];
        seAudioSource.Play();
    }
}
