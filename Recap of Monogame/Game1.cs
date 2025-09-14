using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recap_of_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D radianceTexture;
        Rectangle radianceRect;
        Texture2D sunDialTexture;
        Rectangle sunDialRect;

        Texture2D knightTexture;
        Rectangle knightRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "Hollow Knight";
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();


            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Initialize();

            radianceRect = new Rectangle(window.Width / 2 - radianceTexture.Width / 4, 100, radianceTexture.Width / 2, radianceTexture.Height / 2);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            knightTexture = Content.Load<Texture2D>("Images/Knight/Challenge Start_011");
            radianceTexture = Content.Load<Texture2D>("Images/Radiance/Cast_003");
            sunDialTexture = Content.Load<Texture2D>("Images/Radiance/Sun Dial");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(radianceTexture, radianceRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
