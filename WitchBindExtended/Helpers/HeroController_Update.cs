using GlobalSettings;
using HarmonyLib;
using UnityEngine;
using WitchBindExtended.Settings;

namespace WitchBindExtended.Helpers
{
    [HarmonyPatch(typeof(HeroController), "Update")]
    public static class HeroController_Update
    {
        [HarmonyPostfix]
        public static void Postfix(HeroController __instance)
        {
            float modifier = ConfigSettings.multiplier.Value;
            if (Gameplay.LongNeedleTool.IsEquipped)
            {
                modifier = ConfigSettings.longclawMultiplier.Value;
            }

            if (SharedData.modifierApplied == modifier)
            {
                return;
            }

            GameObject bindEffects = UnityEngine.GameObject.Find("Bind Effects");
            if (bindEffects == null)
            {
                //WitchBindExtended.Instance.Log("Error getting bind effects");
                return;
            }

            GameObject witchBind = UnityEngine.GameObject.Find("Witch Bind");
            if (witchBind == null)
            {
                //WitchBindExtended.Instance.Log("Error getting witch bind");
                return;
            }

            Transform[] witchObjects = witchBind.GetComponentsInChildren<Transform>();
            foreach (Transform t in witchObjects)
            {
                GameObject gameObject = t.gameObject;
                if (gameObject.name.Contains("Damager") ||
                    gameObject.name.Contains("Tendril"))
                {
                    //WitchBindExtended.Instance.Log($"Tendril/Damager found: {gameObject.name}");
                    GameObject parent = gameObject.transform.parent.gameObject;
                    if (parent != null &&
                        parent.name.Equals("Witch Bind"))
                    {
                        // First, reset the tentacles to normal size
                        Vector3 oldScale = gameObject.transform.localScale;
                        gameObject.transform.localScale /= SharedData.modifierApplied;

                        // Then, apply the new multiplier
                        gameObject.transform.localScale *= modifier;
                        //WitchBindExtended.Instance.Log($"{gameObject.name} : {oldScale} -> {gameObject.transform.localScale}");
                    }
                }
            }

            SharedData.modifierApplied = modifier;
        }
    }
}