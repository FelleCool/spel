using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
    private const float Speed = 100.0f; // Fiendens rörelsehastighet

    public override void _Ready()
    {
        GD.Print("Fiende spawned in!");
    }

    public override void _Process(double delta)
    {
        // Hämta spelarens position från GlobalData
        GlobalData globalData = (GlobalData)GetNode("/root/GlobalData");
        Vector2 playerPosition = globalData.PlayerPosition;

        // Beräkna riktning mot spelaren
        Vector2 direction = (playerPosition - GlobalPosition).Normalized();

        // Uppdatera fiendens hastighet baserat på riktningen och hastigheten
        Vector2 velocity = direction * Speed;

        // Flytta fienden
        Velocity = velocity;
        MoveAndSlide(Velocity); // Skicka den uppdaterade Velocity till MoveAndSlide
    }
}
