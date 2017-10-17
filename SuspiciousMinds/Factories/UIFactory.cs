using SuspiciousMinds.Base;
using SuspiciousMinds.Base.Interfaces;
using SuspiciousMinds.Base.Player;
using SuspiciousMinds.Base.UI;
using System;
using System.Collections.Generic;

namespace SuspiciousMinds.Factories
{
    public static class UIFactory
    {
        public static Entity CreateCrosshair()
        {
            var input = new CrosshairInput();
            var display = new CrosshairDisplay(input);

            return new Entity
            {
                Components = new Dictionary<Type, object>
                {
                    {typeof(IDisplayComponent), display },
                    {typeof(IInputComponent), input }
                }
            };
        }
    }
}
