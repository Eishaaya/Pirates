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

namespace platforming_pirates
{
    class ammo : Sprite
    {
        public Rectangle hitbox;
        public Vector2 speed;
        public bool direction = true;
        float speedy = 1;
        public ammo(Texture2D image, Vector2 location, Color color, Rectangle Hitbox, Vector2 Speed)
            : base(image, location, color)
        {
            hitbox = Hitbox;
            speed = Speed;
        }
        public void Update(GameTime time)
        {
            if (direction)
            {
                Location += speed;
            }
            else if (!direction)
            {
                Location -= speed;
            }
            Location = new Vector2(Location.X, Location.Y + speedy/2);
            hitbox = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
        }
    }
}
