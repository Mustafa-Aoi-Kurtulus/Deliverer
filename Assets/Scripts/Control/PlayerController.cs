using Deliverer.Core;
using Deliverer.Movement;
using Deliverer.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deliverer.Control
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] float maxSpeed;
        [SerializeField] float maxRotateForce;
        [SerializeField] Vector3 startPos;
        float speed;
        float rotateForce;
        [SerializeField] float fuelUsage;
        [SerializeField] float windowCooldown;
        float horizontalInput;
        float verticalInput;
        bool isMoving;
        bool didCarSoundStart;
        public static Vector3 playerPos;
        public static Quaternion playerRotation;
        [Header("References")]
        [SerializeField] Mover mover;
        [SerializeField] Fuel fuel;
        [SerializeField] OrderManager order;
        [SerializeField] MoneyManager money;
        [SerializeField] SceneLoader scene;
        [SerializeField] Audio sound;
        [SerializeField] Transform gasStation;
        [SerializeField] SpriteRenderer packageSprite;
        [SerializeField] GameObject tutorialWindow;
        void Start()
        {
            RestoreSpeed();
            if (TimeManager.hours == 8 && TimeManager.minutes == 0)
            {
                if (TimeManager.dayCount == 1)
                {
                    //This enables the tutorial window
                    tutorialWindow.SetActive(true);
                }
                ResetPlayerPosition();
            }
            else
            {
                transform.position = playerPos;
                transform.rotation = playerRotation;
                tutorialWindow.SetActive(false);
            }
        }
        void Update()
        {
            Move();
            ManagePackageSprite();
            if (verticalInput != 0)
            {
                //Decrease fuel every frame the player character is moving vertically
                fuel.DecreaseFuel(fuelUsage);
                //Start playing the car sound
                if (!didCarSoundStart)
                {
                    didCarSoundStart = true;
                    sound.PlaySound(GetComponent<AudioSource>());
                }
                // Make the player twice as slow when they are going backwards.
                if (verticalInput < 0)
                {
                    speed = maxSpeed / 2;
                }
                else
                {
                    speed = maxSpeed;
                }
            }
            else
            {
                //Stop playing car sound
                didCarSoundStart = false;
                sound.StopSound(GetComponent<AudioSource>());
            }
            //If player runs out of fuel, before they could reach a gas station, make sure the fuel isn't lower than 0 and call the function "GetFuel"
            if (Fuel.fuel <= 0)
            {
                Fuel.fuel = 0;
                GetFuel();
            }
            // If fuel isn't already bought and the player character is in the correct location, call the function in the Fuel script "BuyFuel"
            if (fuel.canBuyFuel && !fuel.fuelBought)
            {
                StartCoroutine(fuel.BuyFuelAction(windowCooldown));
            }
            // If money is 0 or lower load the "DayResult" scene which will end the game
            if (MoneyManager.money <= 0)
            {
                scene.LoadGameScene("DayResult");
            }
            //When the game is paused save player position and rotation
            if (Time.timeScale == 0)
            {
                playerPos = transform.position;
                playerRotation = transform.rotation;
            }
        }

        private void ManagePackageSprite()
        {
            //If isCar isn't free enable the package sprite
            if (!order.isCarFree)
            {
                packageSprite.enabled = true;
            }
            else
            {
                packageSprite.enabled = false;
            }
        }

        private void GetFuel()
        {
            //This method stops the car, move the player to the gas station charges them 25 of money and 50 for the fuel and restores their speed.
            StopCar();
            MoveToStation();
            money.SpendMoney(30);
            fuel.BuyFuel();
            RestoreSpeed();
        }

        void MoveToStation()
        {
            //Move the player to the gas station
            transform.position = gasStation.position;
        }
        void StopCar()
        {
            //Stop the player by setting their speed and rotate force to 0
            speed = 0;
            rotateForce = 0;
        }
        void RestoreSpeed()
        {
            //Restores the player's speed by setting their speed to the max value
            speed = maxSpeed;
            rotateForce = maxRotateForce;
        }
        private void Move()
        {
            //Moves the player using move function from the Mover script
            mover.Move(GetInput().y * speed);
            mover.Rotate(-GetInput().x * rotateForce);
        }
        private Vector2 GetInput()
        {
            //Gets player's horizontal and vertical input
            return new Vector2(horizontalInput = Input.GetAxis("Horizontal"), verticalInput = Input.GetAxis("Vertical"));
        }
        void ResetPlayerPosition()
        {
            //Set player character's position to startPos
            transform.position = startPos;
        }
    }
}

