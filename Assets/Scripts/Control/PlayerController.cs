using Deliverer.Movement;
using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float rotateForce;
        Mover mover;
        float horizontalInput;
        float verticalInput;
        bool isMoving;
        [SerializeField] Fuel fuel;
        void Start()
        {
            mover = GetComponent<Mover>();
        }
        void Update()
        {
            Move();
            if (verticalInput != 0)
            {
                fuel.DecreaseFuel(1);
            }
        }

        private void Move()
        {
            mover.Move(GetInput().y * speed);
            mover.Rotate(-GetInput().x * rotateForce);
        }
        private Vector2 GetInput()
        {
            return new Vector2(horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical"));
        }
    }
}

