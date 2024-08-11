using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Teamwork_Projects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            InitializeTeams(teams);
            JoinTeams(teams);
            PrintValidTeams(teams);
            PrintInvalidTeams(teams);
        }

        static void InitializeTeams(List<Team> teams)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= teamsCount; i++)
            {
                string[] teamArgs = Console.ReadLine().Split('-');
                string creator = teamArgs[0];
                string teamName = teamArgs[1];
                if (TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (AlreadyCreatedATeam(teams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamName, creator);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
        }
        static void JoinTeams(List<Team> teams)
        {
            string[] command = Console.ReadLine().Split("->");
            while (command[0] != "end of assignment")
            {
                string user = command[0];
                string teamName = command[1];
                if (!TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (AlreadyAMemeberOfATeam(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    Team teamToJoin = teams.First(h => h.Name == teamName);
                    teamToJoin.AddMember(user);
                }
                command = Console.ReadLine().Split("->");
            }
        }
        static bool AlreadyAMemeberOfATeam(List<Team> teams, string user)
        {
            return teams.Any(t => t.Members.Contains(user)) || 
                teams.Any(t => t.Creator==user);
        }
        static bool TeamExists(List<Team> teams, string teamName)
        {
            return teams.Any(x => x.Name == teamName);
        }
        static bool AlreadyCreatedATeam(List<Team> teams, string creator)
        {
            return teams.Any(y => y.Creator == creator);
        }
        static void PrintValidTeams(List<Team> teams)
        {
            List<Team> teamsWithMembers = teams
                            .Where(t => t.Members.Count > 0)
                            .OrderByDescending(t => t.Members.Count)
                            .ThenBy(t => t.Name)
                            .ToList();
            foreach (Team team in teamsWithMembers)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (string member in team.Members.OrderBy(m=>m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
        }
        static void PrintInvalidTeams(List<Team> teams)
        {
            List<Team> teamsToDisband = teams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name).ToList();
            Console.WriteLine("Teams to disband:");
            foreach (var teamsDisband in teamsToDisband)
            {
                Console.WriteLine($"{teamsDisband.Name}");
            }
        }


    }

    public class Team
    {
        //field
        private readonly List<string> members;

        //constructor
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.members = new List<string>();
        }
        //properties
        public string Name { get; private set; }

        public string Creator { get; private set; }

        //IReadOnlyCollection<string> => List<string>
        public IReadOnlyCollection<string> Members
            => this.members;
        public void AddMember(string user)
        {
            members.Add(user);
        }
    }
}
