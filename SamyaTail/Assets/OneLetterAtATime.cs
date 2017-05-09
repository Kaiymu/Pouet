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

    private int _index = 0;

    private void Awake() {
        _textMesh = GetComponent<TextMesh>();
    }

    private void OnDisable() {
        _index = 0;
        _str = string.Empty;
        _textMesh.text = string.Empty;
    }

    public IEnumerator AnimateText(UnityAction callbackFinishedText = null) {
        yield return new WaitForSeconds(animateTextSeconds);
        _str += completeText[_index++];
        _textMesh.text = _str;

        if (_index <= (completeText.Length - 1)) {
            if (gameObject.activeInHierarchy) {
                StartCoroutine(AnimateText(callbackFinishedText));
            }
        }
        else {
            if (callbackFinishedText != null) {
                callbackFinishedText();
            }
        }

    }
}
