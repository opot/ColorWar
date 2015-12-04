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
			if (keyboard.IsKeyDown(Keys.Up)&&!queue.Contains(PlayerAction.Up))
				queue.Enqueue(PlayerAction.Up);
			if (keyboard.IsKeyDown(Keys.Down)&&!queue.Contains(PlayerAction.Down))
				queue.Enqueue(PlayerAction.Down);
			if (keyboard.IsKeyDown(Keys.Left) && !queue.Contains(PlayerAction.Left))
				queue.Enqueue(PlayerAction.Left);
			if (keyboard.IsKeyDown(Keys.Right) && !queue.Contains(PlayerAction.Right))
				queue.Enqueue(PlayerAction.Right);


			foreach(Keys k in keyboard.GetPressedKeys()) {
				switch (k){
					case Keys.Z: { queue.Enqueue(PlayerAction.BuildDoor); return; }
					case Keys.X: { queue.Enqueue(PlayerAction.BuildBomb); return; }
					case Keys.C: { queue.Enqueue(PlayerAction.BuidWall); return; }
					case Keys.V: { queue.Enqueue(PlayerAction.Key); return; }
				}
			}
		}
	}
}
