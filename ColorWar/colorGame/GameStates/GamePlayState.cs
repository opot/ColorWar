using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.Controller;

namespace ColorWar.colorGame.GameStates {
	sealed class GamePlayState : GameState {

		public static Tile[,] tiles;
		public static int size = 25;

		Texture2D wallTex, floorTex, redPlayerTex, bluePlayerTex;

		Player redPlayer, bluePlayer;
		ResourceGenerator ResGen;

		public override void init(ColorGame game) {
			floorTex = game.Content.Load<Texture2D>("texture/game/floor");
			wallTex = game.Content.Load<Texture2D>("texture/game/wall");
			redPlayerTex = game.Content.Load<Texture2D>("texture/game/RedPlayer");
			bluePlayerTex = game.Content.Load<Texture2D>("texture/game/BluePlayer");
			ResGen = new ResourceGenerator(game.Content);
        }

		public override void enter() {
			tiles = new Tile[size, size];

			bool[][] maze = LabirinthGenerator.generate(size);
			tiles = new Tile[size, size];
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					if(maze[i][j])
						tiles[i, j] = new Tile(floorTex, Color.Gray, i*(ColorGame.HEIGHT - ColorGame.InterfaceHeight)/size + ColorGame.InterfaceWidth, 
																							j* (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceHeight, false);
					else
						tiles[i, j] = new Tile(wallTex, Color.White, i * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceWidth,
																							j * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceHeight, true);

			redPlayer = new Player(0, 0, redPlayerTex, new KeyBoardController(), new Color(190,0,0));
			bluePlayer = new Player(size - 1, size - 1, bluePlayerTex, new GamePadController(), new Color(0, 0, 190));
		}

		public override void draw(SpriteBatch batch) {
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					tiles[i, j].draw(batch);

			redPlayer.draw(batch);
			bluePlayer.draw(batch);
        }

		public override void update(float delta, ColorGame game) {
			ResGen.update(delta);
			redPlayer.update(delta);
			bluePlayer.update(delta);
		}
	}
}
