namespace MyGame;

public class Character : Sprite
{
    private const float SPEED = 500;
    private Vector2 _minPos, _maxPos;

    public Character(Texture2D texture, Vector2 position) : base(texture, position)
    {
    }

    public void SetBounds(Point mapSize, Point tileSize)
    {
        _minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        _maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
    }

    public void Update()
    {
        Position += InputManager.Direction * Globals.Time * SPEED;
        Position = Vector2.Clamp(Position, _minPos, _maxPos);
    }
}