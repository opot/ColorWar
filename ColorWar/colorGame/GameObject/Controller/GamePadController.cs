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
			if (gamepad.DPad.Up == ButtonState.Pressed && !queue.Contains(PlayerAction.Up))
				queue.Enqueue(PlayerAction.Up);
			if (gamepad.DPad.Down == ButtonState.Pressed && !queue.Contains(PlayerAction.Down))
				queue.Enqueue(PlayerAction.Down);
			if (gamepad.DPad.Left == ButtonState.Pressed && !queue.Contains(PlayerAction.Left))
				queue.Enqueue(PlayerAction.Left);
			if (gamepad.DPad.Right == ButtonState.Pressed && !queue.Contains(PlayerAction.Right))
				queue.Enqueue(PlayerAction.Right);       

			if (gamepad.IsButtonDown(Buttons.A) && !queue.Contains(PlayerAction.Key))
				queue.Enqueue(PlayerAction.Key); 
			if (gamepad.IsButtonDown(Buttons.B) && !queue.Contains(PlayerAction.BuildBomb))
				queue.Enqueue(PlayerAction.BuildBomb);
			if (gamepad.IsButtonDown(Buttons.X) && !queue.Contains(PlayerAction.BuidWall))
				queue.Enqueue(PlayerAction.BuidWall);
			if (gamepad.IsButtonDown(Buttons.Y) && !queue.Contains(PlayerAction.BuildDoor))
				queue.Enqueue(PlayerAction.BuildDoor);
		}
	}
}
