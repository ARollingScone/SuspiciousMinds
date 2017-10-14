using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace SuspiciousMinds.Base.Player
{
    public class PixelGrid
    {
        public Dictionary<Vector2f, Color> Grid { get; }  = new Dictionary<Vector2f, Color>();

        public PixelGrid(Color baseColour)
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    var diff = 8 - j;
                    var max = 4 + (4 - diff);
                    var min = 4 - (4 - diff);

                    if (i >= min && i <= max)
                        Grid[new Vector2f(i, j)] = baseColour;
                }
            }
        }
    }
}
