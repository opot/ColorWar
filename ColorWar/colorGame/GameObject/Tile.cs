using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorWar.colorGame.GameObject {
	class Tile {

		private int SIZE = 26;

		private Color color;
		private Texture2D texture;
		private Rectangle rect;

		bool isWall;

		public Tile(Texture2D texture, Color color, int x, int y, bool isWall) {
			this.texture = texture;
			this.color = color;
			this.isWall = isWall;
			rect = new Rectangle(x, y, SIZE, SIZE);
		}

		public void draw(SpriteBatch batch) {
			batch.Draw(texture, rect, color);
		}

		public void changeColor(Color color) {
			this.color = color;
		}

		public bool canStep() {
			return !isWall;
		}

	}
}
