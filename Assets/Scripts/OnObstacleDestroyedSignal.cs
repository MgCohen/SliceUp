
public class OnObstacleDestroyedSignal
{
    public OnObstacleDestroyedSignal(Obstacle obstacle)
    {
        Obstacle = obstacle;
    }

    public Obstacle Obstacle
    {
        get; private set;
    }
}