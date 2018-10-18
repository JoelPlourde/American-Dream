using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Head;

    private void LateUpdate()
    {
        transform.rotation = Head.rotation;
        //transform.position = Head.position;
    }
}
