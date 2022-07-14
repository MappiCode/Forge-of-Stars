using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimPoint : MonoBehaviour
{
    public InputActionAsset inputs;

    // Set position in Update() and not in OnAim() so the AimPoint is always in the correct position
    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(inputs["Aim"].ReadValue<Vector2>());
        mousePosition.z = 0;   
        transform.position = mousePosition;
    }
}
