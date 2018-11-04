using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Roli_The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventIdToNames = new Dictionary<int,string>();
            var eventParticipants = new Dictionary<int, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line=="Time for Code")
                {
                    break;
                }

                var commandParts = line.Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var eventId = 0;
                if (!int.TryParse(commandParts[0],out eventId))
                {
                    continue;
                }

                var eventName = commandParts[1];
                if (!eventName.StartsWith("#"))
                {
                    continue;
                }

                eventName = eventName.Trim('#');

                var invalidParticipants = false;
                var participants = new List<string>();

                for (int i = 2; i < commandParts.Length; i++)
                {
                    var participant = commandParts[i];
                    if (!participant.StartsWith("@"))
                    {
                        invalidParticipants = true;
                        break;
                    }

                    participants.Add(participant);
                }

                if (invalidParticipants)
                {
                    continue;
                }

                if (eventIdToNames.ContainsKey(eventId))
                {
                    var existingsEventName = eventIdToNames[eventId];

                    if (existingsEventName==eventName)
                    {
                        eventParticipants[eventId].AddRange(participants);
                    }
                }
                else
                {
                    eventIdToNames[eventId] = eventName;
                    eventParticipants[eventId] = new List<string>(participants);
                }
            }

            var events = eventParticipants
                .Select(kpv => new
                {
                    Id = kpv.Key,
                    Name = eventIdToNames[kpv.Key],
                    Participants = kpv.Value.Distinct().ToList()
                })
                .OrderByDescending(kvp => kvp.Participants.Count)
                .ThenBy(ev=>ev.Name)
                .ToList();

            foreach (var ev in events)
            {
                var evId = ev.Id;
                var evName = ev.Name;
                var participants = ev.Participants;

                var sortedParticipants = participants
                    .OrderBy(p => p)
                    .ToList();

                Console.WriteLine($"{evName} - {sortedParticipants.Count}");

                foreach (var participant in sortedParticipants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
