using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    [HideInInspector] public Transform gObjectSelected;

    void Update()
    {
        DragCube();
        CameraMove();
    }

    void CameraMove() 
    {
        if (!Input.GetKey(KeyCode.Mouse1)) return;
        Transform cameraMain = Camera.main.transform;

        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += cameraMain.forward;
        if (Input.GetKey(KeyCode.S)) moveDir -= cameraMain.forward;

        if (Input.GetKey(KeyCode.D)) moveDir += cameraMain.right;
        if (Input.GetKey(KeyCode.A)) moveDir -= cameraMain.right;

        CommandStream.instance.CommandQueue.Enqueue(new MoveCommand() { gObject = Camera.main.gameObject, moveDir = moveDir.normalized, speed = 20f });

        CommandStream.instance.CommandQueue.Enqueue(new RotateCommand() { transform = cameraMain, x = Input.GetAxis("Mouse X"), y = Input.GetAxis("Mouse Y"), speed = 5f });
    }

    void DragCube() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit)
                {
                    gObjectSelected = objectHit;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gObjectSelected = null;
        }

        if (gObjectSelected)
        {

            Ray rayToScreen = Camera.main.ScreenPointToRay(Input.mousePosition);

            float x = Camera.main.transform.position.x + rayToScreen.direction.x * ((-Camera.main.transform.position.y + gObjectSelected.position.y) / rayToScreen.direction.y);
            float z = Camera.main.transform.position.z + rayToScreen.direction.z * ((-Camera.main.transform.position.y + gObjectSelected.position.y) / rayToScreen.direction.y);

            CommandStream.instance.CommandQueue.Enqueue(new ChangePosCommand()
            {
                gObject = gObjectSelected.gameObject,
                newPos = new Vector3(x, gObjectSelected.position.y, z)
            });
        }
    }
}
