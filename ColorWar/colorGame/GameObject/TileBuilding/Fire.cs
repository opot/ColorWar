using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ColorWar.colorGame.GameStates;
using Microsoft.Xna.Framework;

namespace ColorWar.colorGame.GameObject.TileBuilding {
	class Fire : TileObject {

		AnimatedSprite sprite;
		private int x, y;
		private float time = 1;

		private new static Texture2D texture;

		public Fire(int x, int y) : base(null, TileType.Fire) {
			sprite = new AnimatedSprite(texture, 26, 26, 0.1f);
			this.x = x;
			this.y = y;
		}

		public override void draw(SpriteBatch batch, Rectangle rect) {
			sprite.draw(batch, rect.Location, 0);
		}

		public static void setTexture(Texture2D texture) {
			Fire.texture = texture;
		}

		public bool update(float delta) {
			time -= delta;
			sprite.update(delta);
			if (time <= 0)
				return true;
			return false;
		}
	}
}
