using RimWorld;
using Verse;

namespace ExampleFloatMenuOptionProvider
{
    // This is identified by the game as a FloatMenuOptionProvider because it inherits from that class and thus is automatically checked as appropriate.
    public class FloatMenuOptionProvider_Example : FloatMenuOptionProvider
    {
        protected override bool Drafted => true;

        protected override bool Undrafted => true;

        protected override bool Multiselect => false;

        // This is where we define the FloatMenuOption that we want to display to players (and in this case, what choosing the option does).
        // Note that returning null here is safe, and will simply display no option. It can be a useful fallback in case TargetThingValid/TargetPawnValid are returning true incorrectly.
        protected override FloatMenuOption GetSingleOptionFor(Pawn clickedPawn, FloatMenuContext context)
        {
            if (clickedPawn.Faction != Faction.OfPlayer)
            {
                // The delegate here controls what happens when a player chooses this float menu option. The code is only executed if the option is chosen.
                return new FloatMenuOption("Example_KillPawn".Translate(clickedPawn), delegate
                {
                    // You can provide DamageInfo and/or a Hediff logging how/why the pawn died, but we don't need to do so here. The message will explain how and why they died if players are somehow confused by the pawn dying.
                    clickedPawn.Kill(null);
                    Messages.Message("Example_KilledWithTheirMind".Translate(context.FirstSelectedPawn, clickedPawn), MessageTypeDefOf.PositiveEvent, historical: false);
                });
            }

            /**
             * For the purposes of this example, we only allow non-player pawns to be killed.
             * Note the "null" after the translated string. Setting a null action is how the game identifies that the option should display, but be disabled.
             * This can be helpful if you want to explain why the option isn't valid while not hiding the option entirely.
             **/
            return new FloatMenuOption("Example_CannotKillPlayerPawns".Translate(clickedPawn), null);
        }
    }
}