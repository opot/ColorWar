using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
namespace ColorWar.colorGame.GameObject.TileBuilding {
	class Bomb : TileObject {

		private float time = 3;
		private int x, y;

		public Bomb(ContentManager content, int x, int y) : base(content, TileType.Bomb) {
			texture = content.Load<Texture2D>("texture/game/buildings/bomb");
			this.x = x;
			this.y = y;
		}

		public bool update(float delta) {
			time -= delta;
			if(time <= 0) {
				Tile[,] tiles = GamePlayState.tiles;
				if (x - 1 >= 0) {
					Tile buf = tiles[x - 1, y];
					tiles[x - 1, y] = getFloor(x - 1, y);
					tiles[x - 1, y].tryToPlace(buf.getHere() as Bomb);
				}
				if (x + 1 < GamePlayState.size) {
					Tile buf = tiles[x + 1, y];
					tiles[x + 1, y] = getFloor(x + 1, y);
					tiles[x + 1, y].tryToPlace(buf.getHere() as Bomb);
				}
				if (y - 1 >= 0) {
					Tile buf = tiles[x - 1, y];
					tiles[x, y - 1] = getFloor(x y - 1);
					tiles[x, y - 1].tryToPlace(buf.getHere() as Bomb);
				}
				if (y + 1 < GamePlayState.size) {
					Tile buf = tiles[x + 1, y];
					tiles[x, y + 1] = getFloor(x, y + 1);
					tiles[x, y + 1].tryToPlace(buf.getHere() as Bomb);
				}
				return true;
			}
			return false;
		}

		private Tile getFloor(int x, int y) {
			return new Tile(GamePlayState.floorTex, Color.Gray,
										x * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceWidth,
										y * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceHeight, false);
        }

		private Tile getWall(int x, int y) {
			return new Tile(GamePlayState.wallTex, Color.White,
										x * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceWidth,
										y * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceHeight, true);
        }

	}
}