using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;

namespace ColorWar.colorGame.GameObject {
	class Player {

		int x, y;
		private int angle = 0;
		AnimatedSprite sprite;
		Color color;

		float dx = 0, dy = 0;
		float dSpeed = 416;

		Controller.Controller control;

		public Player(int x, int y, Texture2D texture, Controller.Controller control, Color color) {
			this.control = control;
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
					if (y > 0 && GamePlayState.tiles[x, y - 1].canStep())
						ddy = -1;
				if (action == PlayerAction.Down)
						if (y < GamePlayState.size - 1 && GamePlayState.tiles[x, y + 1].canStep())
							ddy = 1;
				if (action == PlayerAction.Left)
						if (x > 0 && GamePlayState.tiles[x - 1, y].canStep())
							ddx = -1;
				if (action == PlayerAction.Right)
						if (x < GamePlayState.size - 1 && GamePlayState.tiles[x + 1, y].canStep())
							ddx = 1;

				x += ddx;
				y += ddy;
				dx += -ddx * (ColorGame.HEIGHT - ColorGame.InterfaceHeight)/GamePlayState.size;
				dy += -ddy * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / GamePlayState.size;

				if (ddx != 0 || ddy!= 0) {
					sprite.AnimActive = true;
					GamePlayState.tiles[x, y].changeColor(color);
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
