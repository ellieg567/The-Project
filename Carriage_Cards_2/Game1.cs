using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Carriage_Cards_2
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Rectangle whiteCard;
		Texture2D whiteCardTexture;

		Rectangle orangeCard;
		Texture2D orangeCardTexture;

		KeyboardState kb, oldkb;

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
			whiteCard = new Rectangle(5, 350, 225, 125);
			whiteCardTexture = Content.Load<Texture2D>("white card");

			orangeCard = new Rectangle(5, 350, 225, 125);
			orangeCardTexture = Content.Load<Texture2D>("orange card");
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
			kb = Keyboard.GetState();

			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();


			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{

			GraphicsDevice.Clear(Color.CornflowerBlue);


			int[] cardOrder = new int[23];
			int topCard = 0;

			// TODO: Add your drawing code here
			spriteBatch.Begin();

			for (int i = 0; i < 24; i++)
			{
				Random myRandom = new Random();
				int randomCard = 0;
				randomCard = myRandom.Next(1, 2);

				if (randomCard == 1)
				{
					spriteBatch.Draw(whiteCardTexture, whiteCard, Color.White);
					cardOrder[i] = 1;
					topCard = 1;
				}
				if (randomCard == 2)
				{
					spriteBatch.Draw(orangeCardTexture, orangeCard, Color.White);
					cardOrder[i] = 2;
					topCard = 2;
				}

			}
			spriteBatch.End();

			for (int j = 23; j > -1; j--)
			{
				if (kb.IsKeyDown(Keys.Right))
				{
					if (topCard == 1)
					{
						whiteCard.X += 1000;
						topCard = cardOrder[j - 1];
					}
   				}
				if (kb.IsKeyDown(Keys.Right))
				{
					if (topCard == 2)
					{
						orangeCard.X += 1000;
						topCard = cardOrder[j - 1];
					}
				}
			}

			base.Draw(gameTime);

			//if (kb.IsKeyDown(Keys.Right))
			//{
			//	whiteCard.X += 1000;
			//}

			//if (kb.IsKeyDown(Keys.Right))
			//{
			//	orangeCard.X += 1000;
			//}
		}
	}
}
