using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.Controller;

namespace ColorWar.colorGame.GameObject {
	class Tile {

		private int SIZE = 26;

		private Color color;
		private Texture2D texture;
		private Rectangle rect;

		public bool isWall;
		bool playerHere = false;

		TileObject here = null;

		public Tile(Texture2D texture, Color color, int x, int y, bool isWall) {
			this.texture = texture;
			this.color = color;
			this.isWall = isWall;
			rect = new Rectangle(x, y, SIZE, SIZE);
		}

		public void draw(SpriteBatch batch) {
			batch.Draw(texture, rect, color);
			if (here != null)
				here.draw(batch, rect);
		}

		public void changeColor(Color color) {
			this.color = color;
		}

		public Color getColor() {
			return color;
		}

		public void setPlayerHere(bool isHere) {
			playerHere = isHere;
		}

		public TileObject getResource() {
			if (here != null)
				if ((int)here.type <= 3) {
					TileObject buf = here;
					here = null;
					return buf;
				}
			return null;
		}

		public bool tryToPlace(TileObject here) {
			if(this.here == null && !playerHere && !isWall) {
				this.here = here;
				return true;
			}
			return false;
		}

		public bool canStep() {
			return !isWall && !playerHere;
		}

	}
}
