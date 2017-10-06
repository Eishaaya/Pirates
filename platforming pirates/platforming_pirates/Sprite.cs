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
    public class Sprite
    {
        public SpriteEffects effect = SpriteEffects.None;
        public float scale = 1;
        public float depth = 1;
        public Texture2D Image { get; set; }
        public Vector2 Location { get; set; }
        public Color Color { get; set; }
        public Vector2 origin { get; set; }
        public float rotation { get; set; }

        public Sprite(Texture2D image, Vector2 location, Color color)
        {
            Image = image;
            Location = location;
            Color = color;
            origin = new Vector2(0, 0);
            rotation = 0;
        }
        public virtual void Draw(SpriteBatch batch)
        {
            float rads = MathHelper.ToRadians(rotation);
            batch.Draw(Image, Location, null, Color, rotation, origin, scale, effect, depth);
        }
    }
}