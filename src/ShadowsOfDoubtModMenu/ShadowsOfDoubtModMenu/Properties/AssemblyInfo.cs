using MelonLoader;
using System.Reflection;

[assembly: AssemblyTitle(ShadowsOfDoubtModMenu.BuildInfo.Description)]
[assembly: AssemblyDescription(ShadowsOfDoubtModMenu.BuildInfo.Description)]
[assembly: AssemblyCompany(ShadowsOfDoubtModMenu.BuildInfo.Company)]
[assembly: AssemblyProduct(ShadowsOfDoubtModMenu.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ShadowsOfDoubtModMenu.BuildInfo.Author)]
[assembly: AssemblyTrademark(ShadowsOfDoubtModMenu.BuildInfo.Company)]
[assembly: AssemblyVersion(ShadowsOfDoubtModMenu.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ShadowsOfDoubtModMenu.BuildInfo.Version)]
[assembly: MelonInfo(typeof(ShadowsOfDoubtModMenu.ShadowsOfDoubtModMenu), ShadowsOfDoubtModMenu.BuildInfo.Name, ShadowsOfDoubtModMenu.BuildInfo.Version, ShadowsOfDoubtModMenu.BuildInfo.Author, ShadowsOfDoubtModMenu.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]