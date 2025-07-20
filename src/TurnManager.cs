using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class TurnManager : Node
{
    public Array<Node2D> characterQueue;
    public Dictionary<String, Color> actionQueue;
    public Node2D activeCharacter;
    [Export] public Button button1;
    [Export] public Button button2;
    [Export] public Button button3;
    private bool actionsChosen = false;

    public override void _Ready()
    {
        ResetTurns();
        //actionQueue = 

        activeCharacter = characterQueue.FirstOrDefault();

        button1.Pressed += () => actionQueue.Add("Red", Colors.Red);
        button2.Pressed += () => actionQueue.Add("Blue", Colors.Blue);
        button3.Pressed += () => ProgressTurn();
    }

    public override void _Process(double delta)
    {
        if (actionsChosen)
        {
            ResetTurns();
            for (int i = 0; i < actionQueue.Count; i++)
            {
                activeCharacter.Modulate = actionQueue.Values.First();
                GD.Print("action set to " + actionQueue.Values.First());
                actionQueue.Remove(actionQueue.Keys.First());
            }
            actionsChosen = false;
        }
    }

    public void ProgressTurn(){
        activeCharacter = characterQueue.FirstOrDefault();
        characterQueue.RemoveAt(0);
        //characterQueue.Add(activeCharacter);
        GD.Print(activeCharacter.Name);
        if (characterQueue.Count <= 0) { actionsChosen = true; }
        //some characters will be unwilling to fight certain enemies
    }

    private void ResetTurns() {
        characterQueue = GetChildren().Where();
}
