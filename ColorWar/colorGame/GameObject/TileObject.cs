using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using ColorWar.colorGame.GameObject.TileResourse;

namespace ColorWar.colorGame.GameObject {
	public enum TileType {
		Wood = 0, Iron = 2, Stone = 1, Gold = 3, Door = 4, Bomb = 5
	}
	abstract class TileObject {

		public TileType type;
		protected Texture2D texture;
		private static Random rand = new Random();

		public TileObject(ContentManager content, TileType type) {
			this.type = type;
		}

		public void draw(SpriteBatch batch, Rectangle rect) {
			batch.Draw(texture, rect, Color.White);
		}

		public static TileObject getRandomRes(ContentManager content) {
			int seed = rand.Next(4);
			switch (seed) {
				case 0: return new Wood(content);
				case 1: return new Iron(content);
				case 2: return new Stone(content);
				case 3: return new Gold(content);
			}
			return null;
		}

	}
}
