using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;

namespace platforming_pirates
{
    public class platform : Sprite
    
    {
        public Rectangle Solid;
        public platform(Texture2D image, Vector2 location, Color color, Rectangle solid)
            :base(image, location, color)
            {
                Solid = solid;
          
            }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Solid, null, Color, 0f, new Vector2(0, 0), effect, depth);
        }

        
    }
}
