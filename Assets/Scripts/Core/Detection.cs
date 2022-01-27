using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class Detection : MonoBehaviour
    {
        [SerializeField] OrderManager om;
        [SerializeField] Fuel fuel;
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Package"))
            {
                om.OrderPickup();
            }
            if (collision.gameObject.CompareTag("Arrow"))
            {
                om.DeliverOrder();
            }
            if (collision.gameObject.CompareTag("Fuel"))
            {
                fuel.canBuyFuel = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Fuel"))
            {
                fuel.canBuyFuel = false;
                fuel.fuelBought = false;
            }
        }
    }
}

