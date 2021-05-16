using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water.Graphics
{
    public class Sprite : GameObject
    {
        public string Tag { get; set; } = "Not tagged";
        private Texture2D sprite;
        private readonly string path;
        public Sprite(Rectangle relativePosition, string path)
        {
            RelativePosition = relativePosition;
            this.path = path;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            spriteBatch.Draw(sprite, ActualPosition, Color.White);
        }

        public override void Initialize()
        {
            sprite = Game.Textures.GetTexture(path);
        }

        public override void Update(GameTime gameTime)
        {
 
        }
    }
}
