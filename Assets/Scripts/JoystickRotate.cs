using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickRotate : MonoBehaviour
{

    private FixedJoystick _joystick;
    public float _rotateSpeed;
    public ViewEnemies ve;
    private Swipe sw; 

    private void Start()
    {
        _joystick = GameObject.FindGameObjectWithTag("Joystick").transform.GetChild(0).gameObject.GetComponent<FixedJoystick>();
        sw = GameObject.FindGameObjectWithTag("GameController").GetComponent<Swipe>();
    }

    private void Update()
    {
        if (CurrentNum.enemies.Count != CurrentNum.EnemyDeadCount)
        {
            RotateWithJoystick();
        }
      
    }

    private void RotateWithJoystick()
    {
        Vector3 moveVector = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        if (moveVector != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime);
        }
        else
        {
            sw.localView();
        }
    }
}
