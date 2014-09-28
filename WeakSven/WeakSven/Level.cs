using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WeakSven
{
    class Level
    {
        public List<Wall> Walls { get; private set; }
        public Dictionary<char, Texture2D> Textures {get; private set;}
        Rectangle BackgroundRect;
        public int x = 1600;
        public int y = 1200;
        public int CurrentLevel { get; private set; }

        SpriteFont font;

        public List<Platform> platforms;
        //TODO: Add lists for special platforms;

        public Level(List<Platform> newPlats)
        {
            Walls = new List<Wall>();
            Textures = new Dictionary<char, Texture2D>();
            platforms = newPlats;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Platform p in platforms)
            {
                if (Player.Instance.Rect.Intersects(p.rect))
                {
                     Player.Instance.Landed((int)p.startPosition.Y);
                     break;
                }
            }
        }

        public void Load(ContentManager Content)
        {
            LoadTextures(Content);
            foreach (Platform p in platforms)
            {
                p.Load(Content);
            }

            font = Content.Load<SpriteFont>("Font");
        }

        public void LoadTextures(ContentManager Content)
        {
            Textures.Add('q', Content.Load<Texture2D>("Textures/ComputerWall"));
            Textures.Add('w', Content.Load<Texture2D>("Textures/ComputerWall01"));
            Textures.Add('e', Content.Load<Texture2D>("Textures/Door"));
            Textures.Add('r', Content.Load<Texture2D>("Textures/Door01"));
            Textures.Add('a', Content.Load<Texture2D>("Textures/Door02"));
            Textures.Add('v', Content.Load<Texture2D>("Textures/Door03"));
            Textures.Add('d', Content.Load<Texture2D>("Textures/GreenComputerWall"));
            Textures.Add('f', Content.Load<Texture2D>("Textures/GreenWall"));
            Textures.Add('z', Content.Load<Texture2D>("Textures/PowerGenaretorWall"));
            Textures.Add('x', Content.Load<Texture2D>("Textures/Wall"));
            Textures.Add('c', Content.Load<Texture2D>("Textures/Wall01"));
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Wall w in Walls)
            {
                w.Draw(spriteBatch);
            }
 
            foreach (Platform p in platforms)
            {
                p.Draw(spriteBatch);
            }

        }

        private void Unload()
        {
            Walls.Clear();
        }

        public void Next()
        {
            LoadLevel(CurrentLevel + 1);
        }

        public void LoadLevel(int level)
        {
            if (!File.Exists(GetLevelFile(level)))
                level = 1;

            CurrentLevel = level;

            Unload();

            int y = 0;
            foreach (string line in File.ReadLines(GetLevelFile(level)))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Textures.ContainsKey(line[i]))
                        Walls.Add(new Wall(Textures[line[i]], i * Game1.SCREEN_WIDTH, 800));
                    
                }

                //y += 700;
            }
        }

        public string GetLevelFile(int level)
        {
            return "Content/Levels/Level" + level + ".txt";
        }

    }
}
