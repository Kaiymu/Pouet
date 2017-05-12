using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClickable : MonoBehaviour {

    private const float _distanceClick = 0.1f;

    protected GameObject _samya;
    private Renderer _renderer;

	private bool _hasBeenClicked;
    [HideInInspector]
    public MouseMovement _samyaMovement;

    private void Start()
    {
        _samya = GameObject.FindGameObjectWithTag("Samya");
        _samyaMovement = _samya.GetComponent<MouseMovement>();
        _renderer = GetComponent<Renderer>();
    }
		
    private bool _wasOnObject = false;

    private void OnMouseDown() {
        _hasBeenClicked = true;
        _wasOnObject = false;
    }

    void Update () {
        if (_hasBeenClicked) {
            if (!_isInSamyasRange()) {
                if (_wasOnObject) {
                    _hasBeenClicked = false;
                    _wasOnObject = false;
                    _OnLeavingObject();
                }
            }
            else {
                if (!_wasOnObject) {
                    if (_hasBeenClicked) {
                        _samyaMovement.canMove = false;
                        _wasOnObject = true;
                        _OnClickedObject();
                    }
                }
            }
        }
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
