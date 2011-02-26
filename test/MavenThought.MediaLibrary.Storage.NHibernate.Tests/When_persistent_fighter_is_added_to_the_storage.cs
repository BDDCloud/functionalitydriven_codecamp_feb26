using System.Collections.Generic;
using System.Linq;
using MavenThought.MediaLibrary.Core;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when adding the ninja to the storage
    /// </summary>
    [Specification]
    public class When_persistent_fighter_is_added_to_the_storage : PersistentFighterSpecification
    {
        /// <summary>
        /// Object to store
        /// </summary>
        private Fighter _ninja;
        
        /// <summary>
        /// Actual collection obtained
        /// </summary>
        private IList<Fighter> _actual;

        /// <summary>
        /// Checks the ninja is stored
        /// </summary>
        [It]
        public void Should_retrieve_same_ninja()
        {
            this._actual.First().Strength.Should().Be.EqualTo(this._ninja.Strength);
            this._actual.First().Description.Should().Be.EqualTo(this._ninja.Description);
            this._actual.First().Class.Should().Be.EqualTo(this._ninja.Class);
        }

        /// <summary>
        /// Checks the size of the collection
        /// </summary>
        [It]
        public void Should_have_only_one_element()
        {
            this._actual.Should().Have.Count.EqualTo(1);
        }

        /// <summary>
        /// Setup the ninja we want to store
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._ninja = new Fighter { Description = "Third dan black belt", Strength = 72, Class = "Ninja" };
        }

        /// <summary>
        /// Store the ninja
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this.Sut.AutoCommit(session => session.Save(this._ninja));
        }

        /// <summary>
        /// Retrieve the ninja from the storage
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Sut.List<Fighter>();
        }
    }
}