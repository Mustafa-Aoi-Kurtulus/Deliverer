using Deliverer.Movement;
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

        void Start()
        {
            mover = GetComponent<Mover>();
        }
        void Update()
        {
            mover.Move( GetInput().y * speed);
            mover.Rotate(-GetInput().x * rotateForce);
        }
        private Vector2 GetInput()
        {
            return new Vector2(horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical"));
        }
    }
}

