using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ColorWar.colorGame.GameObject.TileResourse {
	class Gold : TileObject {

		public Gold(ContentManager content) : base(content, TileType.Gold){
			texture = content.Load<Texture2D>("texture/game/resource/gold");
		}
	}
}