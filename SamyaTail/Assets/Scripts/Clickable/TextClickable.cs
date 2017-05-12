using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClickable : BaseClickable {

    public OneLetterAtATime[] oneLetterAnim;

    private int _indexOneLetter = 0;

    protected override void _OnClickedObject()
    {
        _indexOneLetter = 0;
        StopAllCoroutines();


        for (int i = 0; i < oneLetterAnim.Length; i++) {
            oneLetterAnim[i].gameObject.SetActive(true);
        }

        
        var oneLetterAnimObj = oneLetterAnim[_indexOneLetter];
        oneLetterAnimObj.index = 0;
        StartCoroutine(oneLetterAnimObj.AnimateText(_CallbackFinishedText));
    }

    private void _CallbackFinishedText() {
        _indexOneLetter++;
        if (_indexOneLetter <= (oneLetterAnim.Length - 1)) {
            var oneLetterAnimObj = oneLetterAnim[_indexOneLetter];
            oneLetterAnimObj.index = 0;
            StartCoroutine(oneLetterAnimObj.AnimateText());
        } else {
            _LeavingObject();
        }
    }

    protected override void _OnLeavingObject()
    {
        _LeavingObject();
    }

    private void _LeavingObject() {
        _samyaMovement.canMove = true;
        _indexOneLetter = 0;
        for(int i = 0; i < oneLetterAnim.Length; i++) {
            StopCoroutine(oneLetterAnim[i].AnimateText());
            oneLetterAnim[i].gameObject.SetActive(false);
        }
    }
}
