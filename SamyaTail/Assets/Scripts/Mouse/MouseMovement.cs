using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public float _playerSpeed = 5f;

        // Privates
    private Camera _mainCamera;
    private Vector2 _playerPosition;

    private SpriteRenderer _playerSprite;
    void Start () {
        _mainCamera = Camera.main;
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private bool _canMove;
	
	void Update () {
        if(Input.GetMouseButtonDown(0)) {
            _playerPosition = _GetPositionsFromMouse();
            _FlipAnim(_playerPosition.x - transform.position.x);
        }

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), _playerPosition, _playerSpeed * Time.deltaTime);
    }

    private Vector2 _GetPositionsFromMouse() {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 finalPosition = new Vector2(_mainCamera.ScreenToWorldPoint(mousePosition).x, transform.position.y);
        return finalPosition;
    }

    private void _FlipAnim(float rotationSens) {
        _playerSprite.flipX = (rotationSens < 0);
    }
}
