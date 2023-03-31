using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    [SerializeField]
    private Texture2D point;
    // Start is called before the first frame update
    void Awake()
    {
        // This transforms my point to a square, but at least it is 10x10.
        point.Reinitialize(10, 10);

        Vector2 pointOffset = new(point.width / 2, point.height / 2);

        Cursor.SetCursor(point, pointOffset, CursorMode.Auto);
    }
}