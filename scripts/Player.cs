using Godot;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite;
	private RayCast2D _raycast;
	private Timer attackTimer;
	[Export] public float attackInterval = 5f;

    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSpriteD2");
		_raycast = GetNode<RayCast2D>("RayCast2D");

		attackTimer = new Timer();
    	attackTimer.WaitTime = attackInterval;
    	attackTimer.OneShot = false;
    	attackTimer.Connect("timeout", new Callable(this, nameof(playerAttack)));
    	AddChild(attackTimer);
    	attackTimer.Start();
    }

	public const float Speed = 300.0f;

	private void playerMovement()
	{
		if (_animatedSprite == null) // Kontrollera att _animatedSprite inte är null
		{
			GD.Print("sprite = null");
		}
		Vector2 velocity = Velocity;

		// Hämta inputriktning och hantera rörelse/avstanning
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
			_animatedSprite.Play("move");
			if (direction.X > 0) // Kollar om spelaren rör sig åt höger
			{
    			_animatedSprite.Scale = new Vector2(1, 1); // Återställ normal skala
			}
			else if (direction.X < 0) // Kollar om spelaren rör sig åt vänster
			{
   				 _animatedSprite.Scale = new Vector2(-1, 1); // Spegla horisontellt
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			_animatedSprite.Play("idle");
		}

		// Uppdatera hastighet och spelares position
		Velocity = velocity;

		// Uppdatera spelarens position i GlobalData
		GlobalData globalData = (GlobalData)GetNode("/root/GlobalData"); 
		globalData.PlayerPosition = GlobalPosition;

	}
	
	private void playerAttack()
	{
		// Spela attackanimationen
        _animatedSprite.Play("attack-side-down");

        _raycast.Enabled = true; // Aktivera raycast tillfälligt

        if (_raycast.IsColliding()) // Om RayCast2D träffar något
        {
            Node target = _raycast.GetCollider() as Node;
			if (target != null)
			{
    			GD.Print("Hit: ", target.Name);
			}
            
        // logik för att minska hälsan hos fienden
        }
		_animatedSprite.Play("idle");
	}
	public override void _PhysicsProcess(double delta)
	{
		playerMovement();
		MoveAndSlide();
	}
}
