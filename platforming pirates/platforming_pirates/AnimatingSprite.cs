using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace platforming_pirates
{
    public class AnimatingSprite : Sprite
    {
        public enum State
        {
            Running,
            Jumping,
            Attacking,
            Crouching,
            Crouchattacking,
            Standing,
            up,
            down,
            left,
            right,
            upleft,
            upright,
            downleft,
            downright
        }

        public enum ImageState
        {
            Normal,
            FlippedHorizontally,
            FlippedVertically
        }

        public Rectangle activeFrame;

        public float LayerDepth = 1;
        public int speed;
        public int cost;
        public Rectangle personalspace;
        protected Dictionary<State, List<Rectangle>> allFrames;
        public int hpdisplacement;
        public int frameIndex = 0;
        public Rectangle Hitbox;
        public State currentState;
        public bool isdead = false;
        public int attack;
        public int defence;
        SpriteFont thefont;
        public label hp;
        public bool readytoattack = false;
        public TimeSpan attackdellay = new TimeSpan(0, 0, 0, 0, 350);
        public TimeSpan untilattack;
        public bool goback = false;
        public int totaldeath = 0;
        public int totalreloads = 0;
        public bool isattacking = true;
        public bool flipped = false;
        public State CurrentState
        {
            get { return currentState; }
            set
            {
                if(currentState == value)
                {
                    return;
                }

                currentState = value;
                frameIndex = 0;
            }
        }

        private ImageState imageEffect;

        public ImageState ImageEffect
        {
            get { return imageEffect; }
            set { imageEffect = value; }
        }


        TimeSpan elapsedTime;
        TimeSpan frameTime;

        public void LoadFrameList(List<Rectangle> frames, State name)
        {
            if (!allFrames.ContainsKey(name))
            {
                allFrames.Add(name, frames);
            }
        }

        public AnimatingSprite(Texture2D image, Vector2 position, Color tint, int frameTime, Rectangle hitbox, int Defence, int Attack, SpriteFont Thefont, int Speed = 0)
            :base(image, position, tint)
        {
            speed = Speed;
            allFrames = new Dictionary<State, List<Rectangle>>();
            this.frameTime = new TimeSpan(0, 0, 0, 0, frameTime);
            imageEffect = ImageState.Normal;
            Hitbox = hitbox;
            defence = Defence;
            attack = Attack;
            thefont = Thefont;
            hpdisplacement = 25;
            if (origin == new Vector2(0, 0))
            {
                hp = new label(thefont, "HP", new Vector2(Location.X, Location.Y), Color.Black);
            }
        }

        public void Animate(GameTime gameTime)
        {
     
            var currentFrames = allFrames[CurrentState];
            elapsedTime += gameTime.ElapsedGameTime;
            activeFrame = allFrames[CurrentState][frameIndex];
            untilattack += gameTime.ElapsedGameTime;
            if(untilattack >= attackdellay)
            {
                readytoattack = true;
                untilattack = TimeSpan.Zero;
                if(isdead)
                {
                    totaldeath++;
                }
                totalreloads++;
            }
            else
            {
                readytoattack = false;
            }
            if(elapsedTime > frameTime)
            {
                frameIndex++;
                if(frameIndex > currentFrames.Count - 1)
                {
                    frameIndex = 0;
                }
                elapsedTime = TimeSpan.Zero;
                hp.text = string.Format("{0}HP", defence);
                hp.depth = .9999999999999999999f;
                hp.location = new Vector2(Location.X, Location.Y - hpdisplacement);
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            float rads = MathHelper.ToRadians(rotation);
            if (imageEffect == ImageState.FlippedHorizontally)
            {
                batch.Draw(Image, Location, allFrames[currentState][frameIndex], Color, rotation, origin, 1.0f, SpriteEffects.FlipHorizontally, LayerDepth);
            }
            else if(imageEffect == ImageState.Normal)
            {
                batch.Draw(Image, Location, allFrames[CurrentState][frameIndex], Color, rotation, origin, 1.0f, SpriteEffects.None, LayerDepth);
            }
            else if (imageEffect == ImageState.FlippedVertically)
            {
                batch.Draw(Image, Location, allFrames[currentState][frameIndex], Color, rotation, origin, 1.0f, SpriteEffects.FlipVertically, LayerDepth);
            }
            hp.draw(batch);
        }

      

    }
}
