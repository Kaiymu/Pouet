using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneLetterAtATime : MonoBehaviour {

    public string completeText;
    public float animateTextSeconds = 0.5f;

    private TextMesh _textMesh;
    private string _str;
    private bool _stopWritingText;

    private void Awake() {
        _textMesh = GetComponent<TextMesh>();
    }

    private void OnEnable() {
        StopCoroutineManually();
    }

    private void OnDisable() {
        StopCoroutineManually();
    }


    public void StopCoroutineManually() {
        _stopWritingText = true;
        StopAllCoroutines();
        _textMesh.text = string.Empty;
    }

    public IEnumerator AnimateText(UnityAction callbackFinishedText = null) {
        _stopWritingText = false;
        int i = 0;
        _str = "";

        while (i < completeText.Length) {
            if (_stopWritingText) {
                StopAllCoroutines();
                yield return null;
            }

            _str += completeText[i++];
            _textMesh.text = _str;
            yield return new WaitForSeconds(animateTextSeconds);
        }

        if (callbackFinishedText != null) {
            callbackFinishedText();
        }
    }
}
