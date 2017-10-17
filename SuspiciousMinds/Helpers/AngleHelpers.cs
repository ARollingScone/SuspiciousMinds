using SFML.System;
using System;

namespace SuspiciousMinds.Helpers
{
    public static class AngleHelpers
    {
        public static Vector2f Rotate(Vector2f a, double angle)
        {
            var x = (a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle));
            var y = (a.Y * Math.Cos(angle)) + (a.X * Math.Sin(angle));

            return new Vector2f((float)x, (float)y);
        }

        public static double GetRotation(Vector2f a, Vector2f b)
        {
            return Math.Atan2(
                b.Y - a.Y,
                b.X - a.X);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
