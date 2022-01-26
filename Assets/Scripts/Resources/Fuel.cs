using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Resource
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float fuel;
        public void DecreaseFuel(float fuelUsage)
        {
            fuel -= fuelUsage * Time.deltaTime;
        }

    }
}

