using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] float horsePower;
    private Rigidbody playerRb;
    private float horizontalInput, verticalInput;
    private float speed, rpm;
    private float turnSpeed = 40f;
    private int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //The center of mass of the vehicle is set to a child object's transform's origin
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void Update()
    {
        //This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (AreAllWhellsOnGround())
        {
            //Rigidbody.velocity.magnitude returns the speed in m/s. Multiply by 3.6 to convert it to Km/hr
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.text = "Speed: " + speed + " Km/hr";

            rpm = (speed % 30) * 40;
            rpmText.text = "RPM: " + rpm;
        }
    }

    void FixedUpdate()
    {
        if (AreAllWhellsOnGround())
        {
            ////We move the vehicle forward applying forces
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //We rotate the vehicle
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        }
    }

    private bool AreAllWhellsOnGround()
    {
        wheelsOnGround = 0;

        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded) { wheelsOnGround++; }
        }

        return wheelsOnGround == 4;
    }
}
