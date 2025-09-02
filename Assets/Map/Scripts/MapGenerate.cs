using UnityEngine;

public class MapGenerate : MonoBehaviour
{
    public GameObject bg;
    public int leftSide = -10;
    public int rightSide = 10;
    public int topSide = 10;
    public int bottomSide = -10;

    private void Start()
    {
        for(int i = leftSide; i<=rightSide; i++)
        {
            for(int j = bottomSide; j<=topSide; j++)
            {
                Instantiate(bg, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
}
