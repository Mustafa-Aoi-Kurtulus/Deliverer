using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Movement
{
    public class Mover : MonoBehaviour
    {
        public void Move(float verticalSpeed)
        {
            transform.Translate(0,verticalSpeed * Time.deltaTime, 0,Space.Self);
        }
        public void Rotate(float rotateAmount)
        {
            transform.Rotate((Vector3.forward * rotateAmount) * Time.deltaTime);
        }
    }
}

