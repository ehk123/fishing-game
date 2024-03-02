using System.Collections.Generic;

namespace MyGame;

public class Map
{
    private readonly Point _mapTileSize = new(30, 25);
    private readonly Sprite[,] _tiles;
    public Point TileSize { get; private set; }
    public Point MapSize { get; private set; }

    public Map()
    {
        _tiles = new Sprite[_mapTileSize.X, _mapTileSize.Y];

        Texture2D texture = Globals.Content.Load<Texture2D>("grass");

        TileSize = new(texture.Width, texture.Height);
        MapSize = new(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);

        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++)
            {
                _tiles[x, y] = new(texture, new(x * TileSize.X, y * TileSize.Y));
            }
        }
    }

    public void Draw()
    {
        for (int y = 0; y < _mapTileSize.Y; y++)
        {
            for (int x = 0; x < _mapTileSize.X; x++)
            {
                _tiles[x, y].Draw();
            }
        }
    }
}