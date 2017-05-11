using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoClickable : BaseClickable {

    public GameObject[] gameObjectList;

    private int _indexGameObjectList = 0;


    private void _TypeElement(GameObject _test) {
        if (_test.GetComponent<VideoPlayer>() != null) {

        }
        else if (_test.GetComponent<SpriteRenderer>() != null) {
            _test.gameObject.SetActive(true);
        }
        else if (_test.GetComponent<AudioSource>() != null) {

        }
        else if (_test.GetComponent<TextMesh>() != null) {

        }
	}

	protected override void _OnLeavingObject()
	{
		//Bien ouej l'erreur de compil négro
	}

    private IEnumerator _CallbackFinishedSpriteRenderer(float duration) {
        yield return new WaitForSeconds(duration);

        _indexGameObjectList++;
        /*
         * 
        if (_indexGameObjectList <= (gameObjectList.Length - 1)) {
            var sprite = gameObjectList[_indexSpriteRenderer];
            sprite.gameObject.SetActive(true);
            StartCoroutine(_CallbackFinishedSpriteRenderer());
        }
        else {
            _HideSprites();
        }
         * */

        yield return null;
    }
}
