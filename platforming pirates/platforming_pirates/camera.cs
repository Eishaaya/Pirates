using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace platforming_pirates
{
    public class camera
    {
        public BasicEffect effect;
        protected AnimatingSprite player;
        public camera(AnimatingSprite dude)
        {
            player = dude;
            var viewport = dude.Image.GraphicsDevice.Viewport;
            effect = new BasicEffect(dude.Image.GraphicsDevice);
            effect.TextureEnabled = true;
            effect.VertexColorEnabled = true;
            effect.Projection = Matrix.CreateOrthographic(viewport.Width, viewport.Height, 1, 10);
            effect.World = Matrix.Identity;
            update();
        }
        public void update()
        {
            var viewport = player.Image.GraphicsDevice.Viewport;
            effect.View = Matrix.CreateLookAt(new Vector3(player.Location, -9), new Vector3(player.Location, 0), Vector3.Down);
        }
    }
}
