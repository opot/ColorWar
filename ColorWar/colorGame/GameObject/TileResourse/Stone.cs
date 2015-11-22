using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ColorWar.colorGame.GameObject.TileResourse {
	class Stone : TileObject {
		public Stone(ContentManager content) : base(content, TileType.Stone){
			texture = content.Load<Texture2D>("texture/game/resource/stone");
		}
	}
}