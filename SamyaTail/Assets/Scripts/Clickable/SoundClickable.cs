using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClickable : BaseClickable {

    public AudioSource[] audioSourceList;

    private int _indexSoundAudio = 0;

    protected override void _OnClickedObject() {
        _indexSoundAudio = 0;
        StopAllCoroutines();

        for (int i = 0; i < audioSourceList.Length; i++) {
            audioSourceList[i].gameObject.SetActive(true);
        }

        var audioSource = audioSourceList[_indexSoundAudio];
        audioSource.PlayOneShot(audioSource.clip);

        StartCoroutine(_CallbackFinishedAudio(audioSource.clip.length));
    }

    private IEnumerator _CallbackFinishedAudio(float time) {
        yield return new WaitForSeconds(time);

        _indexSoundAudio++;

        if (_indexSoundAudio <= (audioSourceList.Length - 1)) {
            var audioSource = audioSourceList[_indexSoundAudio];
            audioSource.PlayOneShot(audioSource.clip);
            StartCoroutine(_CallbackFinishedAudio(audioSource.clip.length));
        }

        yield return null;
    }

    protected override void _OnLeavingObject() {
        StopAllCoroutines();

        _indexSoundAudio = 0;
        for (int i = 0; i < audioSourceList.Length; i++) {
            audioSourceList[i].Stop();
            audioSourceList[i].gameObject.SetActive(false);
        }
    }
}
