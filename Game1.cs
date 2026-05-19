using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;

namespace Keyboard_and_Mouse_event
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D pacTexture, pacLeftTexture, pacUpTexture, pacDowntexture, pacSleepTexture, pacRightTexture, coinTexture, exitTexture, barrierTexture;
        Rectangle pacLocation;
        Rectangle window;
        Vector2 pacSpeed;
        KeyboardState keyboardState;

        
        Rectangle exitRect;

        List<Rectangle> barriers;
        MouseState mouseState;
        
        List<Rectangle> coins;


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
            window = new Rectangle(0, 0, 800, 600);
            pacSpeed = Vector2.Zero;

            barriers = new List<Rectangle>();
            barriers.Add(new Rectangle(0, 250, 350, 75));
            barriers.Add(new Rectangle(450, 250, 350, 75));
            coins = new List<Rectangle>();
            coins.Add(new Rectangle(400, 50,50, 50));
            coins.Add(new Rectangle(475, 50, 50, 50));
            coins.Add(new Rectangle(200, 300, 50, 50));
            coins.Add(new Rectangle(400, 300, 50, 50));
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
            mouseState = Mouse.GetState();
            pacSpeed = new Vector2();


            
            pacLocation.Y += (int)pacSpeed.Y;
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

            //if (pacLocation.Bottom > window.Height)
            //{
            //    pacSpeed.Y *= -pacSpeed.Y;

            //}

            //if (pacLocation.Top <= 0)
            //{
            //    pacSpeed.Y *= -1;
            //}

            pacLocation.X += (int)pacSpeed.X;

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
            if (pacLocation.Right > window.Width)
            {

               pacSpeed.X *= -pacSpeed.X;


            }
            

          

           
            pacLocation.Offset(pacSpeed);

           
            



            foreach (Rectangle barrier in barriers)
                if (pacLocation.Intersects(barrier))
                    pacLocation.Offset(-pacSpeed);


            if (mouseState.LeftButton == ButtonState.Pressed)
                if (exitRect.Contains(mouseState.X, mouseState.Y))
                    Exit();

            if (exitRect.Contains(pacLocation))
                Exit();



            

            for (int i = 0; i < coins.Count; i++)
            {
                if (pacLocation.Intersects(coins[i]))
                {
                    coins.RemoveAt(i);
                    i--;
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            _spriteBatch.Begin();


            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);

           
            _spriteBatch.Draw(exitTexture, exitRect, Color.White);

            foreach (Rectangle coin in coins)
                _spriteBatch.Draw(coinTexture, coin, Color.White);
            foreach (Rectangle barrier in barriers)
                _spriteBatch.Draw(barrierTexture, barrier, Color.White);



            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
