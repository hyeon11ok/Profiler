using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public void UISoundPlay(AudioClip clip) {
        SoundManager.instance.SFXPlay("UISound", clip);
    }
}
