using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public CharacterController controller;
    public float Force;
    public float smoothTime;
    float smooth;
    public Transform firstCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + firstCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref smooth, smoothTime);
            Vector3 move = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(move.normalized * Force * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("ÏÈÇÄÀ))");
            Force = 30;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Force = 15;
        }
    }
}
