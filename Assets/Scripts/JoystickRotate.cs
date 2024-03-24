using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRotate : MonoBehaviour
{
    public FixedJoystick _joystick;
    public float _rotateSpeed;
    private void Update()
    {
        RotateWithJoystick();
    }

    private void RotateWithJoystick()
    {
        Vector3 moveVector = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        if (moveVector != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
