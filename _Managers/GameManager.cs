namespace MyGame;

public class GameManager
{
    private readonly Map _map;
    private readonly Character _character;
    private Matrix _translation;
    public GameManager()
    {
        _map = new();
        _character = new(Globals.Content.Load<Texture2D>("character_right_1_upscaled"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2));
        _character.SetBounds(_map.MapSize, _map.TileSize);
    }

    private void CalculateTranslation()
    {
        var dx = (Globals.WindowSize.X / 2) - _character.Position.X;
        dx = MathHelper.Clamp(dx, -_map.MapSize.X + Globals.WindowSize.X + (_map.TileSize.X / 2), _map.TileSize.X / 2);
        var dy = (Globals.WindowSize.Y / 2) - _character.Position.Y;
        dy = MathHelper.Clamp(dy, -_map.MapSize.Y + Globals.WindowSize.Y + (_map.TileSize.Y / 2), _map.TileSize.Y / 2);
        _translation = Matrix.CreateTranslation(dx, dy, 0f);
    }

    public void Update()
    {
        InputManager.Update();
        _character.Update();
        CalculateTranslation();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin(transformMatrix: _translation);
        _map.Draw();
        _character.Draw();
        Globals.SpriteBatch.End();
    }
}