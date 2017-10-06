using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platforming_pirates
{
    public class Button : Sprite
    {
        private SpriteFont _font;
        private string _text;
        public Rectangle hitbox;
        public Button(SpriteFont font, string text, Texture2D image, Vector2 location, Color color, Rectangle Hitbox) :
            base(image, location, color)
        {
            hitbox = Hitbox;
            _font = font;
            _text = text;
        }
        public override void Draw(SpriteBatch batch)
        {

            base.Draw(batch);
            batch.DrawString(_font, _text, new Vector2(Location.X + 40, Location.Y + 40), Color.Black);
            //batch.Draw(Image, Location, Color, 0f, , _font, _text)
        }
        public void shade(Color blah)
        {
                Color = blah;
        }
    }
}
