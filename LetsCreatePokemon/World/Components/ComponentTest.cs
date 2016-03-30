﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsCreatePokemon.EventArg;
using LetsCreatePokemon.Inputs;
using LetsCreatePokemon.Services.World;
using LetsCreatePokemon.World.Events;

namespace LetsCreatePokemon.World.Components
{
    internal class ComponentTest : Component
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;

        public ComponentTest(IComponentOwner owner, IEventRunner eventRunner, Input input) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            input.NewInput += InputOnNewInput;
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == Common.Inputs.A)
            {
                eventRunner.RunEvents(new List<IEvent>() { new EventTest()});
            }
        }

        public override void Update(double gameTime)
        {
            input.Update(gameTime);
        }
    }
}