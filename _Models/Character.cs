namespace MyGame;

public class Character : Sprite
{
    private const float SPEED = 500f;
    private Vector2 _minPos, _maxPos;
    private readonly AnimationManager _animations = new();

    public Character(Texture2D texture, Texture2D refTexture, Vector2 position) : base(refTexture, position)
    {
        _animations.AddAnimation(new Vector2(1, 0), new(texture, 8, 2, 0.1f, 1));
        _animations.AddAnimation(new Vector2(-1, 0), new(texture, 8, 2, 0.1f, 2));
    }

    public void SetBounds(Point mapSize, Point tileSize)
    {
        _minPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        _maxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X - 64, mapSize.Y - (tileSize.Y / 2) - Origin.Y - 64);
    }

    public void Update()
    {
        Position += InputManager.Direction * Globals.Time * SPEED;
        Position = Vector2.Clamp(Position, _minPos, _maxPos);
        _animations.Update(InputManager.Direction);
    }

    public void DrawAnimation()
    {
        _animations.Draw(Position);
    }
}