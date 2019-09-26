﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace MoreAlerts
{
    class Alert_WastingPsychicHelmet : Alert_Custom_FreeColonistsSpawned
    {
        public Alert_WastingPsychicHelmet()
        {
            this.defaultLabel = "wasting psychic helmets";
            this.defaultExplanation = "Some colonists are pointlessly wearing psychic helmets.";
        }

        private static bool isBadPsychicEvent(Map map)
        {
            if (map.gameConditionManager.ConditionIsActive(GameConditionDefOf.PsychicDrone))
            {
                return true;
            }
            List<Thing> emanators = map.listerThings.ThingsInGroup(ThingRequestGroup.PsychicDroneEmanator);
            if (emanators.Any())
            {
                return true;
            }
            return false;
        }

        protected override bool isPawnAffected(Pawn p)
        {
            if (isBadPsychicEvent(p.Map))
            {
                return false;
            }

            foreach (Thing t in p.equipment.AllEquipmentListForReading)
            {
                if (t.def.defName == "Apparel_PsychicFoilHelmet")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
