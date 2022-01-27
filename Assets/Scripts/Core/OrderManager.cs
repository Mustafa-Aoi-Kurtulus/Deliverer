using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Core
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] GameObject packagePrefab;
        [SerializeField] GameObject arrowPrefab;
        [SerializeField] Transform packagePoint;
        [SerializeField] List<Transform> deliveryPoints;
        [SerializeField] int orderWorth;
        GameObject currentPackage;
        GameObject currentArrow;
        [SerializeField] bool isPackageSpawned;
        [SerializeField] bool isCarFree;

        [SerializeField] TimeManager tm;
        [SerializeField] MoneyManager money;

        void Start()
        {
            isCarFree = true;
        }
        void Update()
        {
            if (!tm.isDayOver)
            {
                if (!isPackageSpawned && isCarFree)
                {
                    SpawnPackage();
                }
            }
        }

        public void OrderPickup()
        {
            isCarFree = false;
            Destroy(currentPackage);
            ConfirmAdress();
        }

        void SpawnPackage()
        {
            isPackageSpawned = true;
            currentPackage = Instantiate(packagePrefab, packagePoint.position,Quaternion.identity);
        }

        void ConfirmAdress()
        {
            int randomIndex = Random.Range(0, deliveryPoints.Count);
            currentArrow = Instantiate(arrowPrefab, deliveryPoints[randomIndex].position,deliveryPoints[randomIndex].rotation);
        }
        public void DeliverOrder()
        {
            Destroy(currentArrow);
            isCarFree = true;
            isPackageSpawned = false;
            money.EarnMoney(orderWorth);
        }
    }
}