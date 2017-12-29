using SFML.System;
using System.Collections.Generic;
using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;

namespace SuspiciousMinds.Base.Interfaces
{
    public interface IInputComponent
    {
        Vector2f MouseCoords { get; set; }
        Dictionary<Key, bool> Keys { get; }
        Dictionary<Button, bool> MouseButtons { get; }

        void Update();
    }
}
