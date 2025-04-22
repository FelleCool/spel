using Godot;
using System;

public partial class Explotion : Area2D
{
	[Export]
    public float Duration = 0.5f; // Explosionens varaktighet i sekunder

    public override void _Ready()
    {
        // Starta en timer eller vänta en viss tid innan explosionen tas bort
        GetTree().CreateTimer(Duration).Connect("timeout", new Callable(this, "OnTimerTimeout"));
    }

    private void OnTimerTimeout()
    {
        QueueFree();
    }
}
