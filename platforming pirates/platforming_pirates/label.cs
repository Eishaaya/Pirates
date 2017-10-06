using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platforming_pirates
{
    public class label
    {
        private SpriteFont font;
        public string text;
        public float depth = 1;
        public Vector2 location;
        Color color;
        public label(SpriteFont Font, string Text, Vector2 Location, Color Color)
        {
            font = Font;
            text = Text;
            location = Location;
            color = Color;
        }
        public void draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, location, color, 0, new Vector2(0, 0), 1, SpriteEffects.None, depth);
        }
    }
}