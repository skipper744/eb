﻿using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = Volibear.Config.Modes.LaneClear;

namespace Volibear.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minion =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(Q.Range));

            if (minion == null) return;

            if (Q.IsReady() && minion.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                Q.Cast();
            }

            if (E.IsReady() && minion.IsValidTarget(E.Range) && Settings.UseE)
            {
                E.Cast();
            }

            if (W.IsReady() && minion.IsValidTarget(W.Range) && Settings.UseW && minion.Health <= SpellDamage.GetRealDamage(SpellSlot.W, minion))
            {
                W.Cast(minion);
            }
        }
    }
}

