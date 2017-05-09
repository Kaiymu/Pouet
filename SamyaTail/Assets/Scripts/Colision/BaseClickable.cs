using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClickable : MonoBehaviour {

    private const float _distanceClick = 3f;

    protected GameObject _samya;
    private Renderer _renderer;

	private bool _hasBeenClicked;

    private void Start()
    {
        _samya = GameObject.FindGameObjectWithTag("Samya");
        _renderer = GetComponent<Renderer>();
    }
		
    private bool _wasOnObject = false;
    void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if(_CalculateClickedOn()) {
				_hasBeenClicked = true;
			}
		}

        if (!_isInSamyasRange()) {
			if (_wasOnObject) {
				_hasBeenClicked = false;
				_wasOnObject = false;
				_OnLeavingObject();
			}
		} else {
			if(!_wasOnObject) {
				if(_hasBeenClicked) {
					_wasOnObject = true;
		        _OnClickedObject();
				}
			}
		}
	}

	private bool _CalculateClickedOn() {

		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
		if (hit != null && hit.collider != null)
		{
			return true;
		}

		return false;
	}


    private bool _isInSamyasRange()
    {
        float distanceSamyaClick = Mathf.Abs(_samya.transform.position.x - _renderer.bounds.center.x);
        return distanceSamyaClick < _distanceClick;
    }
		

    protected virtual void _OnClickedObject()
    {
        _wasOnObject = true;
    }

    protected abstract void _OnLeavingObject();
}
