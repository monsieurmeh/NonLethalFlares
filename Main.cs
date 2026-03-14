using Il2Cpp;
using MelonLoader;
using HarmonyLib;
using System.Reflection;

[assembly: AssemblyTitle("NonLethalFlares")]
[assembly: AssemblyCopyright("MonsiuerMeh")]
[assembly: AssemblyVersion("1.0.0")]
[assembly: AssemblyFileVersion("1.0.0")]
[assembly: MelonInfo(typeof(NonLethalFlares.Main), "Non-Lethal Flares", "1.0.0", "MonsieurMeh", null)]
[assembly: MelonGame("Hinterland", "TheLongDark")]

namespace NonLethalFlares;

internal class Main : MelonMod 
{
    internal static bool FlaregunDamageBlock = false;

    [HarmonyPatch(typeof(FlareGunRoundItem), nameof(FlareGunRoundItem.InflictDamage), new Type[] { typeof(UnityEngine.GameObject), typeof(float), typeof(bool), typeof(string) })]
    internal static class FlareGunRoundItem_InflictDamageBlock
    {
        internal static void Prefix(UnityEngine.GameObject victim, float damageScalar, ref bool stickIn, string collider)
        {
            FlaregunDamageBlock = true;
            stickIn = false;
        }


        internal static void Postfix() => FlaregunDamageBlock = false;
    }


    [HarmonyPatch(typeof(BaseAi), nameof(BaseAi.ApplyDamage), new Type[] { typeof(float), typeof(float), typeof(DamageSource), typeof(string) })]
    internal static class BaseAi_LogDamage
    {
        internal static bool Prefix(float damage, float bleedOutMintues, DamageSource damageSource, string collider) => !FlaregunDamageBlock;
    }
}