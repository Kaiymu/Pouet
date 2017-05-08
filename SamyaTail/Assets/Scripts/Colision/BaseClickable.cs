using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseClickable : MonoBehaviour {

    private const float _distanceClick = 1f;

    protected GameObject _samya;

    private void Start()
    {
        _samya = GameObject.FindGameObjectWithTag("Samya");
    }

    bool _calculate = false;
    void Update () {
        Renderer _renderer = GetComponent<Renderer>();
        float distanceSamyaClick = Mathf.Abs(_samya.transform.position.x - _renderer.bounds.center.x);

        if (distanceSamyaClick > _distanceClick)
        {
            _calculate = true;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit != null && hit.collider != null)
            {
                _OnClickedObject();
            }
        }

        if(_calculate)
        {
            float distanceSamyaClick2 = Mathf.Abs(_samya.transform.position.x - _renderer.bounds.center.x);

            Debug.LogError(distanceSamyaClick2 + " " + _distanceClick);
            if (distanceSamyaClick2 < _distanceClick)
            {
                _calculate = false;
                _OnClickedObject();
            }
        }
    }

    protected abstract void _OnClickedObject();
}
