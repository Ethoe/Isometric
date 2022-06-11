using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{

    public class Transformer
    {
        // These are the four numbers that define the transform, i hat and j hat
        const float i_x = 1f;
        const float i_y = 0.5f;
        const float j_x = -1f;
        const float j_y = 0.5f;

        // Sprite size
        const int w = 1;
        const int h = 1;

        private struct matrix
        {
            public float a;
            public float b;
            public float c;
            public float d;
        }

        static public Vector2 toScreenCoordinate(Vector2 tile)
        {
            // return new Vector2(tile.x * i_x + tile.y * j_x,
            //                    tile.x * i_y + tile.y * j_y);

            return new Vector2(tile.x * i_x * 0.5f * w + tile.y * j_x * 0.5f * w,
                               tile.x * i_y * 0.5f * h + tile.y * j_y * 0.5f * h);
        }

        static public Vector2 toGridCoordinate(Vector2 screen)
        {
            var a = i_x * 0.5f * w;
            var b = j_x * 0.5f * w;
            var c = i_y * 0.5f * h;
            var d = j_y * 0.5f * h;

            var inv = invertMatrix(a, b, c, d);

            return new Vector2(Mathf.Floor(screen.x * inv.a + screen.y * inv.b),
                               Mathf.Floor(screen.x * inv.c + screen.y * inv.d));
        }

        static private matrix invertMatrix(float a, float b, float c, float d)
        {
            var det = (1 / (a * d - b * c));
            var result = new matrix();
            result.a = det * d;
            result.b = det * -b;
            result.c = det * -c;
            result.d = det * a;
            return result;
        }
    }
}