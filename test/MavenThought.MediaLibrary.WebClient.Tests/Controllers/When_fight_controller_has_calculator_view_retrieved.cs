using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MavenThought.Commons;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.WebClient.ViewModels;
using MvcContrib.TestHelper;
using Rhino.Mocks;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// When fight controller has calculator view retrieved 
    /// </summary>
    [Specification]
    public class When_fight_controller_has_calculator_view_retrieved 
        : FightControllerSpecification
    {
        /// <summary>
        /// Should have the calculator view
        /// </summary>
        [It]
        public void Should_have_the_calculator_view()
        {
            this.ActualResult.AssertViewRendered();
        }

        /// <summary>
        /// Should have the view model
        /// </summary>
        [It]
        public void Should_have_the_view_model()
        {
            ((ViewResult)this.ActualResult).ViewData.Model.Should().Be(Dep<ICalculatorViewModel>());
        }
        
        /// <summary>
        /// Calculator view
        /// </summary>
        protected override void WhenIRun()
        {
            this.ActualResult = Sut.Calculator();
        }
    }
}