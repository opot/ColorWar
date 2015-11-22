using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
namespace ColorWar.colorGame.GameObject.TileBuilding {
	class Door : TileObject {

		private Player owner;

		public Door(ContentManager content,Player owner) : base(content, TileType.Door) {
			texture = content.Load<Texture2D>("texture/game/building/door");
		}

		public bool canStep(Player player)  {
			return player == owner;
		}

		public void changeOwner(Player player) {
			this.owner = player;
		}
	}
}