using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    // ��������� ���������� ��� ��������� �������� � ���� ������
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // ��������� ����������
    private Rigidbody rb;
    private bool isGrounded;

    // ����� ��� �������������
    void Start()
    {
        // �������� ��������� Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // �����, ���������� ������ ����
    void Update()
    {
        // �������� ���� �� ������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ������� ������ �������� �� ������ �����
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;

        // ��������� �������� � ������� ���������
        transform.Translate(movement, Space.Self);

        // ���������, ������ �� ������ ������ (�� ��������� "Space") � ��������� �� �������� �� �����
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // ��������� ���� ������ � Rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // �����, ���������� ��� ��������������� � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ��������� �� �������� �� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // �����, ���������� ��� ��������� ��������������� � ������ ��������
    private void OnCollisionExit(Collision collision)
    {
        // ���������, ���� �� �������� � ����������� �����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}