using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveDistance = 1f; // Расстояние перемещения за один шаг
    public float moveSpeed = 5f; // Скорость перемещения
    public float moveDelay = 0.5f; // Задержка после движения

    private Vector3 targetPosition; // Целевая позиция для перемещения
    private bool isMoving = false; // Флаг, указывающий, движется ли объект
    private SpriteRenderer spriteRenderer; // Компонент SpriteRenderer

    void Start()
    {
        targetPosition = transform.position; // Инициализация целевой позиции
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент SpriteRenderer
    }

    void Update()
    {
        // Проверка нажатия клавиш для перемещения только если не движемся
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector3.left);
                spriteRenderer.flipX = true; // Разворачиваем спрайт влево
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector3.right);
                spriteRenderer.flipX = false; // Разворачиваем спрайт вправо
            }
        }

        // Плавное движение к целевой позиции
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);

        // Проверка, достигли ли мы целевой позиции
        if (transform.position == targetPosition)
        {
            isMoving = false; // Сбрасываем флаг движения, когда достигли цели
        }
    }

    void Move(Vector3 direction)
    {
        // Установка новой целевой позиции с учетом заданного расстояния
        targetPosition += direction * moveDistance;
        isMoving = true; // Устанавливаем флаг движения в true

        // Запускаем корутину для задержки
        StartCoroutine(MoveDelay());
    }

    private System.Collections.IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(moveDelay); // Ждем заданное время
        isMoving = false; // Сбрасываем флаг движения после задержки
    }
}