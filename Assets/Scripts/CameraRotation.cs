using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cameraAxisTransform;
    public float rotationSpeed;
    public float minAngle;
    public float maxAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = cameraAxisTransform.localEulerAngles.x - Time.deltaTime * rotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX >= 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        cameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
