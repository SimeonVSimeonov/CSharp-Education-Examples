namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";

        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory)
        {
            this.instrumentFactory = instrumentFactory;
            this.setFactory = setFactory;
            this.stage = stage;
        }
        //ok/100/100
        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {this.RealTimeFormat(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({this.RealTimeFormat(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

        //ok/100/100
        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);
            string resul = $"Registered {type} set";
            return resul;
        }

        //ok
        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            var instrumenti2 = instrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = new Performer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        //ok
        public string RegisterSong(string[] args)
        {
            var songName = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, null);

            ISong song = new Song(songName, duration);

            this.stage.AddSong(song);

            string result = $"Registered song {songName} ({duration:mm\\:ss})";
            return result;
        }

        //ok
        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        //ok
        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        //ok
        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            if (song == null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            set.AddSong(song);

            string result = $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
            return result;


        }

        private object RealTimeFormat(TimeSpan timeSpan)
        {
            int minutes = timeSpan.Minutes + timeSpan.Hours * 60;
            int seconds = timeSpan.Seconds;

            string result = $"{minutes:d2}:{seconds:d2}";
            return result;
        }

    }
}