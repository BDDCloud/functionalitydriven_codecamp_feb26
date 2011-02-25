using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MavenThought.Commons;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using Rhino.Mocks;

namespace MavenThought.MediaLibrary.WebClient.Tests.ViewModels
{
    /// <summary>
    /// When calculator view model is created
    /// </summary>
    [ConstructorSpecification]
    public class When_calculator_view_model_is_created : CalculatorViewModelSpecification
    {
        /// <summary>
        /// Expected ninjas
        /// </summary>
        private IEnumerable<SelectListItem> _expectedNinjas;

        /// <summary>
        /// Random generator
        /// </summary>
        private RandomGenerator _randomGenerator;

        /// <summary>
        /// Expected opponents
        /// </summary>
        private IEnumerable<SelectListItem> _expectedOpponents;

        /// <summary>
        /// Should have the expected ninjas
        /// </summary>
        [It]
        public void Should_have_the_expected_ninjas()
        {
            Assert.AreElementsEqual(_expectedNinjas, Sut.Ninjas,
                (a, b) => a.Text == b.Text && a.Text == b.Text);
        }

        /// <summary>
        /// Should have the expected opponents
        /// </summary>
        [It]
        public void Should_have_the_expected_opponents()
        {
            Assert.AreElementsEqual(_expectedOpponents, Sut.Opponents,
                (a, b) => a.Text == b.Text && a.Text == b.Text);
        }

        /// <summary>
        /// Given that there are ninjas and opponents
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            _randomGenerator = new RandomGenerator();

            var ninjas = StubFighters();
            Dep<INinjaCommander>().Stub(c => c.Ninjas).Return(ninjas);

            var opponents = StubFighters();
            Dep<INinjaCommander>().Stub(c => c.Opponents).Return(opponents);

            _expectedNinjas = ninjas.Select(f => new SelectListItem { Text = f.Description });
            _expectedOpponents = opponents.Select(f => new SelectListItem { Text = f.Description });
        }

        /// <summary>
        /// Get fighters
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IFighter> StubFighters()
        {
            var fighters = 10.Times(i => Mock<IFighter>());
            fighters.ForEach(f => f.Stub(g => g.Description).Return(_randomGenerator.Generate<string>()));
            return fighters;
        }
    }
}