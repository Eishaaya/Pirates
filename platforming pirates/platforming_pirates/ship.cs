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
    class ship : Turret
    {
        public Sprite icon { get; set; }
        public int alpha;
        public ship(Texture2D image, Vector2 location, Color color, int frameTime, Rectangle hitbox, int Defence, int Attack, SpriteFont Thefont, List<ammo> Shot, TimeSpan RelodingPeriod, Texture2D shotimage, Vector2 Speed, Rectangle Range, int Speedx, Vector2 Origin, Sprite Icon, int Turnamount)
            : base(image, location, color, frameTime, hitbox, Defence, Attack, Thefont, Shot, RelodingPeriod, shotimage, Speed, Range, Speedx, Turnamount)
        {
            icon = Icon;
            origin = Origin;
            alpha = 255;
        }
        public override void update(GameTime time)
        {
            hp.location = new Vector2(Location.X, Location.Y - hpdisplacement);
            base.update(time);
            framy = activeFrame;
            float magnitude = (float)Math.Sqrt((yAxis - 127) * (yAxis - 127) + (xAxis - 127) * (xAxis - 127));
            float angle = (float)Math.Atan2((yAxis - 127) * -1, xAxis - 127);

            if (magnitude > 20)
            {
                float angleDegrees = MathHelper.ToDegrees((float)Math.Atan2(yAxis - 127, xAxis - 127)) - 90;
                
                angle += MathHelper.PiOver2;

                while (angle < 0)
                {
                    angle += MathHelper.Pi * 2;

                }
                angle = MathHelper.ToDegrees(angle);
                float leftDelta = rotation - angle;
                if (leftDelta < 0)
                {
                    leftDelta += 360;
                }
                float rightDelta = angle - rotation;
                if (rightDelta < 0)
                {
                    rightDelta += 360;
                }

                bool favorLeft = leftDelta < rightDelta;
                bool shouldTurn = Math.Abs(leftDelta - 180) > 3 && Math.Abs(rightDelta - 180) > 3;
                if (favorLeft)
                {
                    if (shouldTurn)
                    {
                        rotation += turnamount;
                    }
                }
                else
                {
                    if (shouldTurn)
                    {
                        rotation -= turnamount;
                    }
                }
                Console.WriteLine("angle: " + angle + "\t vessel: " + rotation + "\tleft: " + leftDelta + "\tright: " + rightDelta);

                if (rotation < 0)
                {
                    rotation += 360;
                }
                else if (rotation > 360)
                {
                    rotation -= 360;
                }
            }
        }
        public override void Draw(SpriteBatch batch)
        {
            float rads = MathHelper.ToRadians(rotation);
            batch.Draw(Image, Location, allFrames[currentState][frameIndex], Color, rads, origin, 1.0f, SpriteEffects.FlipHorizontally, LayerDepth);
            for (int i = 0; i < shot.Count; i++)
            {
                shot[i].Draw(batch);
            }
            if (!isdead)
            {
                hp.draw(batch);
            }
        }
    }
}
