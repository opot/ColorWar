using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using ColorWar.colorGame.GameStates;
using ColorWar.colorGame.GameObject.Controller;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ColorWar.colorGame.GameObject.TileResourse {
	class Wood : TileObject {

		public Wood(ContentManager content) : base(content, TileType.Wood){
			texture = content.Load<Texture2D>("texture/game/resource/wood");
		}
    }
}
