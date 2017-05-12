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
        for (int i = 0; i < oneLetterAnim.Length; i++) {
            var objectAnim = oneLetterAnim[i];
            objectAnim.gameObject.SetActive(true);
            objectAnim.ResetParameters();
        }

        var oneLetterAnimObj = oneLetterAnim[_indexOneLetter];
        oneLetterAnimObj.callbackFinishedText = _CallbackFinishedText;
        oneLetterAnimObj.readText = true;
    }

    private void _CallbackFinishedText() {
        _indexOneLetter++;
        if (_indexOneLetter <= (oneLetterAnim.Length - 1)) {
            var oneLetterAnimObj = oneLetterAnim[_indexOneLetter];
            oneLetterAnimObj.readText = true;
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
            var oneLetterAnimObj = oneLetterAnim[i];
            oneLetterAnimObj.ResetParameters();
        }
    }
}
