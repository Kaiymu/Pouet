using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GenericClickable : BaseClickable {

    public GameObject[] gameObjectList;
    public float durationSprite;

    private bool _onLeavingObject = false;

    private int _indexGameObjectList = 0;

    protected override void _OnClickedObject() {

        _indexGameObjectList = 0;
        StopAllCoroutines();

        _onLeavingObject = false;
        
        float duration = _TypeElement(gameObjectList[_indexGameObjectList]);
        StartCoroutine(_CallbackFinishedGenericAction(duration));
    }

    private float _TypeElement(GameObject _test) {

        if (_onLeavingObject)
            return 0;

        var videoPlayer = _test.GetComponent<VideoPlayer>();
        var spriteRenderer = _test.GetComponent<SpriteRenderer>();
        var audioSource = _test.GetComponent<AudioSource>();
        var textClickable = _test.GetComponent<OneLetterAtATime>();

        if (videoPlayer != null) {
            videoPlayer.gameObject.SetActive(true);
            videoPlayer.Play();
            return (float)videoPlayer.clip.length;
        }
        else if (spriteRenderer != null) {
            spriteRenderer.gameObject.SetActive(true);
            return durationSprite;
        }
        else if (audioSource != null) {
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
            return audioSource.clip.length;
        }
        else if (textClickable != null) {
            textClickable.gameObject.SetActive(true);
            StartCoroutine(textClickable.AnimateText());
            return (textClickable.animateTextSeconds * textClickable.completeText.Length);
        }

        return 0f;
    }

    protected override void _OnLeavingObject() {
        _LeavingObject();
    }

    private void _LeavingObject() {
        _onLeavingObject = true;
        for (int i = 0; i < gameObjectList.Length; i++) {
            gameObjectList[i].SetActive(false);
        }

        _indexGameObjectList = 0;
        StopAllCoroutines();
    }

    private IEnumerator _CallbackFinishedGenericAction(float duration) {

        yield return new WaitForSeconds(duration);

        _indexGameObjectList++;
        if (_indexGameObjectList <= (gameObjectList.Length - 1)) {
            float durationCallback = _TypeElement(gameObjectList[_indexGameObjectList]);
            StartCoroutine(_CallbackFinishedGenericAction(durationCallback));
        }
        else {
            _LeavingObject();
        }

        yield return null;
    }
}
