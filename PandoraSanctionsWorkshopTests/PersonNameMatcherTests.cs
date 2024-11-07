using PandoraSanctionsWorkshop;

namespace PandoraSanctionsWorkshopTests
{
    [TestClass]
    public class PersonNameMatcherTests
    {
        private readonly int _autoPromoteScore = 80;

        [DataTestMethod]
        [DataRow("Michail Babkin", 1, 2, 1)]
        [DataRow("Babkin, Michail Anatoljewitsch", 1, 2, 1)]
        [DataRow("Michail Anatoljewitsch Putin", -1, 0, 0)]
        [DataRow("Michaile Anatoljewitsch Babkins", 1, 1, 1)]
        [DataRow("Michail Anatoljewitsc Bbkin", 1, 1, 0)]
        [DataRow("Michail Anatolje Babkin", 1, 1, 0)]
        [DataRow("Viktor Ali Baturin", 1, 1, 0)]
        [DataRow("Baturin, Viktor", 1, 1, 1)]
        [DataRow("Viktor Batman", 2, 1, 0)]
        [DataRow("Victor Batman", 2, 1, 0)]
        [DataRow("Vikto Baturin", 2, 1, 0)]
        [DataRow("Viktore Baturin", 2, 1, 1)]
        [DataRow("Marija Boerljaeva", 3, 1, 1)]
        [DataRow("Marija Nikolaevna Boteliva", 3, 1, 0)]
        [DataRow("Maria Nikolaevna Boerljaeva", 3, 1, 0)]
        [DataRow("Marija Nikolaevnae Boerljaeva", 3, 1, 1)]
        [DataRow("Marija Nikolaevna Teresa Boerljaeva", 3, 1, 1)]
        [DataRow("Muhammad Naji al Otari", 4, 1, 1)]
        [DataRow("Muhammad al-Otari", 4, 1, 1)]
        [DataRow("Muhammade Naji al-Otari", 4, 1, 1)]
        [DataRow("Muhammad Naji a-Otari", 4, 1, 0)]
        [DataRow("Toni Naji al-Otari", 4, 1, 0)]
        [DataRow("Mari Loren", -1, 0, 0)]
        [DataRow("Sofia Loren", 5, 1, 1)]
        [DataRow("Sofi Maria Loren", 5, 1, 0)]
        [DataRow("Sof Loren", 5, 1, 0)]
        [DataRow("Sofa Loren", 5, 1, 0)]
        [DataRow("Sofa\r\nLoren", 5, 1, 0)]
        [DataRow("Loren, Sofia", 5, 1, 1)]
        public void GetMatches_Returns_Correct_Results(string nameToMatch, int sanctionId, int numberOfMatches, int numberOfPromotedMatches)
        {
            //Arrange
            var sut = new PersonNameMatcher(GetSanctions());

            //Act
            var results = sut.GetMatches(nameToMatch, _autoPromoteScore);

            //Assert
            Assert.AreEqual(numberOfMatches, results.Count);
            Assert.AreEqual(sanctionId, results[0].Id);
            Assert.AreEqual(numberOfPromotedMatches, results.Count(x => x.Promoted == true));
        }

        private List<Sanction> GetSanctions()
        {
            return [
                new Sanction {
                    Id = 1,
                    Name = "Michail Anatoljewitsch Babkin",
                },
                new Sanction {
                    Id = 1,
                    Name = "Michail Babkin",
                },
                new Sanction {
                    Id = 2,
                    Name = "Viktor Baturin",
                },
                new Sanction {
                    Id = 3,
                    Name = "Marija Nikolaevna Boerljaeva",
                },
                new Sanction {
                    Id = 3,
                    Name = "Marija Boerljaeva",
                },
                new Sanction {
                    Id = 4,
                    Name = "Muhammad Naji al-Otari",
                },
                new Sanction {
                    Id = 5,
                    Name = "Sofi Loren",
                },
            ];
        }
    }
}
