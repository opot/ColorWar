using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using ColorWar.colorGame;
using ColorWar.colorGame.GameObject;
using ColorWar.colorGame.GameObject.Controller;
using System;
using Microsoft.Xna.Framework.Content;

namespace ColorWar.colorGame.GameStates {

	sealed class Counter {
		private int count = 1;

		public void inc() {
			count++;
		}

		public void dec() {
			count--;
		}

		public float getPer(int size) {
			if(size!=0)
				return (1000 * count / size)/10f;
			return 0;
		}

	}

	sealed class GamePlayState : GameState {

		public static Tile[,] tiles;
		private Counter redCounter, blueCounter;
		public static int tileCount;

		public static int size = 25;
		public static int time = 3;

		public static Texture2D wallTex, floorTex, redPlayerTex, bluePlayerTex;
		Texture2D interTex;
		public static ContentManager content;
		SpriteFont font;

		Player redPlayer, bluePlayer;
		ResourceGenerator ResGen;
		GameInterface gameInterface;
		DateTime startTime;



		public override void init(ColorGame game) {
			floorTex = game.Content.Load<Texture2D>("texture/game/floor");
			wallTex = game.Content.Load<Texture2D>("texture/game/wall");
			redPlayerTex = game.Content.Load<Texture2D>("texture/game/RedPlayer");
			bluePlayerTex = game.Content.Load<Texture2D>("texture/game/BluePlayer");
			interTex = game.Content.Load<Texture2D>("texture/game/interface");
			font = game.Content.Load<SpriteFont>("Font/SpriteFont");
			ResGen = new ResourceGenerator(game.Content);
			content = game.Content;
        }

		public override void enter() {
			tiles = new Tile[size, size];

			bool[][] maze = LabirinthGenerator.generate(size);
			tiles = new Tile[size, size];
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					if(maze[i][j])
						tiles[i, j] = new Tile(floorTex, Color.Gray,
										i*(ColorGame.HEIGHT - ColorGame.InterfaceHeight)/size + ColorGame.InterfaceWidth, 
										j* (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceHeight, false);
					else
						tiles[i, j] = new Tile(wallTex, Color.White, 
										i * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceWidth,
										j * (ColorGame.HEIGHT - ColorGame.InterfaceHeight) / size + ColorGame.InterfaceHeight, true);
			tileCount = 0;
			used = new bool[size, size]; 
			dfs(0, 0);
			redCounter = new Counter();
			blueCounter = new Counter();
			redPlayer = new Player(0, 0, redPlayerTex, new KeyBoardController(), new Color(190,0,0), redCounter, blueCounter);
			bluePlayer = new Player(size - 1, size - 1, bluePlayerTex, new GamePadController(), new Color(0, 0, 190), blueCounter, redCounter);
			gameInterface = new GameInterface(interTex, font, redPlayer, bluePlayer, redCounter, blueCounter, tileCount);
			startTime = DateTime.Now;
		}

		public override void draw(SpriteBatch batch) {
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					tiles[i, j].draw(batch);

			redPlayer.draw(batch);
			bluePlayer.draw(batch);
			gameInterface.draw(batch, new TimeSpan(0,(time-1) - (DateTime.Now.Minute - startTime.Minute), 
													60 - (DateTime.Now.Second - startTime.Second)));
		}

		public override void update(float delta, ColorGame game) {
			ResGen.update(delta);
			redPlayer.update(delta);
			bluePlayer.update(delta);

			KeyboardState keyboard = Keyboard.GetState();
			Keys[] pressed = keyboard.GetPressedKeys();
			foreach (Keys key in pressed)
				if (key == Keys.Escape)
					game.enterState(GameType.MainMenu);

			if (DateTime.Now.Second - startTime.Second == 0 && DateTime.Now.Minute - startTime.Minute == time) {
				EndOfGameState.redWin = (redCounter.getPer(tileCount) > blueCounter.getPer(tileCount));
				game.enterState(GameType.EndOfGame);
			}
		}

		bool[,] used = new bool[size, size];
		private void dfs(int x, int y) {
			if (!tiles[x, y].isWall && !used[x,y]) {
				tileCount++;
				used[x, y] = true;
				if (x > 0)
					dfs(x - 1, y);
				if (y > 0)
					dfs(x, y - 1);
				if (x < size - 1)
					dfs(x + 1, y);
				if (y < size - 1)
					dfs(x, y + 1);
			}
		}

	}
}
