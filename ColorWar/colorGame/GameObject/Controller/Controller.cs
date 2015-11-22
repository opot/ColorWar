using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorWar.colorGame.GameObject.Controller {

	public enum PlayerAction {
		Up, Down, Left, Right, None
	}

	public abstract class Controller {

		protected Queue<PlayerAction> queue = new Queue<PlayerAction>();

		public abstract void update();

		public PlayerAction getAction() {
			if (queue.Count > 10)
				queue.Clear();

			if (queue.Count != 0)
				return queue.Dequeue();
			else
				return PlayerAction.None;

		}
	}
}
