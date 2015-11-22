using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorWar.colorGame.GameObject {
	static class LabirinthGenerator {

		public static bool[][] generate(int size) {
			bool[][] field = new bool[size][];
			int[,] random = new int[,] { { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
							   { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
							   { 1, 1, 0, 1, 0, 1, 1, 0, 1, 1 } };

			for (int i = 0; i < size; i++) {
				field[i] = new bool[size];
				for (int j = 0; j < size; j++)
					field[i][j] = false;
			}

			int curX, curY;
			Random r = new Random();
			field[0][0] = true;
			for (int k = 0; k < 3; k++) {
				curX = 0;
				curY = 0;
				while (curX < size - 1 && curY < size - 1) {
					int temp = r.Next(10);
					if (random[k, temp] == 0)
						curY++;
					else
						curX++;
					field[curX][curY] = true;
				}

				while (curX < size - 1) {
					curX++;
					field[curX][curY] = true;
				}

				while (curY < size - 1) {
					curY++;
					field[curX][curY] = true;
				}
			}


			field[size - 1][0] = true;
			for (int k = 0; k < 3; k++) {
				curX = size - 1;
				curY = 0;
				while (curX > 0 && curY < size - 1) {
					int temp = r.Next(10);
					if (random[k, temp] == 0)
						curY++;
					else
						curX--;
					field[curX][curY] = true;
				}

				while (curX > 0) {
					curX--;
					field[curX][curY] = true;
				}

				while (curY < size - 1) {
					curY++;
					field[curX][curY] = true;
				}
			}



			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++) {
					int temp = r.Next(11);
					if (temp % 7 == 0)
						field[i][j] = true;
				}


			return field;
		}

	}
}
