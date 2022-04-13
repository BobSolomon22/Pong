using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPosition;
        Vector2 ballSpeed;
        Vector2 predictedBallPosition;
        
        Texture2D barTexture;
        Vector2 barPosition;
        Vector2 barScale;
        float barSpeed;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private void checkBounds() {
            if (predictedBallPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2) {
                predictedBallPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                ballSpeed.X = -ballSpeed.X;
            }  
            else if (predictedBallPosition.X < ballTexture.Width / 2) {
                predictedBallPosition.X = ballTexture.Width / 2;
                ballSpeed.X = -ballSpeed.X;
            }

            if (predictedBallPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2) {
                predictedBallPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                ballSpeed.Y = -ballSpeed.Y;
            }
            else if (predictedBallPosition.Y < ballTexture.Height / 2) {
                predictedBallPosition.Y = ballTexture.Height / 2;
                ballSpeed.Y = -ballSpeed.Y;
            }

            if (barPosition.Y > _graphics.PreferredBackBufferHeight - (barScale.Y * barTexture.Height) / 2)
                barPosition.Y = _graphics.PreferredBackBufferHeight - (barScale.Y * barTexture.Height) / 2;
            else if (barPosition.Y < (barScale.Y * barTexture.Height) / 2)
                barPosition.Y = (barScale.Y * barTexture.Height) / 2;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = new Vector2(10f, 10f);

            barPosition = new Vector2(30, _graphics.PreferredBackBufferHeight / 2);
            barScale = new Vector2(0.25f, 0.25f);
            barSpeed = 500f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            barTexture = Content.Load<Texture2D>("bar");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                barPosition.Y -= barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (kstate.IsKeyDown(Keys.Down))
                barPosition.Y += barSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            predictedBallPosition = ballPosition + ballSpeed;

            checkBounds();

            ballPosition = predictedBallPosition;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.Draw(
                barTexture,
                barPosition,
                null,
                Color.White,
                0f,
                new Vector2(barTexture.Width / 2, barTexture.Height / 2),
                barScale,
                SpriteEffects.None,
                0f
            );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
