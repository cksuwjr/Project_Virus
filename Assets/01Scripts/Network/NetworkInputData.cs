using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    // player
    public Vector3 direction;

    // ball
    public const byte MOUSEBUTTON0 = 1;

    public NetworkButtons buttons;

    // physxBall
    public const byte MOUSEBUTTON1 = 2;

}