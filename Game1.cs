using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        #endregion

        // SPRITES

        // 1. Debo declarar una textura para poder dibujar en este caso 2d ...
        // ... la Textura del personaje o el personaje mejor dicho
        Texture2D pj1;
        // 2. Definir el área contenedor de la textura
        Rectangle cuadroContenedor;
        // 3. Paso a la función LoadContent ..............----> ........


        // MOVIENDO SPRITES
        // 1. Creo la variable Velocidad que es un vector
        Vector2 Velocidad;
        // 2. Voy a loadContent();
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


            // SPRITES 
            // 3. Cargar la imagen a mi Texture2D, para ello debemos usar el archivo ...
            // content.mgcb ver archivo ... 
            // Lo mejor es usar el monogame pipeline y agregar los archivos de contenido al proyecto y guardar

            // 4. Cargo la textura
            pj1 = Content.Load<Texture2D>("pj1");

            // 5. Trabajo sobre el rectángulo canvas que se llama cuadroContenedor
            // Hay varias formas de llenarlo, en este caso se definen los valores de forma ...
            // ... manual contando la posición en la pantalla y el ancho  x el alto

            /* cuadroContenedor = new Rectangle(150, 150, 43, 57); */

            // o también así 
            cuadroContenedor = new Rectangle(150, 150, pj1.Width, pj1.Height);

            // 6. Voy a la función Draw y uso el objeto spriteBatch


            /*MOVER SPRITES*/
            // 2. Voy a loadContent(); seteo la variable para asignar la velocidad
            Velocidad = new Vector2(2, 2);
            // 3. Voy al Update()
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
      
            /*MOVER SPRITES*/

            // 3. Voy al Update() y uso el objeto cuadroContenedor que es el sprite renderizado y le aumento la velocidad
            // Nota el paréntesis int hace una conversión de un tipo de dato flotante
            // a un entero en este caso
            cuadroContenedor.X += (int) Velocidad.X;
            cuadroContenedor.Y += (int)Velocidad.Y;
            // Hacer que reboten con los bordes
            // En Y
            if (cuadroContenedor.Y + pj1.Height >= ALTO || cuadroContenedor.Y < 0 ) {
                Velocidad.Y = -Velocidad.Y;
            }
            // En X
            if (cuadroContenedor.X + pj1.Width >= ANCHO || cuadroContenedor.X < 0)
            {
                Velocidad.X = -Velocidad.X;
            }


            // DESDE LA CLASE PERSONAJE
            Digger.Update();

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

            // PAra dibujar 
            // Usa 3 parámetros, el sprite que creamos, el canvas donde dibuja, y el tono
            spriteBatch.Draw(pj1, cuadroContenedor, Color.White);
            // Para decirle que copie al buffer y lo  ponga en la pantalla
            // EL personaje de la clase personaje
            Digger.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
