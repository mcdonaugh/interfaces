using UnityEngine;
using UnityEngine.InputSystem;

namespace Interfaces.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInput _playerInput;
        private Vector3 _moveDirection = Vector3.zero;
        public float _moveSpeed = 1f;
        
        private InputAction _move;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _move = _playerInput.Player.Move;
            _move.Enable();
        }

        private void OnDisable()
        {
            _move.Disable();
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            _moveDirection = _move.ReadValue<Vector3>();
            transform.position += new Vector3(_moveDirection.x, _moveDirection.y, _moveDirection.z)  * _moveSpeed * Time.deltaTime;
        }
    }  
}