using System.Collections.Generic;
using AM.UI;
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using UnityEngine;
using Verse;

namespace AM.Patches;

[HarmonyPatch(typeof(FloatMenuMakerMap), nameof(FloatMenuMakerMap.GetOptions))]
[UsedImplicitly]
public class Patch_FloatMenuMakerMap_GetOptions
{
    [UsedImplicitly]
    private static void Postfix(Vector3 clickPos, List<Pawn> selectedPawns, List<FloatMenuOption> __result)
    {
        if (__result == null)
            __result = new List<FloatMenuOption>();
        if (selectedPawns == null || selectedPawns.Count != 1)
            return false;
        Pawn pawn = selectedPawns[0];

        if (pawn == null || !pawn.Spawned || pawn.Map == null)
            return false;
        __result.AddRange(DraftedFloatMenuOptionsUI.GenerateMenuOptions(clickPos, pawn));
        return true;
    }
}
