using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;

    bool blocking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open && !blocking)
        {
            Quaternion targetRotationO = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationO, smooth * Time.deltaTime);
        }
        if (!open && !blocking)
        {
            Quaternion targetRotationC = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationC, smooth * Time.deltaTime);
        }
    }

    public void ChangeDoorState()
    {
        // Flips open bool
        open = !open;
    }

    private void OnCollisionEnter(Collision collision)
    {
        blocking = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        blocking = false;
    }
}
