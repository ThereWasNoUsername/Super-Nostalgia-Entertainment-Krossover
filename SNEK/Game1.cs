﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SNEK {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        World world;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1920; //GraphicsDevice.Viewport.Width;
            graphics.PreferredBackBufferHeight = 1080; // GraphicsDevice.Viewport.Height;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            world = new World(1920/16, 1080/16);
            var p = new Player(new Point(world.width / 2, world.height / 2));
            world.Add(p);
            world.Add(new Spawner(p));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Sprites.Initialize(this.Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            try {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                else if(Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                    Initialize();
                }
                world.Update();
                base.Update(gameTime);
            } catch(Exception e) {
                Console.WriteLine(e);
                Exit();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            try {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                world.Draw(spriteBatch);
                spriteBatch.End();

                base.Draw(gameTime);
            } catch(Exception e) {
                Console.WriteLine(e);
                Exit();
                
            }
        }
    }
}
