using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play
{
    public class GameManager
    {
        public List<Object> AllObjects { get; private set; } = new();
        public float GameSpeed { get; set; } = 100f;

        private readonly List<Object> objectsToAdd = new();
        private readonly List<Object> objectsToRemove = new();
        public void AddObject(Object obj)
        {
            obj.GameManager = this;
            objectsToAdd.Add(obj);
        }
        public void RemoveObject(Object obj)
        {
            objectsToRemove.Add(obj);
        }
        public void Update(GameTime gameTime)
        {
            foreach (var obj in AllObjects)
                obj.Update(gameTime);
            AllObjects.AddRange(objectsToAdd);
            objectsToAdd.Clear();
            foreach (var obj in objectsToRemove)
            {
                AllObjects.Remove(obj);
            }
            objectsToRemove.Clear();
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var obj in AllObjects)
                obj.Draw(gameTime, spriteBatch);
        }
    }
}
