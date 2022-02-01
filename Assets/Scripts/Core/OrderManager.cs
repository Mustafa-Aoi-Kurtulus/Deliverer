using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class OrderManager : MonoBehaviour
    {
        [Header("Point References")]
        [SerializeField] Transform packagePoint;
        [SerializeField] List<Transform> deliveryPoints;
        [Header("Variables")]
        [SerializeField] int orderWorth;
        [Header("Booleans")]
        [SerializeField] bool isPackageSpawned;
        public bool isCarFree;
        [Header("References")]
        [SerializeField] TimeManager tm;
        [SerializeField] MoneyManager money;
        [SerializeField] GameObject package;
        public GameObject currentDelivery;
        void Update()
        {
            //if the package isn't spawned & the isn't carrying a package
            if (!isPackageSpawned && isCarFree)
            {
                //Spawn the package
                SpawnPackage();
            }
        }

        public void OrderPickup()
        {
            //Set the isCarFree false, destroy the package in front of the restaurant, Choose one of the delivery points to deliver.
            isCarFree = false;
            package.SetActive(false);
            ConfirmAdress();
        }

        void SpawnPackage()
        {
            //Set the isPackageSpawned true, Instantiate the package in front of the restaurant
            isPackageSpawned = true;
            package.SetActive(true);
        }

        void ConfirmAdress()
        {
            //Choose randomly between the delivery points
            int randomIndex = Random.Range(0, deliveryPoints.Count);
            currentDelivery = deliveryPoints[randomIndex].gameObject;
            currentDelivery.SetActive(true);
        }
        public void DeliverOrder()
        {
            //Destroy the arrow at the delivery point, set the isCarFree true, Set the isPackageSpawned false, earn money
            currentDelivery.SetActive(false);
            isCarFree = true;
            isPackageSpawned = false;
            money.EarnMoney(orderWorth);
        }
    }
}