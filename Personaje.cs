using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// Clase que administra el personaje gráfico 2D
    /// </summary>
    class Personaje
    {
        #region Propiedades
        
        // Creo las propiedades que son necesarias para crear el personaje (bitmap, rectangle, velocidad, activo)
        private Texture2D bitmap;
        private Rectangle rectangulo;
        private Vector2 velocidad;
        private Boolean activo;
        private int ANCHO, ALTO;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicia los parámetros del personaje
        /// </summary>
        /// <param name="sprite"> Mapa de birs que se va a dibujar </param>
        /// <param name="x"> Posición inicial en X </param>
        /// <param name="y"> oosición inicial en Y </param>
        /// <param name="velX"> Velocidad en X </param>
        /// <param name="velY"> Velocidad en Y </param>
        /// <param name="ANCHO"> Ancho de la ventana </param>
        /// <param name="ALTO"> Alto de la ventana </param>
        public Personaje( Texture2D sprite, int x, int y, int velX, int velY, int ANCHO, int ALTO ) {
            bitmap = sprite;
            rectangulo = new Rectangle(x, y, sprite.Width, sprite.Height);
            velocidad = new Vector2((float)velX, (float)velY);
            activo = true;
            // El this hace referencia al elemento del constructor
            this.ANCHO = ANCHO;
            this.ALTO = ALTO;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Mueve el personaje, según su velocidad, y rebota en las orillas de la ventana
        /// </summary>
        public void Update() {
            // Muevo el personaje
            rectangulo.X += (int)velocidad.X;
            rectangulo.Y += (int)velocidad.Y;

            // Rebote en las orillas
            // En Y
            if (rectangulo.Y + bitmap.Height >= ALTO || rectangulo.Y < 0)
            {
                velocidad.Y = -velocidad.Y;
            }
            // En X
            if (rectangulo.X + bitmap.Width >= ANCHO || rectangulo.X < 0)
            {
                velocidad.X = -velocidad.X;
            }

        }
        /// <summary>
        /// Creo el método draw que 
        /// </summary>
        /// <param name="sb"> requiero el objeto spritebatch para procesar el sprite </param>
        public void Draw(SpriteBatch sb) {

            //  Dibjar el sprite solo si está activo
            if (activo)
            {
                sb.Draw(bitmap, rectangulo, Color.White);
            }
        
        }

        #endregion

    }
}
