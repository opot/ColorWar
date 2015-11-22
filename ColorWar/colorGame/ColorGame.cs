using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;

namespace ColorWar.colorGame {
	public enum GameType {
		MainMenu = 0, Game = 1
	}

	public sealed class ColorGame : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SpriteFont font;

		public static int WIDTH = 1280;
		public static int HEIGHT = 720;
		public static int InterfaceHeight = 70;
		public static int InterfaceWidth = (WIDTH - (HEIGHT - InterfaceHeight)) / 2;

		List<GameState> states;
		GameState CurrectState;

		public ColorGame() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {

			graphics.PreferredBackBufferHeight = HEIGHT;
			graphics.PreferredBackBufferWidth = WIDTH;
			//graphics.ToggleFullScreen();
			states = new List<GameState>();

			states.Add(new MainMenuState());
			states.Add(new GamePlayState());

			enterState(GameType.MainMenu);
			base.Initialize();
		}

		protected override void LoadContent() {

			spriteBatch = new SpriteBatch(GraphicsDevice);

			font = Content.Load<SpriteFont>("Font/SpriteFont");
			foreach (GameState state in states)
				state.init(this);
		}

		protected override void UnloadContent() {}

		protected override void Update(GameTime gameTime) {
		
			CurrectState.update((float)(gameTime.ElapsedGameTime.Milliseconds / 1000.0), this);
			
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();
			CurrectState.draw(spriteBatch);
			spriteBatch.DrawString(font, ((float)(gameTime.ElapsedGameTime.Milliseconds / 1000.0)).ToString(), new Vector2(0, 0), Color.Black);
			spriteBatch.End();

			base.Draw(gameTime);
		}

		public void enterState(GameType type) {
			CurrectState = states[(int)type];
			CurrectState.enter();
		}

	}
}
