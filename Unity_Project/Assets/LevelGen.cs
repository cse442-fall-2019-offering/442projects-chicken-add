using UnityEngine;

public class LevelGen : MonoBehaviour
{

    public Texture2D map1;
    public Texture2D map2;
    private Texture2D map;

    public ColorToPrefab[] colorMappings;
    // Start is called before the first frame update
    void Start()
    {
        if(LivesControl.Instance.level == 1)
        {
            map = map1;
        }else if(LivesControl.Instance.level == 2){
            map = map2;
        }
        else{
            map = map1;
        }
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i=0; i < map.width; i++)
        {
            for (int j = 0; j <map.height; j++)
            {
                GenerateTile(i, j);
            }

        }

    }

    void GenerateTile (int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
