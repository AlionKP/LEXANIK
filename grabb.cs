using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grabb : MonoBehaviour

{

    [Header("настройки")]

    public float grabPower = 10.0f;

    public float throwPower = 10f;

    public float RayDistance = 10.0f;

    [Header("компоненты")]

    public Transform offset;

    public Camera _camera;



    RaycastHit hit;

    private bool Grab = false;

    private bool Throw = false;

    void Update()

    {

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, RayDistance);



        if (hit.rigidbody && Input.GetKeyDown(KeyCode.E))

        {

            Grab = !Grab;

        }



        if (Input.GetMouseButtonDown(0) && Grab)

        {

            Grab = false;

            Throw = true;

        }



        if (Grab && hit.rigidbody) { Grabb(); } // поднять предмет

        if (Throw && hit.rigidbody) { ThrowB(); } // кинуть предмет

    }



    void Grabb()
    {

        hit.rigidbody.velocity = (offset.position - (hit.transform.position + hit.rigidbody.centerOfMass)) * grabPower;

    }



    void ThrowB()
    {

        hit.rigidbody.velocity = _camera.ScreenPointToRay(Input.mousePosition).direction * throwPower;

        Throw = false;

    }

}
