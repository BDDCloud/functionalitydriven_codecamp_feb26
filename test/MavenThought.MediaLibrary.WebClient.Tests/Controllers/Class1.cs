using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MavenThought.Commons;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// When fight controller has calculator view retrieved 
    /// </summary>
    public class When_fight_controller_has_calculator_view_retrieved 
        : FightControllerSpecification
    {
        /// <summary>
        /// Expected ninjas
        /// </summary>
        private IEnumerable<SelectListItem> _expectedNinjas;

        /// <summary>
        /// Should have the expected ninjas
        /// </summary>
        [It]
        public void Should_have_the_expected_ninjas()
        {
            ((IEnumerable<SelectListItem>) Sut.ViewData["myNinja"]).Should().Have.SameValuesAs(_expectedNinjas);
        }

        /// <summary>
        /// Given that there are ninjas and opponents
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var randomGenerator = new RandomGenerator();
            var fighters = 10.Times(i => Mock<IFighter>());
            fighters.ForEach(f => f.Stub(g => g.Description).Return(randomGenerator.Generate<string>()));
            Dep<INinjaCommander>().Stub(c => c.Ninjas).Return(fighters);

            _expectedNinjas = fighters.Select(f => new SelectListItem { Text = f.Description });
        }
    }
}