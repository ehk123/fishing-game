namespace MyGame;

public class GameManager
{
    private readonly Map _map;
    public GameManager()
    {
        _map = new();
    }

    public void Update()
    {
        InputManager.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        _map.Draw();
        Globals.SpriteBatch.End();
    }
}