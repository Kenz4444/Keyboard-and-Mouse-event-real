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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pacLocation = new Rectangle(10, 10, 75, 75);
            window = new Rectangle(100, 200, 300, 800);

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



            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
