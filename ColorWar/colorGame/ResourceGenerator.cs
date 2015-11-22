using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.TileResourse;
using Microsoft.Xna.Framework.Content;

namespace ColorWar.colorGame {
	class ResourceGenerator {

		private float GoalTime = 1;
		private float dTime = 0;
		private static Random rand = new Random();

		private ContentManager content;

		public ResourceGenerator(ContentManager content) {
			this.content = content;
		}

		public void update(float delta) {
			dTime += delta;
			if (dTime >= GoalTime) {
				dTime = 0;
				GoalTime = rand.Next(300) / 100f;
				TileObject to = TileObject.getRandomRes(content);

				bool isPlaced = false;
				while (!isPlaced) {
					int x = rand.Next(25);
					int y = rand.Next(25);
					Tile tile = GamePlayState.tiles[x, y];
					if (tile.tryToPlace(to))
						isPlaced = true;
				}

			}
		}

	}
}
