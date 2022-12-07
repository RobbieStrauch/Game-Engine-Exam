using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInvertCommand : ICommand
{
    bool isInverted;

    public PlaceInvertCommand(bool isInvert)
    {
        this.isInverted = isInvert;
    }

    public void Execute()
    {
        InvertCommand.InvertControls(isInverted);
    }

    public void Redo()
    {

    }

    public void Undo()
    {

    }
}
