using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClickable : BaseClickable {

    public TextMesh[] _3DText;


    protected override void _OnClickedObject()
    {
        for(int i = 0; i < _3DText.Length; i++)
        {
            _3DText[i].gameObject.SetActive(true);
        }

    }
}
