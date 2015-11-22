using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ColorWar.colorGame;

namespace ColorWar.colorGame.GameStates {
	abstract class GameState {

		public abstract void enter();
		public abstract void init(ColorGame game);
		public abstract void draw(SpriteBatch batch);
		public abstract void update(float delta, ColorGame game);

	}
}
