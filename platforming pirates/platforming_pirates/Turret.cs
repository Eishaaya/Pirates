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
    class Turret : shooter
    {
        public Rectangle framy;
        public int xAxis;
        public int yAxis;
        public int turnamount;
        public Turret(Texture2D image, Vector2 location, Color color, int frameTime, Rectangle hitbox, int Defence, int Attack, SpriteFont Thefont, List<ammo> Shot, TimeSpan RelodingPeriod, Texture2D shotimage, Vector2 Speed, Rectangle Range, int Speedx, int Turnamount)
            : base(image, location, color, frameTime, hitbox, Defence, Attack, Thefont, Shot, RelodingPeriod, shotimage, Speed, Range, Speedx)
        {
            turnamount = Turnamount;
        }
        public override void update(GameTime time)
        {
            base.update(time);
        }
        public void build(SpriteBatch hammerandnails)
        {
            float rads = MathHelper.ToRadians(rotation);
            base.Draw(hammerandnails);
        }
    }
}

