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
    class shooter : AnimatingSprite
    {
        public List<ammo> shot;
        TimeSpan reloding;
        TimeSpan relodingperiod;
        Texture2D si;
        Vector2 speed;
        public Rectangle range;
        public int updown = 0;
        public int speedx;
        public shooter(Texture2D image, Vector2 position, Color tint, int frameTime, Rectangle hitbox, int Defence, int Attack, SpriteFont Thefont, List<ammo> Shot, TimeSpan RelodingPeriod, Texture2D shotimage, Vector2 Speed, Rectangle Range, int Speedx)
            :base(image, position, tint, frameTime, hitbox, Defence, Attack, Thefont, Speedx)
        {
            shot = Shot;
            relodingperiod = RelodingPeriod;
            si = shotimage;
            speed = Speed;
            range = Range;
            speedx = Speedx;
        }
        public virtual void update(GameTime time)
        {
            Hitbox = new Rectangle((int)Location.X, (int)Location.Y, activeFrame.Width, activeFrame.Height);
            if (goback)
            {
                range = new Rectangle((int)Location.X + activeFrame.Width, (int)Location.Y + 15, 350, 5);
            }
            else if (!goback)
            {
                range = new Rectangle((int)Location.X - 350, (int)Location.Y + 15, 350, 5);
            }
            base.Animate(time);
            updown++;
            if(updown >= 20)
            {
                updown = 0;
            }
            reloding += time.ElapsedGameTime;            
            for (int i = 0; i < shot.Count; i++)
            {
                shot[i].Update(time);
            }
        }
        public void shoot(Vector2 startingpoint)
        {
            if (reloding >= relodingperiod)
            {
                ammo newshot = new ammo(si, Location, Color, new Rectangle((int)startingpoint.X, (int)startingpoint.Y, si.Width, si.Height), speed);
                if (goback)
                {
                    newshot.direction = true;
                    newshot.effect = SpriteEffects.FlipHorizontally;
                }
                else if (!goback)
                {
                    newshot.direction = false;
                }
                shot.Add(newshot);
                reloding = TimeSpan.Zero;
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            for(int i = 0; i < shot.Count; i++)
            {
                shot[i].Draw(batch);
            }
        }
    }
}
