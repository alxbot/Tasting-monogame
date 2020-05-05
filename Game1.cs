using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // TAMAÑO DE PANTALLA

        const int ANCHO = 800;
        const int ALTO = 600;

        #region
        // Creo personaje ya desde la clase que creé
        Personaje Digger;
        // Crearé grupos de personajes a través de una lista
        List<Personaje> lista = new List<Personaje>();
        string[] personajes = {"pj1", "pj2", "pj3", "pj4", "pj5", "pj6" };
        // debo definir cuantos personajes crearé
        const int CANTIDAD_PERSONAJES = 6;
        #endregion

        // SPRITES

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Cambiar el tamaño de la ventana se hace desde el constructor
                // Defino el ancho de la pantalla
            graphics.PreferredBackBufferWidth = ANCHO;
                // Defino el alto de la pantalla
            graphics.PreferredBackBufferHeight = ALTO;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Personaje propio
            Digger = new Personaje(Content.Load<Texture2D>("pj2"),150,150,10,10,ANCHO, ALTO);

            for (int i = 0; i < personajes.Length ; i++) {
                lista.Add(new Personaje(Content.Load<Texture2D>(personajes[i]), 10 * i, 10 * i, 10, 10, ANCHO, ALTO));
            }
    
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
      
            // DESDE LA CLASE PERSONAJE
            Digger.Update();

            foreach(Personaje x in lista )
            {

                x.Update();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // 6. Voy a la función Draw y uso el objeto spriteBatch
                // Para decirle aquí empiezo a dibujar
            spriteBatch.Begin();
            // EL personaje de la clase personaje
            Digger.Draw(spriteBatch);
            foreach (Personaje x in lista)
            {
                x.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
