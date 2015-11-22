using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorWar.colorGame.GameStates {
	class MainMenuState : GameState {

		Texture2D back;

		public override void init(ColorGame game) {
			back = game.Content.Load<Texture2D>("texture/menu/back");
		}

		public override void enter() {

		}

		public override void draw(SpriteBatch batch) {
			batch.Draw(back, new Rectangle(0, 0, ColorGame.WIDTH, ColorGame.HEIGHT), Color.White);
		}

		public override void update(float delta, ColorGame game) {
			KeyboardState keyboard = Keyboard.GetState();
			Keys[] pressed = keyboard.GetPressedKeys();
			foreach (Keys key in pressed)
				if (key == Keys.Space)
					game.enterState(GameType.Game);
		}
	}
}
