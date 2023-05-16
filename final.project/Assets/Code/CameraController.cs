using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Посилання на трансформ персонажа
    public float mouseSensitivity = 2.0f; // Чутливість миші
    public float smoothSpeed = 5.0f; // Швидкість плавного переходу камери

    private Vector2 currentRotation = Vector2.zero;

    void LateUpdate()
    {
        // Телепортуємо камеру до позиції персонажа
        transform.position = target.position;

        // Отримуємо значення руху миші
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Обчислюємо обертання камери в залежності від руху миші
        currentRotation.x += mouseX;
        currentRotation.y -= mouseY;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -90f, 90f);

        // Повертаємо персонажа відповідно до обертання камери
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);

        // Плавно переходимо до нової позиції камери
        transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
    }
}