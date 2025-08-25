using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject squarePrefab;
    public int row = 8;
    public int column = 8;
    public Vector3 spawnPosition = new Vector3(5, 0, 0);
    void Start()
    {
        Debug.unityLogger.Log("Hello World");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                GameObject squareInstance = Instantiate(squarePrefab,  new Vector3(i, j, 0), Quaternion.identity);
                SpriteRenderer spriteRenderer = squareInstance.GetComponent<SpriteRenderer>();
                if ((i + j) % 3 == 1)
                {
                    spriteRenderer.color = Color.red;
                }
                else if ((i + j) % 3 == 2)
                {
                    spriteRenderer.color = Color.orange;
                }
                else
                {
                    spriteRenderer.color = Color.yellow;
                }
            }
        }
    }
}