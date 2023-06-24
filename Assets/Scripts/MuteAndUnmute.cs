using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAndUnmute : MonoBehaviour
{
    public AudioSource backgroundAudio;

    public void MuteAndUnmuteSound() {
        if( backgroundAudio.isPlaying ) {
            backgroundAudio.Pause();
        } else {
            backgroundAudio.Play();
        }
    }
}
