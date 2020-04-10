using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _Controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    [SerializeField]
    private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _jumpDouble;
    [SerializeField]
    private int _coins;
    private UIManager _uiManager;
    private int _lives = 3;
    void Start()
    {
        _Controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _uiManager.UpdateLives(_lives);
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(HorizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;
        if(_Controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _jumpDouble = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _jumpDouble == true)
            {
                _yVelocity += _jumpHeight ;
                _jumpDouble = false;
            }
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        _Controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins ()
    {
        _coins++;
        _uiManager.UpdateCoinsDisplay(_coins);
    }

    public void Damage ()
    {
        _lives--;
        _uiManager.UpdateLives(_lives);
        if (_lives < 1)
            SceneManager.LoadScene(0);
    }
}
