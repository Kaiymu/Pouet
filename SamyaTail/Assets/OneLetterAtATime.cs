using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneLetterAtATime : MonoBehaviour {

    public string completeText;

    public float animateTextSeconds = 0.5f;
    private TextMesh _textMesh;
    private string _str;

    private void Awake() {
        _textMesh = GetComponent<TextMesh>();
    }

    private void OnDisable() {
        StopAllCoroutines();
        _textMesh.text = string.Empty;
    }

    public IEnumerator AnimateText(UnityAction callbackFinishedText = null) {
        int i = 0;
        _str = "";
        while (i < completeText.Length) {
            _str += completeText[i++];
            _textMesh.text = _str;
            yield return new WaitForSeconds(animateTextSeconds);
        }

        if (callbackFinishedText != null) {
            callbackFinishedText();
        }
    }
}
