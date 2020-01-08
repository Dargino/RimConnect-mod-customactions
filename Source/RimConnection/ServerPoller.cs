﻿using System;
using Verse;

namespace RimConnection
{
    class ServerPoller : GameComponent
    {
        private float timeCounterSeconds = 0.0f;
        private float waitTimeSeconds = 30.0f;

        private DateTime previousDateTime;

        public ServerPoller(Game game)
        {
        }

        public ServerPoller()
        {
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            previousDateTime = DateTime.Now;
        }

        public override void GameComponentTick()
        {
            // Only do this stuff if the mod successfully connected to the server
            if (RimConnectSettings.initialiseSuccessful)
            {
                base.GameComponentTick();
                var now = DateTime.Now;

                timeCounterSeconds += (float)(now - previousDateTime).TotalSeconds;
                if (timeCounterSeconds > waitTimeSeconds)
                {
                    timeCounterSeconds = 0.0f;
                    serverChecker();
                }

                previousDateTime = now;
            }
        }

        private void serverChecker()
        {
            var commands = RimConnectAPI.GetCommands();
            foreach (var command in commands)
            {
                var action = ActionList.actionLookup[command.actionHash];
                action.Execute(command.amount);
                Find.TickManager.slower.SignalForceNormalSpeedShort();
            }
            return;
        }

    }
}
