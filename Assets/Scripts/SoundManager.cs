using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer audioMixer;
    public AudioSource bgSound;
    public AudioClip titleBGM;
    private Transform usingSFX;
    private Transform usedSFX;
    public AudioClip endingClip;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        usingSFX = transform.GetChild(0);
        usedSFX = transform.GetChild(1);
        BgSoundPlay(titleBGM);
    }

    public void SFXPlay(string sfxName, AudioClip clip) {
        if (usedSFX.childCount == 0) { // ��Ȱ���� ������Ʈ�� ���� ���
            GameObject clipObj = new GameObject(sfxName + "Sound");
            clipObj.transform.parent = usingSFX;

            // Ŭ�� �ʱ�ȭ �� ���
            AudioSource audiosource = clipObj.AddComponent<AudioSource>();
            audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
            audiosource.clip = clip;
            audiosource.Play();

            // Ŭ�� Ǯ���� ������Ʈ �ʱ�ȭ
            SFXPlayer sfxtmp = clipObj.AddComponent<SFXPlayer>();
            sfxtmp.SetPlayer(usedSFX);
        } else { // ��Ȱ���� ������Ʈ�� ���� ���
            GameObject clipObj = usedSFX.GetChild(0).gameObject;
            clipObj.SetActive(true);
            clipObj.transform.name = sfxName + "Sound";
            clipObj.transform.parent = usingSFX;

            clipObj.GetComponent<AudioSource>().clip = clip;
            clipObj.GetComponent<AudioSource>().Play();
        }
    }

    public void BgSoundPlay(AudioClip clip) {
        if(bgSound.clip != null && bgSound.clip.name == clip.name) {
            return;
        }

        bgSound.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.Play();
    }

    public void MasterVolume(float val) {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(val) * 20);
    }

    public void BGMVolume(float val) {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(val) * 20);
    }

    public void SFXVolume(float val) {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(val) * 20);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        OVRPlayerController.instance.transform.position = new Vector3(0, 0.8f, 0);
        OVRPlayerController.instance.transform.rotation = Quaternion.identity;
        OVRPlayerController.instance.EnableLinearMovement = false;
        OVRPlayerController.instance.EnableRotation = false;
        if (scene.name == "TrueEnding" || scene.name == "NormalEnding" || scene.name == "BadEnding") {
            BgSoundPlay(endingClip);
        }
        // �� �ε尡 �Ϸ�� �� ���ʿ��� ���ҽ��� ����
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
