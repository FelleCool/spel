using Godot;

public partial class Player : CharacterBody2D
{
    private AnimatedSprite2D _animatedSprite;
    private Timer attackTimer;
    
    // Stats
    public int hp = 100;
    public float Speed = 300.0f;
    public int attackDamage = 10;


    public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSpriteD2");
        
        // Se till att filvägen är korrekt
        packedScene = ResourceLoader.Load<PackedScene>("res://scenes/sword.tscn");
        if (packedScene == null)
        {
            GD.PrintErr("Misslyckades att ladda SwordAttack.tscn! Kontrollera filvägen.");
        }
    }


    private void playerMovement(){
        if (_animatedSprite == null)
        {
            GD.Print("sprite = null");
        }
        Vector2 velocity = Velocity;
        Vector2 direction = Input.GetVector("left", "right", "up", "down");

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
            _animatedSprite.Play("move");

            if (direction.X > 0)
            {
                _animatedSprite.Scale = new Vector2(1, 1);
            }
            else if (direction.X < 0)
            {
                _animatedSprite.Scale = new Vector2(-1, 1);
            }
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            _animatedSprite.Play("idle");
        }

        Velocity = velocity;
        

    }
	
	// Attack
    private bool swordAttack = true;
    private PackedScene packedScene; // Klassvariabel för att hålla scenen
	private void attacks(){
		if (swordAttack == true)
        {
            Node instance = packedScene.Instantiate();
            AddChild(instance);
			swordAttack = false;
        }
	}
    public override void _PhysicsProcess(double delta)
    {
        Vector2 playerPosition = GlobalPosition;
        GetTree().CallGroup("fiender", "findAndMoveToPlayer", playerPosition);
        playerMovement();
        MoveAndSlide();
		attacks();
    }
}
