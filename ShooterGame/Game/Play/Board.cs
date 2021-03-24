using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Game.Play.Gems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame.Game.Play
{
    public class Board
    {
        public bool IsSwitching { get; private set; }
        public Gem LastSelected { get; set; }

        private int size = 8;
        private Gem[,] board;
        private Random rng = new();
        private List<GemType> gems = new() { GemType.RedGem, GemType.OrangeGem, GemType.YellowGem, GemType.GreenGem, GemType.BlueGem, GemType.PurpleGem, GemType.WhiteGem };

        private readonly GameManager gameManager;
        private readonly GraphicsDevice graphicsDevice;
        public Board(GameManager gameManager, GraphicsDevice graphicsDevice)
        {
            this.gameManager = gameManager;
            this.graphicsDevice = graphicsDevice;
            CreateBoard();
        }

        public void SelectGem(Gem gem)
        {
            gem.IsSelected = true;
            LastSelected = gem;
        }
        public void DeselectGem(Gem gem)
        {
            gem.IsSelected = false;
            LastSelected = null;
        }
        public void SwapGems(Gem originalGem, Gem swapWith)
        {
            //var originalGemInBoard = board[originalGem.XPositionInBoard, originalGem.YPositionInBoard];
            //var swapGemInBoard = board[swapWith.XPositionInBoard, swapWith.YPositionInBoard];

            var buffer = originalGem;
            swapWith.Position = originalGem.Position;
            swapWith = originalGem;

            originalGem.Position = buffer.Position;
            originalGem = buffer;
        }

        private void CreateBoard()
        {
            board = new Gem[size, size];

            float startX = 5;
            float startY = 5;
            const int spaceBetweenTiles = 60;

            var previousLeft = new GemType[size];
            var previousBelow = GemType.None;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    List<GemType> possibleGems = new();
                    possibleGems.AddRange(gems);

                    possibleGems.Remove(previousLeft[y]);
                    possibleGems.Remove(previousBelow);

                    Gem newGem = CreateGemFromType((GemType)rng.Next(1, possibleGems.Count + 1), graphicsDevice);
                    newGem.Board = this;
                    newGem.XPositionInBoard = x;
                    newGem.YPositionInBoard = y;
                    newGem.Position = new Vector2(startX + (spaceBetweenTiles * x), startY + (spaceBetweenTiles * y));
                    board[x, y] = newGem;
                    gameManager.AddObject(newGem);

                    previousLeft[y] = newGem.Type;
                    previousBelow = newGem.Type;
                }
                
            }
        }
        private Gem CreateGemFromType(GemType type, GraphicsDevice graphicsDevice) => type switch
        {
            GemType.RedGem => new RedGem(graphicsDevice),
            GemType.OrangeGem => new OrangeGem(graphicsDevice),
            GemType.YellowGem => new YellowGem(graphicsDevice),
            GemType.GreenGem => new GreenGem(graphicsDevice),
            GemType.BlueGem => new BlueGem(graphicsDevice),
            GemType.PurpleGem => new PurpleGem(graphicsDevice),
            GemType.WhiteGem => new WhiteGem(graphicsDevice),
            _ => throw new Exception("idoit")
        };

    }
    public enum GemType
    {
        None,
        RedGem,
        OrangeGem,
        YellowGem,
        GreenGem,
        BlueGem,
        PurpleGem,
        WhiteGem
    }
}
