using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneLetterAtATime : MonoBehaviour {

    public string completeText;
    public float animateTextSeconds = 0.5f;

    [HideInInspector]
    public TextMesh textMesh;
    [HideInInspector]
    public string str;
    [HideInInspector]
    public int index = 0;

    private float _timeValue;
    public UnityAction callbackFinishedText;

    public void ResetParameters() {
        if(textMesh == null) {
            textMesh = GetComponent<TextMesh>();
        }

        index = 0;
        str = string.Empty;
        textMesh.text = string.Empty;
        readText = false;
    }

    private void Awake() {
        textMesh = GetComponent<TextMesh>();
    }

    private void OnDisable() {
        ResetParameters();
    }

    [HideInInspector]
    public bool readText;

    private void Update() {
        if(!readText)
            return;

        _timeValue += Time.deltaTime;

        if(_timeValue > animateTextSeconds) {
            _ReadText();
            _timeValue = 0;
        }
    }

    private void _ReadText() {
        if(index <= (completeText.Length - 1)) {
            str += completeText[index++];
            textMesh.text = str;
        } else {
            if(callbackFinishedText != null) {
                readText = false;
                callbackFinishedText();
            }
        }
    }
}
