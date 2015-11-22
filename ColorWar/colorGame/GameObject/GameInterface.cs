using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.TileResourse;
using Microsoft.Xna.Framework.Content;

namespace ColorWar.colorGame.GameObject {
	class GameInterface {

		Player player1;
		Player player2;
		Texture2D back;
		SpriteFont font;

		Counter red;
		Counter blue;
		int count;

		private Rectangle rect = new Rectangle(0, 0, ColorGame.WIDTH, ColorGame.HEIGHT);

		public GameInterface(Texture2D back, SpriteFont font, Player player1, Player player2, Counter red, Counter blue, int count) {
			this.player1 = player1;
			this.player2 = player2;
			this.back = back;
			this.font = font;
			this.red = red;
			this.blue = blue;
			this.count = count;
		}

		public void draw(SpriteBatch batch, TimeSpan time) {
			batch.Draw(back, rect, Color.White);
			batch.DrawString(font, ((time.Minutes).ToString() + ":" + (time.Seconds).ToString()), new Vector2(ColorGame.WIDTH / 2 - 25, 10), Color.Black, 0, new Vector2(0, 0), 3, SpriteEffects.None, 0);
			for (int i = 0; i < 4; i++) {
				batch.DrawString(font, player1.Resources[i].ToString(), new Vector2(65, 535 + 35 * i), Color.Black, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
				batch.DrawString(font, player2.Resources[i].ToString(), new Vector2((ColorGame.HEIGHT - ColorGame.InterfaceHeight + ColorGame.InterfaceWidth) + 65, 535 + 35 * i), Color.Black, 0, new Vector2(0, 0), 1.5f, SpriteEffects.None, 0);
			}
			batch.DrawString(font, red.getPer(count).ToString()+"%", new Vector2(40, 15), Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
			batch.DrawString(font, blue.getPer(count).ToString()+"%", new Vector2((ColorGame.HEIGHT - ColorGame.InterfaceHeight + ColorGame.InterfaceWidth) + 40, 15), Color.Black, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
		}
	}
}
