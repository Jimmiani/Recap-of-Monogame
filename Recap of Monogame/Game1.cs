using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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

        List<Texture2D> essenceTextures = new List<Texture2D>();
        List<Texture2D> featherTextures = new List<Texture2D>();
        List<Rectangle> essenceRects = new List<Rectangle>();
        List<Rectangle> featherRects = new List<Rectangle>();
        Random generator = new Random();

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

            for (int i = 0; i < essenceTextures.Count; i++)
            {
                int scale = generator.Next(100, 400);
                essenceRects.Add(new Rectangle(generator.Next(-100, 900), generator.Next(-100, 600), scale, scale));
            }

            for (int i = 0; i < featherTextures.Count; i++)
            {
                int scale = generator.Next(30, 60);
                featherRects.Add(new Rectangle(generator.Next(300, 1000), generator.Next(100, 600), scale, scale));
            }

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
            gameFont = Content.Load<SpriteFont>("gameFont");

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    essenceTextures.Add(Content.Load<Texture2D>("Images/Particles/Essence/dream_particle_" + i));
                }
            }
                

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    featherTextures.Add(Content.Load<Texture2D>("Images/Particles/Feathers/moth_feather_particle_" + i));
                }
            }
                
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

            for (int i = 0; i < essenceTextures.Count; i++)
            {
                _spriteBatch.Draw(essenceTextures[i], essenceRects[i], Color.LemonChiffon * 0.3f);
            }
            
            _spriteBatch.Draw(sunDialTexture, sunDialRect, null, Color.White, dialRotation, new Vector2(sunDialTexture.Width / 2, sunDialTexture.Height / 2), SpriteEffects.None, 0);
            
            for (int i = 0; i < featherTextures.Count; i++)
            {
                _spriteBatch.Draw(featherTextures[i], featherRects[i], null, Color.White, featherRects[i].Width /*Rotation. Needed a value to rotate the feathers by, and this one was already randomized with each feather.*/, new Vector2(featherTextures[i].Width / 2, featherTextures[i].Width / 2), SpriteEffects.None, 0);
            }
            
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
