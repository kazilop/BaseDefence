
public class GameStateGame : GameState
{
    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Game);
        GameManager.Instance.motor.ResumePlayer();
        GameManager.Instance.isGameBegin = true;
    }

    public override void UpdateState()
    {
        
    }
}
