using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Массив префабов тайлов
    public int width = 10; // Ширина уровня
    public int height = 10; // Высота уровня
    public float tileSize = 1f; // Размер тайла

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Выбираем случайный префаб из массива
                GameObject tilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
                
                // Создаем тайл на позиции (x, y)
                Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
                Instantiate(tilePrefab, position, Quaternion.identity);
            }
        }
    }
}