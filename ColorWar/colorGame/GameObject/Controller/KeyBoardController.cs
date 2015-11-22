using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;

using ColorWar.colorGame.GameObject.Controller;

namespace ColorWar.colorGame.GameObject.Controller {
	class KeyBoardController : Controller {
		public override void update() {
			KeyboardState keyboard = Keyboard.GetState();
			if (keyboard.IsKeyDown(Keys.Up))
				queue.Enqueue(PlayerAction.Up);
			if (keyboard.IsKeyDown(Keys.Down))
				queue.Enqueue(PlayerAction.Down);
			if (keyboard.IsKeyDown(Keys.Left))
				queue.Enqueue(PlayerAction.Left);
			if (keyboard.IsKeyDown(Keys.Right))
				queue.Enqueue(PlayerAction.Right);

		}
	}
}
