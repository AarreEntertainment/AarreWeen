using InControl;
public class MyCharacterActions : PlayerActionSet
{
    public PlayerAction Jump;
    public PlayerAction Run;
    public PlayerAction mUp;
    public PlayerAction mDown;
    public PlayerAction mLeft;
    public PlayerAction mRight;

    public PlayerAction lUp;
    public PlayerAction lDown;
    public PlayerAction lLeft;
    public PlayerAction lRight;

    public PlayerTwoAxisAction Move;
    public PlayerTwoAxisAction Look;

    public MyCharacterActions()
    {
        Jump = CreatePlayerAction("Jump");
        Run = CreatePlayerAction("Run");
        mLeft= CreatePlayerAction("Move left");
        mRight = CreatePlayerAction("Move right");
        mUp = CreatePlayerAction("Move up");
        mDown = CreatePlayerAction("Move down");
        lLeft = CreatePlayerAction("Look left");
        lRight = CreatePlayerAction("Look right");
        lUp = CreatePlayerAction("Look up");
        lDown = CreatePlayerAction("Look down");
        Move = CreateTwoAxisPlayerAction(mLeft, mRight, mDown, mUp);
        Look = CreateTwoAxisPlayerAction(lLeft, lRight, lDown, lUp);
    }

}