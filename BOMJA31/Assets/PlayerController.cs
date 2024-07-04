using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    // Публичные переменные для настройки скорости и силы прыжка
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    // Приватные переменные
    private Rigidbody rb;
    private bool isGrounded;

    // Метод для инициализации
    void Start()
    {
        // Получаем компонент Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Метод, вызываемый каждый кадр
    void Update()
    {
        // Получаем ввод от игрока
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Создаем вектор движения на основе ввода
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;

        // Применяем движение к позиции персонажа
        transform.Translate(movement, Space.Self);

        // Проверяем, нажата ли кнопка прыжка (по умолчанию "Space") и находится ли персонаж на земле
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Применяем силу прыжка к Rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Метод, вызываемый при соприкосновении с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, находится ли персонаж на земле
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Метод, вызываемый при окончании соприкосновения с другим объектом
    private void OnCollisionExit(Collision collision)
    {
        // Проверяем, ушел ли персонаж с поверхности земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}