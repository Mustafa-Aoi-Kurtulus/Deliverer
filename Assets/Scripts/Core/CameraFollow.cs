using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] Vector3 offset;
        void LateUpdate()
        {
            transform.position = player.transform.position + offset;
        }
    }
}

