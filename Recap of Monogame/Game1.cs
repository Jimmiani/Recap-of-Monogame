using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Recap_of_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont gameFont;

        Rectangle window;
        Texture2D backgroundTexture;

        Texture2D radianceTexture;
        Rectangle radianceRect;

        Texture2D sunDialTexture;
        Rectangle sunDialRect;
        float dialRotation;

        Texture2D knightTexture;
        Rectangle knightRect;

        Texture2D platformTexture;
        Rectangle platformRect;

        Texture2D cloudTexture;
        Rectangle cloudRect;

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
            dialRotation = 0;

            base.Initialize();

            radianceRect = new Rectangle(window.Width / 2 - 275, 50, 551, 600);
            sunDialRect = new Rectangle(645, 300, 1300, 1300);
            cloudRect = new Rectangle(100, 400, 1200, 700);
            platformRect = new Rectangle(600, 500, platformTexture.Width, platformTexture.Height);
            knightRect = new Rectangle(630, 360, knightTexture.Width, knightTexture.Height);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            knightTexture = Content.Load<Texture2D>("Images/Knight/Challenge Start_011");
            radianceTexture = Content.Load<Texture2D>("Images/Radiance/Cast_003");
            sunDialTexture = Content.Load<Texture2D>("Images/Radiance/Sun Dial");
            backgroundTexture = Content.Load<Texture2D>("Images/Background/hollow_knight_background");
            cloudTexture = Content.Load<Texture2D>("Images/Clouds/blurry_cloud");
            platformTexture = Content.Load<Texture2D>("Images/Platforms/R Plat Wide Idle_000");
            knightTexture = Content.Load<Texture2D>("Images/Knight/Challenge Start_011");
            gameFont = Content.Load<SpriteFont>("gameFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            dialRotation += 0.005f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(sunDialTexture, sunDialRect, null, Color.White, dialRotation, new Vector2(sunDialTexture.Width / 2, sunDialTexture.Height / 2), SpriteEffects.None, 0);
            _spriteBatch.Draw(radianceTexture, radianceRect, Color.White);
            _spriteBatch.Draw(knightTexture, knightRect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            _spriteBatch.Draw(platformTexture, platformRect, Color.White);
            _spriteBatch.Draw(cloudTexture, cloudRect, Color.White * 0.9f);
            _spriteBatch.DrawString(gameFont, new string("Hollow Knight"), new Vector2(40, 630), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
