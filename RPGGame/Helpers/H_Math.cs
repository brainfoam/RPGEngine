using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------------MAIN INCLUDE-------------//
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPGGame.Helpers;
using RPGGame.Managers;
using RPGGame.Templates;
using RPGGame.Inventory;
//--------------------------------------//

namespace RPGGame.Helpers
{
    static class H_Math
    {
        /// <summary>
        /// Rounds a vector's X and Y values.
        /// </summary>
        /// <param name="v">The vector being rounded.</param>
        /// <returns></returns>
        public static Vector2 VectorLevel(Vector2 v)
        {
            return new Vector2((float)Math.Round(v.X), (float)Math.Round(v.Y));
        }

        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Lineraly interpolates two values up until a threshold, where it will round to the second value.
        /// </summary>
        /// <param name="v1">The first value.</param>
        /// <param name="v2">The second value.</param>
        /// <param name="l">The interpolation amount.</param>
        /// <param name="t">The threshold at which to round.</param>
        /// <returns></returns>
        public static float LerpThreshold(float v1, float v2, float l, float t = .01f)
        {
            if (v1 == v2)
                return v1;
            float new_value = MathHelper.Lerp(v1, v2, l);
            if (Math.Abs(new_value - v2) < t)
                new_value = v2;
            return new_value;
        }

        /// <summary>
        /// Lineraly interpolates two vectors up until a threshold, where it will round to the second value.
        /// </summary>
        /// <param name="v1">The first value.</param>
        /// <param name="v2">The second value.</param>
        /// <param name="l">The interpolation amount.</param>
        /// <param name="t">The threshold at which to round.</param>
        /// <returns></returns>
        public static Vector2 LerpThreshold(Vector2 v1, Vector2 v2, float l, float t = .01f)
        {
            if (v1 == v2)
                return v1;
            Vector2 new_vector = Vector2.Lerp(v1, v2, l);
            float dist = (new_vector - v2).Length();
            if (dist < t)
                new_vector = v2;
            return new_vector;
        }
    }
}
