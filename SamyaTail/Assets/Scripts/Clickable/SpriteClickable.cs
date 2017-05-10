using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteClickable : BaseClickable {

    public SpriteRenderer[] spriteRenderer;
    public float durationSprite;

    private int _indexSpriteRenderer = 0;

    protected override void _OnClickedObject() {
        spriteRenderer[0].gameObject.SetActive(true);
        StartCoroutine(_CallbackFinishedSpriteRenderer());
    }

    private IEnumerator _CallbackFinishedSpriteRenderer() {
        yield return new WaitForSeconds(durationSprite);

        _indexSpriteRenderer++;

        if (_indexSpriteRenderer <= (spriteRenderer.Length - 1)) {
            var sprite = spriteRenderer[_indexSpriteRenderer];
            sprite.gameObject.SetActive(true);
            StartCoroutine(_CallbackFinishedSpriteRenderer());
        }
        else {
            _HideSprites();
        }

        yield return null;
    }

    protected override void _OnLeavingObject() {
        _indexSpriteRenderer = 0;
        _HideSprites();
    }

    private void _HideSprites() {
        for (int i = 0; i < spriteRenderer.Length; i++) {
            spriteRenderer[i].gameObject.SetActive(false);
        }
    }
}
