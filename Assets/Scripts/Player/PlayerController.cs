using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Animator _animator;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float _speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    private float _amountIncrementSpeed = 1.5f;
    private float _maxSpeed = 150f;

    private int lineToMove = 1;
    private float lineDIstance = 2f;

    private bool _isGround;
    private float _distanceCheckGround = 0.25f;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundLayers;

    private void Awake()
    {
        Instance = this;
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        RunAnimation();
    }

    private void FixedUpdate()
    {
        _direction.z = _speed;
        _direction.y += gravity * Time.fixedDeltaTime;
        _characterController.Move(_direction * Time.fixedDeltaTime);
    }

    private void Update()
    {
        // Проверка на землю
        CheckGround();

        // Установка анимации
        SetAnimation();

        // Свайп вправо
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        // Свайп влево
        if (SwipeController.swipeLeft)
            if (lineToMove > 0)
                lineToMove--;

        // Свайв вверх
        if (SwipeController.swipeUp)
        {
            if (_characterController.isGrounded)
                Jump();
        }

        if (SwipeController.swipeDown)
            UIController.Instance.ShowGamePausedMenu();

        // Движение персонажа
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDIstance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDIstance;

        if (transform.position == targetPosition) return;
        Vector3 different = targetPosition - transform.position;
        Vector3 moveDirection = different.normalized * 25 * Time.deltaTime;
        if (moveDirection.sqrMagnitude < different.sqrMagnitude)
        {
            _characterController.Move(moveDirection);
        }
        else
        {
            _characterController.Move(different);
        }
    }

    /// <summary>
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        _direction.y = jumpForce;
    }

    /// <summary>
    /// Анимация прыжка
    /// </summary>
    private void JumpAnimation()
    {
        _animator.SetBool(Settings.isRun, false);
        _animator.SetBool(Settings.isJump, true);
    }

    /// <summary>
    /// Анимация бега
    /// </summary>
    private void RunAnimation()
    {
        _animator.SetBool(Settings.isJump, false);
        _animator.SetBool(Settings.isRun, true);
    }

    /// <summary>
    /// Проверка на нахождение на земле
    /// </summary>
    private void CheckGround()
    {
        _isGround = Physics.Raycast(_groundCheckPoint.position, Vector3.down, _distanceCheckGround, _groundLayers);
    }

    /// <summary>
    /// Установка анимации
    /// </summary>
    private void SetAnimation()
    {
        // Анимаия
        if (_isGround)
        {
            RunAnimation();
        }
        else
        {
            JumpAnimation();
        }
    }

    /// <summary>
    /// Увеличение скорости
    /// </summary>
    public void IncrementSpeed()
    {
        if (_speed < _maxSpeed)
            _speed += _amountIncrementSpeed;
    }
}
