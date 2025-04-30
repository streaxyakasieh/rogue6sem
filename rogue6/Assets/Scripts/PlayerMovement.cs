using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Получаем компонент SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Получаем ввод от игрока
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D или стрелки влево/вправо
        movement.y = Input.GetAxisRaw("Vertical"); // W/S или стрелки вверх/вниз

        // Нормализуем вектор движения, чтобы избежать ускорения при диагональном движении
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Разворот персонажа в зависимости от направления движения
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Поворот влево
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Поворот вправо
        }
    }

    void FixedUpdate()
    {
        // Перемещение игрока
        transform.position += (Vector3)movement * moveSpeed * Time.fixedDeltaTime;
    }
}