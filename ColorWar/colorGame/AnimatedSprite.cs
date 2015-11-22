using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject;

namespace ColorWar.colorGame {
	class AnimatedSprite {

		private Texture2D[] frames;
		private int AnimID = 0;
		public bool AnimActive = true;
		private float AnimSpeed;

		private int width, height;
		private Point size;
		private Vector2 origin;

		private float deltaTime = 0;

		public AnimatedSprite(Texture2D texture, int width, int height, float speed) {
			frames = Split(texture, width);
			this.AnimSpeed = speed;
			this.width = width;
			this.height = height;
			size = new Point(width, height);
			origin = new Vector2(width/2, height/2);
		}
	
		public void update(float delta) {
			if (AnimActive) {
				deltaTime += delta;
				if(deltaTime >= AnimSpeed) {
					deltaTime -= AnimSpeed;
					AnimID++;
					AnimID = AnimID % frames.Length;
				}
			}
		}

		public void draw(SpriteBatch batch, Point position, float angle) {
			//batch.Draw(frames[AnimID], new Rectangle(position, size), new Rectangle(position, size), Color.White, angle, origin, SpriteEffects.None, 0);
			batch.Draw(frames[AnimID], new Rectangle(position, size), Color.White);
        }

		private Texture2D[] Split(Texture2D original, int width) {
			int xCount = original.Width / width;
			Texture2D[] r = new Texture2D[xCount];
			int dataPerPart = width * width;

			Color[] originalData = new Color[original.Width * original.Height];
			original.GetData<Color>(originalData);

			int index = 0;
			for (int x = 0; x < xCount * width; x += width) {
				Texture2D part = new Texture2D(original.GraphicsDevice, width, width);
				Color[] partData = new Color[dataPerPart];

				for (int py = 0; py < width; py++)
					for (int px = 0; px < width; px++) {
						int partIndex = px + py * width;
						if (py >= original.Height || x + px >= original.Width)
							partData[partIndex] = Color.Transparent;
						else
							partData[partIndex] = originalData[(x + px) + py * original.Width];
					}
				part.SetData<Color>(partData);
				r[index++] = part;
			}
			return r;
		}

	}
}
