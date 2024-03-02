namespace MyGame;

public class GameManager
{
    private readonly Map _map;
    private readonly Character _character;
    public GameManager()
    {
        _map = new();
        _character = new(Globals.Content.Load<Texture2D>("peter"), new(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2));
        _character.SetBounds(_map.MapSize, _map.TileSize);
    }

    public void Update()
    {
        InputManager.Update();
        _character.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _map.Draw();
        _character.Draw();
        Globals.SpriteBatch.End();
    }
}