using SFML.System;
using System.Collections.Generic;
using static SFML.Window.Keyboard;

namespace SuspiciousMinds.Base.Interfaces
{
    public interface IInputComponent
    {
        Vector2f MouseCoords { get; set; }
        Dictionary<Key, bool> Keys { get; }

        void Update();
    }
}
