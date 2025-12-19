using HarmonyLib;
using WitchBindExtended.Settings;
namespace WitchBindExtended.Helpers
{
    [HarmonyPatch(typeof(HeroController), "Start")]
    public static class HeroController_Start
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            SharedData.modifierApplied = 1f;
        }
    }
}