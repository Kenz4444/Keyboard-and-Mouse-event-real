using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Emit;

namespace Keyboard_and_Mouse_event
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D pacTexture, pacLeftTexture, pacUpTexture, pacDowntexture, pacSleepTexture, pacRightTexture;
        Rectangle pacLocation;
        Rectangle window;
        Vector2 pacSpeed;
        KeyboardState keyboardState;

        Texture2D exitTexture;
        Rectangle exitRect;
        Texture2D barrierTexture;
        Rectangle barrierRect1, barrierRect2;
        Texture2D coinTexture;
        Rectangle coinRect;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pacLocation = new Rectangle(10, 10, 60, 60);
            window = new Rectangle(0, 0, 800, 480);
            pacSpeed = Vector2.Zero;

            barrierRect1 = new Rectangle(0, 250, 350, 75);
            barrierRect2 = new Rectangle(450, 250, 350, 75);
            coinRect = new Rectangle(400, 50, 50, 50);
            exitRect = new Rectangle(700, 380, 100, 100);
           


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pacTexture = Content.Load<Texture2D>("PacRight");
            pacUpTexture = Content.Load<Texture2D>("pacUp");
            pacDowntexture = Content.Load<Texture2D>("pacDown");
            pacLeftTexture = Content.Load<Texture2D>("pacLeft");
            pacSleepTexture = Content.Load<Texture2D>("pacSleep");
            pacRightTexture = Content.Load<Texture2D>("Pacright");


            barrierTexture = Content.Load<Texture2D>("rock_barrier");
            // Exit
            exitTexture = Content.Load<Texture2D>("hobbit_door");
            // Coin
            coinTexture = Content.Load<Texture2D>("coin");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            keyboardState = Keyboard.GetState();
            pacSpeed = new Vector2();
            
            pacSpeed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacSpeed.Y -= 2;
                pacTexture=pacUpTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacSpeed.Y += 2;
                pacTexture=pacDowntexture;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacSpeed.X += 2;
                pacTexture = pacRightTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacSpeed.X -= 2;
                pacTexture =pacLeftTexture;
            }
            pacLocation.Offset(pacSpeed);

            pacLocation.X += (int)pacSpeed.X;



            pacLocation.Y += (int)pacSpeed.Y;
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            _spriteBatch.Begin();


            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

            _spriteBatch.Draw(barrierTexture, barrierRect1, Color.White);
            _spriteBatch.Draw(barrierTexture, barrierRect2, Color.White);
            _spriteBatch.Draw(exitTexture, exitRect, Color.White);
            
            _spriteBatch.Draw(coinTexture, coinRect, Color.White);



            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
