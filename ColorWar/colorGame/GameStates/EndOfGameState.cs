using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.Controller;
using System;

namespace ColorWar.colorGame.GameStates {
	class EndOfGameState : GameState {

		public static bool redWin = false;//0 - red, 1 - blue 
		private Rectangle rect = new Rectangle(0, 0, ColorGame.WIDTH, ColorGame.HEIGHT);
		Texture2D backWinRed, backWinBlue;

		public override void draw(SpriteBatch batch) {
			if (redWin)
				batch.Draw(backWinRed, rect, Color.White);
			else
				batch.Draw(backWinBlue, rect, Color.White);
		}

		public override void enter() {}

		public override void init(ColorGame game) {
			backWinRed = game.Content.Load<Texture2D>("texture/game/RedWin");
			backWinBlue = game.Content.Load<Texture2D>("texture/game/BlueWin");
		}

		public override void update(float delta, ColorGame game) {
			KeyboardState keyboard = Keyboard.GetState();
			Keys[] pressed = keyboard.GetPressedKeys();
			foreach (Keys key in pressed)
				if (key == Keys.Escape)
					game.enterState(GameType.MainMenu);
		}
	}
}
