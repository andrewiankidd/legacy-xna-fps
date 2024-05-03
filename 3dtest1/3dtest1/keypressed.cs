using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

 namespace _3dtest1
{
    public class keypressed
    {
        public static KeyboardState newkbState, oldkbState;
        static public bool Key(Keys theKey)
        {
            if (newkbState.IsKeyUp(theKey) && oldkbState.IsKeyDown(theKey))
            {
                 return true;
            }
            return false;
        }
    }
}
