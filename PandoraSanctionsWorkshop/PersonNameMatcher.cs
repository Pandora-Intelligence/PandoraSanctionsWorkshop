namespace PandoraSanctionsWorkshop
{
    public class PersonNameMatcher(List<Sanction> sanctionsToMatch)
    {
        private readonly List<Sanction> _sanctionsToMatch = sanctionsToMatch;

        public List<MatchedSanction> GetMatches(string nameToMatch, int autoPromoteScore)
        {
            //Here you need to add whatever you deem necessary to match the given name to the provided list of Sanctions
            return new();
        }
    }
}
