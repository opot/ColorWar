using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using ColorWar.colorGame.GameObject.TileBuilding;

namespace ColorWar.colorGame.GameObject {
	class Player {

		int x, y;
		private int angle = 0;
		AnimatedSprite sprite;
		Color color;

		float dx = 0, dy = 0;
		float dSpeed = 416;

		public int[] Resources = {10, 10, 10, 10};
		public bool isKey = false;

		Counter myCounter;
		Counter enemyCounter;
	   Controller.Controller control;

		public Player(int x, int y, Texture2D texture, Controller.Controller control, Color color, Counter myCounter, Counter enemyCounter) {
			this.control = control;
			this.myCounter = myCounter;
			this.enemyCounter = enemyCounter;
			this.color = color;
			sprite = new AnimatedSprite(texture, 26, 26, 0.06f);
			sprite.AnimActive = false;
			this.x = x;
			this.y = y;
			GamePlayState.tiles[x, y].changeColor(color);
		}

		public void draw(SpriteBatch batch) {
			sprite.draw(batch, new Point((int)dx + x*26 + ColorGame.InterfaceWidth,(int)dy + y*26 + ColorGame.InterfaceHeight), angle);
		}

		public void update(float delta) {
			control.update();
			sprite.update(delta);

			PlayerAction action = control.getAction();

			if (dx == 0 && dy == 0) {
				sprite.AnimActive = false;
				int ddx = 0, ddy = 0;
				if (action == PlayerAction.Up)
					if (y > 0 && GamePlayState.tiles[x, y - 1].canStep(this))
						ddy = -1;
				if (action == PlayerAction.Down)
						if (y < GamePlayState.size - 1 && GamePlayState.tiles[x, y + 1].canStep(this))
							ddy = 1;
				if (action == PlayerAction.Left)
						if (x > 0 && GamePlayState.tiles[x - 1, y].canStep(this))
							ddx = -1;
				if (action == PlayerAction.Right)
						if (x < GamePlayState.size - 1 && GamePlayState.tiles[x + 1, y].canStep(this))
							ddx = 1;

				if(action == PlayerAction.BuidWall) {
					bool canBuy = true;
					for (int i = 0; i < 4; i++)
						if (Resources[i] < TileObject.WallCost[i])
							canBuy = false;

					if (canBuy) {
						for (int i = 0; i < 4; i++)
							Resources[i] -= TileObject.WallCost[i];
						GamePlayState.tiles[x, y] = new Tile(GamePlayState.wallTex, Color.White, 
													x * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceWidth,
													y * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size + ColorGame.InterfaceHeight, true);
						GamePlayState.tileCount--;
						myCounter.dec();
					}
				}

				if (action == PlayerAction.BuildDoor) {
					bool canBuy = true;
					for (int i = 0; i < 4; i++)
						if (Resources[i] < TileObject.DoorCost[i])
							canBuy = false;

					if (canBuy) {
						if(GamePlayState.tiles[x, y].tryToPlace(new Door(GamePlayState.content, this)))
							for (int i = 0; i < 4; i++)
								Resources[i] -= TileObject.DoorCost[i];
                    }
				}

				if (action == PlayerAction.BuildBomb) {
					bool canBuy = true;
					for (int i = 0; i < 4; i++)
						if (Resources[i] < TileObject.BombCost[i])
							canBuy = false;

					if (canBuy) {
						if (GamePlayState.tiles[x, y].tryToPlace(new Bomb(GamePlayState.content, x, y)))
							for (int i = 0; i < 4; i++)
								Resources[i] -= TileObject.BombCost[i];
					}
				}

				if (action == PlayerAction.Key) {
					bool canBuy = true;
					for (int i = 0; i < 4; i++)
						if (Resources[i] < TileObject.KeyCost[i])
							canBuy = false;

					if (canBuy && !isKey) {
						isKey = true;
						for (int i = 0; i < 4; i++)
							Resources[i] -= TileObject.KeyCost[i];
					}
				}

				GamePlayState.tiles[x, y].setPlayerHere(false);
				x += ddx;
				y += ddy;
				GamePlayState.tiles[x, y].setPlayerHere(true);
				dx += -ddx * (ColorGame.HEIGHT - ColorGame.InterfaceHeight)/GamePlayState.size;
				dy += -ddy * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size;

				if (ddx != 0 || ddy!= 0) {
					sprite.AnimActive = true;
					if(GamePlayState.tiles[x, y].getColor() != color) {
						myCounter.inc();
						if (GamePlayState.tiles[x, y].getColor() != Color.Gray)
							enemyCounter.dec();
                    }
					GamePlayState.tiles[x, y].changeColor(color);
					TileObject resource = GamePlayState.tiles[x, y].getResource();
					if (resource != null)
						Resources[(int)(resource.type)]++;
				}


			} else {
				if (dx != 0) {
					if (Math.Abs(dx) < delta * dSpeed)
						dx = 0;
					else
						dx -= delta * dSpeed * Math.Sign(dx);
				}
				if (dy != 0) {
					if (Math.Abs(dy) < delta * dSpeed)
						dy = 0;
					else
						dy -= delta * dSpeed * Math.Sign(dy);
				}

			}

		}

	}
}
