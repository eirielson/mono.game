using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace lab.mono.game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Vector2 centroTela;
        private List<ISprite> sprites;
        private ISprite agulha;
        private ISprite compasso;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            this.agulha = new SpriteDefault("agulha");
            this.compasso = new SpriteDefault("compasso");
            sprites = new List<ISprite> { compasso, agulha };
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

            var viewport = graphics.GraphicsDevice.Viewport;
            centroTela = new Vector2(viewport.Width, viewport.Height) / 2f;

            sprites.ForEach(sprite =>
            {
                sprite.OrigemCentralizada = true;
                sprite.Posicao = centroTela;
                sprite.LoadContent(Content);
                sprite.Escala = 0.5f;
            });

            agulha.Posicao = centroTela + new Vector2(0, 10);
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
            var tempoDecorrido = (float)gameTime.ElapsedGameTime.TotalSeconds;
            agulha.Rotacao += tempoDecorrido;
            agulha.Rotacao %= MathHelper.TwoPi;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            sprites.ForEach(sprite => sprite.Draw(spriteBatch));
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
