using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof (CarController))]
public class CarSteering : MonoBehaviour
{
	[SerializeField]
	bool _userInput = true;
	public bool userInput {
		get { return _userInput; }
		set {
			if (_userInput != value)
			{
				_userInput = value;
				horizontalSteering = 0f;
				verticalSteering = 0f;
			}
		}
	}

    private CarController car;
	[NonSerialized]
	public float horizontalSteering;
	[NonSerialized]
	public float verticalSteering;

    private void Awake()
    {
        car = GetComponent<CarController>();
		foreach (var w in car.GetComponentsInChildren<WheelCollider>())
			w.ConfigureVehicleSubsteps(0.5f, 8, 8);
    }

	private void Update()
	{
		if(userInput)
		{
			horizontalSteering = Input.GetAxis("Horizontal");
			verticalSteering = Input.GetAxis("Vertical");
			verticalSteering -= Input.GetAxis("Jump");
		}
	}

	private void FixedUpdate()
    {
        car.Move(horizontalSteering, verticalSteering, verticalSteering, 0f);
    }
}
