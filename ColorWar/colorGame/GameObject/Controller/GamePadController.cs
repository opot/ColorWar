using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;

using ColorWar.colorGame.GameObject.Controller;
using System;

namespace ColorWar.colorGame.GameObject.Controller {
	class GamePadController : Controller {
		public override void update() {
			GamePadState gamepad = GamePad.GetState(0);
			if (gamepad.DPad.Up == ButtonState.Pressed)
				queue.Enqueue(PlayerAction.Up);
			if (gamepad.DPad.Down == ButtonState.Pressed)
				queue.Enqueue(PlayerAction.Down);
			if (gamepad.DPad.Left == ButtonState.Pressed)
				queue.Enqueue(PlayerAction.Left);
			if (gamepad.DPad.Right == ButtonState.Pressed)
				queue.Enqueue(PlayerAction.Right);
		}
	}
}
