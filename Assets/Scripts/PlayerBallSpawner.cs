using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float throwStrength;
    public InputAction action;
    public InputActionAsset actionAsset;

    private void Start()
    {
        var actionMap = actionAsset.FindActionMap("Default");
        action = actionMap.FindAction("Spawn");
        action.performed += Action_performed;
        action.Enable();
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Instantiate(ball, playerCamera.position, playerCamera.rotation).GetComponent<Rigidbody>();
    }




    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody ballToSpawn = Instantiate(ball, playerCamera.position, playerCamera.rotation).GetComponent<Rigidbody>();

            ballToSpawn.velocity = playerCamera.TransformDirection(Vector3.forward * throwStrength);
        }

    }
}
