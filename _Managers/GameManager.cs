namespace MyGame;

public class GameManager
{
    public GameManager()
    {
    }

    public void Update()
    {
        InputManager.Update();
    }

    public void Draw()
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.End();
    }
}