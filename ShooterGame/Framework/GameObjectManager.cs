using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Framework
{
    public class GameObjectManager
    {
        public List<GameObject> AllObjects { get; private set; } = new();
        public GraphicsDevice GraphicsDevice { get; init; }

        private readonly List<GameObject> objectsToAdd = new();
        private readonly List<GameObject> objectsToRemove = new();
        public GameObjectManager(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }

        public void AddObject(GameObject obj)
        {
            obj.Game = this;
            obj.Initialize();
            objectsToAdd.Add(obj);
        }
        public void RemoveObject(GameObject obj)
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
