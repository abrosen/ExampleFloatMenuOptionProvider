using RimWorld;
using Verse;
namespace ExampleFloatMenuOptionProvider
{
    public class FloatMenuOptionProvider_Example : FloatMenuOptionProvider
    {
        protected override bool Drafted => true;
        protected override bool Undrafted => true;
        protected override bool Multiselect => false;


        protected override FloatMenuOption GetSingleOptionFor(Pawn clickedPawn, FloatMenuContext context)
        {
            return new FloatMenuOption("Hello we are trying to reach you about your car warranty", () =>
            {
                clickedPawn.Kill(null);
                Messages.Message($"{context.FirstSelectedPawn} has killed {clickedPawn} by emptying their bank account.", MessageTypeDefOf.PositiveEvent, historical:false);
            });
        }
    }
}