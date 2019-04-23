using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;
using NUnit.Framework;
using System;

// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            //IInstrument instrument = new Guitar();

            IPerformer performer = new Performer("Gosho", 24);
            //performer.AddInstrument(instrument);
            stage.AddPerformer(performer);

            ISong song = new Song("Rocks down", new TimeSpan(0, 0, 0, 55));
            stage.AddSong(song);

            ISet set = new Long("Set1");
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);

            string result = setController.PerformSets();

            Assert.AreEqual("1. Set1:\r\n-- Did not perform", result);
        }

        [Test]
        public void Test2()
        {
            IStage stage = new Stage();

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Stamat", 18);
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);

            set.AddSong(new Song("Song1", new TimeSpan(0, 0, 1, 2)));

            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo("1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful"));
        }

        [Test]
        public void Test3()
        {
            IStage stage = new Stage();

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Stamat", 18);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);

            set.AddSong(new Song("Song1", new TimeSpan(0, 0, 1, 2)));

            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            var beforeValue = instrument.Wear;
            setController.PerformSets();

            var afterValue = instrument.Wear;

            Assert.That(beforeValue, Is.Not.EqualTo(afterValue));
        }
    }
}