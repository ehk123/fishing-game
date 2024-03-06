namespace MyGame;

public class Character : Sprite
{
    private const float SPEED = 500;
    private Vector2 _minPos, _maxPos;
    private Vector2 _position;
    private readonly AnimationManager _animations = new();

    public Character(Texture2D texture, Vector2 position) : base(texture, position)
    {
        _position = position;
        _animations.AddAnimation(new Vector2(1, 0), new(texture, 8, 2, 0.1f, 1));
        _animations.AddAnimation(new Vector2(-1, 0), new(texture, 8, 2, 0.1f, 2));
    }

    public void SetBounds(Point mapSize, Point tileSize)
    {
        _minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        _maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
    }

    public void Update()
    {
        if (InputManager.Moving)
        {
            Position += InputManager.Direction * Globals.Time * SPEED;
            Position = Vector2.Clamp(Position, _minPos, _maxPos);
        }
        _animations.Update(InputManager.Direction);
    }

    public void DrawAnimation()
    {
        _animations.Draw(_position);
    }
}