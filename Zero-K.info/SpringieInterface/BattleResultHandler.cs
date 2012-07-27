﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LobbyClient;
using ZeroKWeb.Controllers;
using ZkData;

namespace ZeroKWeb.SpringieInterface
{
    public class BattlePlayerResult
    {
        public int AllyNumber;
        public string CommanderType;
        public bool IsIngameReady;
        public bool IsSpectator;
        public bool IsVictoryTeam;
        public int LobbyID;
        public int? LoseTime;
        public int Rank;
    }

    public class BattleResult
    {
        public int Duration;
        public string EngineBattleID;
        public string EngineVersion;
        public DateTime? IngameStartTime;
        public bool IsBots;
        public bool IsMission;
        public string Map;
        public string Mod;
        public string ReplayName;
        public DateTime StartTime;
        public string Title;
    }


    public class BattleResultHandler
    {
        public static string SubmitSpringBattleResult(BattleContext context,
                                                      string password,
                                                      BattleResult result,
                                                      List<BattlePlayerResult> players,
                                                      List<string> extraData) {
            try {
                Account acc = AuthServiceClient.VerifyAccountPlain(context.AutohostName, password);
                if (acc == null) throw new Exception("Account name or password not valid");
                AutohostMode mode = context.GetMode();
                var db = new ZkDataContext();

                if (extraData == null) extraData = new List<string>();


                var sb = new SpringBattle
                         {
                             HostAccountID = acc.AccountID,
                             Duration = result.Duration,
                             EngineGameID = result.EngineBattleID,
                             MapResourceID = db.Resources.Single(x => x.InternalName == result.Map).ResourceID,
                             ModResourceID = db.Resources.Single(x => x.InternalName == result.Mod).ResourceID,
                             HasBots = result.IsBots,
                             IsMission = result.IsMission,
                             PlayerCount = players.Count(x => !x.IsSpectator),
                             StartTime = result.StartTime,
                             Title = result.Title,
                             ReplayFileName = result.ReplayName,
                             EngineVersion = result.EngineVersion,
                         };
                db.SpringBattles.InsertOnSubmit(sb);

                foreach (BattlePlayerResult p in players) {
                    sb.SpringBattlePlayers.Add(new SpringBattlePlayer
                                               {
                                                   AccountID = db.Accounts.First(x => x.LobbyID == p.LobbyID).AccountID,
                                                   AllyNumber = p.AllyNumber,
                                                   CommanderType = p.CommanderType,
                                                   IsInVictoryTeam = p.IsVictoryTeam,
                                                   IsSpectator = p.IsSpectator,
                                                   Rank = p.Rank,
                                                   LoseTime = p.LoseTime
                                               });
                }

                db.SubmitChanges();

                // awards
                foreach (string line in extraData.Where(x => x.StartsWith("award"))) {
                    string[] partsSpace = line.Substring(6).Split(new[] { ' ' }, 3);
                    string name = partsSpace[0];
                    string awardType = partsSpace[1];
                    string awardText = partsSpace[2];

                    SpringBattlePlayer player = sb.SpringBattlePlayers.FirstOrDefault(x => x.Account.Name == name && x.Account.LobbyID != null);
                    if (player != null) {
                        db.AccountBattleAwards.InsertOnSubmit(new AccountBattleAward
                                                              {
                                                                  AccountID = player.AccountID,
                                                                  SpringBattleID = sb.SpringBattleID,
                                                                  AwardKey = awardType,
                                                                  AwardDescription = awardText
                                                              });
                    }
                }
                db.SubmitChanges();

                Dictionary<int, int> orgLevels = sb.SpringBattlePlayers.Select(x => x.Account).ToDictionary(x => x.AccountID, x => x.Level);

                sb.CalculateElo();
                db.SubmitAndMergeChanges();

                try {
                    foreach (Account a in sb.SpringBattlePlayers.Where(x => !x.IsSpectator).Select(x => x.Account)) Global.Nightwatch.Tas.Extensions.PublishAccountData(a);
                } catch (Exception ex) {
                    Trace.TraceError("error updating extension data: {0}", ex);
                }

                var text = new StringBuilder();

                if (mode == AutohostMode.Planetwars && sb.SpringBattlePlayers.Count(x => !x.IsSpectator) >= 2 && sb.Duration >= GlobalConst.MinDurationForPlanetwars) {
                    ProcessPlanetwars(result, extraData, db, sb, text);
                }

                foreach (Account account in sb.SpringBattlePlayers.Select(x => x.Account)) {
                    if (account.Level > orgLevels[account.AccountID]) {
                        try {
                            string message =
                                string.Format("Congratulations {0}! You just leveled up to level {1}. http://zero-k.info/Users/Detail/{2}",
                                              account.Name,
                                              account.Level,
                                              account.AccountID);
                            text.AppendLine(message);
                            AuthServiceClient.SendLobbyMessage(account, message);
                        } catch (Exception ex) {
                            Trace.TraceError("Error sending level up lobby message: {0}", ex);
                        }
                    }
                }

                text.AppendLine(string.Format("Debriefing room for a battle at {0}", context.Map));
                text.AppendLine(string.Format("View full battle details and demo at http://zero-k.info/Battles/Detail/{0}", sb.SpringBattleID));

                // create debriefing room, join players there and output message
                string channelName = "B" + sb.SpringBattleID;
                var joinplayers = new List<string>();
                joinplayers.AddRange(context.Players.Select(x => x.Name)); // add those who were there at start
                joinplayers.AddRange(sb.SpringBattlePlayers.Select(x => x.Account.Name)); // add those who played
                TasClient tas = Global.Nightwatch.Tas;
                Battle bat = tas.ExistingBattles.Values.FirstOrDefault(x => x.Founder.Name == context.AutohostName); // add those in lobby atm

                if (bat != null) {
                    List<string> inbatPlayers = bat.Users.Select(x => x.Name).ToList();
                    joinplayers.RemoveAll(x => inbatPlayers.Contains(x));
                }
                foreach (string jp in joinplayers.Distinct().Where(x => x != context.AutohostName)) tas.ForceJoinChannel(jp, channelName);
                tas.JoinChannel(channelName); // join nightwatch and say it
                tas.Say(TasClient.SayPlace.Channel, channelName, text.ToString(), true);
                tas.LeaveChannel(channelName);

                text.Append(string.Format("Debriefing in #{0} - spring://chat/channel/{0}  ", channelName));
                return text.ToString();
            } catch (Exception ex) {
                return ex.ToString();
            }
        }

        static void ProcessPlanetwars(BattleResult result, List<string> extraData, ZkDataContext db, SpringBattle sb, StringBuilder text) {
            Galaxy gal = db.Galaxies.Single(x => x.IsDefault);
            Planet planet = gal.Planets.Single(x => x.MapResourceID == sb.MapResourceID);

            text.AppendFormat("Battle on http://zero-k.info/PlanetWars/Planet/{0} has ended\n", planet.PlanetID);

            List<int> presentFactions =
                sb.SpringBattlePlayers.Where(x => !x.IsSpectator).Where(x => x.Account.Faction != null).GroupBy(x => x.Account.FactionID).Select(
                    x => x.Key ?? 0).ToList();

            Faction attacker = planet.GetAttacker(presentFactions);
            if (attacker == null) {
                text.AppendLine("ERROR: Invalid attacker");
                return;
            }
            Faction defender = planet.Faction;

            Faction winner = null;
            bool wasCcDestroyed = false;
            List<int> winnerTeams =
                sb.SpringBattlePlayers.Where(x => x.IsInVictoryTeam && !x.IsSpectator).Select(x => x.AllyNumber).Distinct().ToList();
            if (winnerTeams.Count == 1) {
                int winNum = winnerTeams[0];
                if (winNum > 1) {
                    text.AppendLine("ERROR: Invalid winner");
                    return;
                }

                if (winNum == 0) winner = attacker;
                else winner = defender;
                wasCcDestroyed = extraData.Any(x => x.StartsWith("hqkilled," + winner));
            }




            // distribute influence
            if (winner != null) {
                double planetDefs = (planet.PlanetStructures.Where(x => x.IsActive).Sum(x => x.StructureType.EffectDropshipDefense) ?? 0);
                int totalShips = (planet.PlanetFactions.Where(x => x.Faction == attacker).Sum(x => (int?)x.Dropships) ?? 0);
                int involvedCount =
                    sb.SpringBattlePlayers.Count(
                        x => !x.IsSpectator && x.Account.Faction != null && (x.Account.Faction == winner || x.Account.Faction == defender));

                double influence = GlobalConst.BaseInfluencePerBattle;

                double shipBonus = winner == attacker ? (totalShips - planetDefs)*GlobalConst.InfluencePerShip : 0;
                double techBonus = winner.GetFactionUnlocks().Count()*GlobalConst.InfluencePerTech;
                int playerBonus = involvedCount*GlobalConst.InfluencePerInvolvedPlayer;
                double ccMalus = wasCcDestroyed ? -influence*GlobalConst.InfluenceCcKilledMultiplier : 0;

                influence = influence + shipBonus + techBonus + playerBonus + ccMalus;

                // save influence gains
                PlanetFaction entry = planet.PlanetFactions.FirstOrDefault(x => x.Faction == winner);
                if (entry == null) {
                    entry = new PlanetFaction { Faction = winner, Planet = planet, };
                    planet.PlanetFactions.Add(entry);
                }

                entry.Influence += influence;

                // clamping of influence
                // gained over 100, sole owner
                if (entry.Influence >= 100) {
                    entry.Influence = 100;
                    foreach (var pf in planet.PlanetFactions.Where(x => x.Faction != winner)) pf.Influence = 0;
                } else {
                    var sumOthers = planet.PlanetFactions.Where(x => x.Faction != winner).Sum(x => (double?)x.Influence) ?? 0;
                    if (sumOthers + entry.Influence > 100) {
                        var exces = 100 - sumOthers - entry.Influence;
                        foreach (var pf in planet.PlanetFactions.Where(x => x.Faction != winner)) pf.Influence -= pf.Influence/sumOthers*exces;
                    }
                }


                var ev = Global.CreateEvent("{0} gained {1} ({4}{5}{6}{7}) influence at {2} from {3} ",
                                            winner,
                                            influence,
                                            planet,
                                            sb,
                                            techBonus > 0 ? "+" + techBonus + " from techs " : "",
                                            playerBonus > 0 ? "+" + playerBonus + " from commanders " : "",
                                            shipBonus > 0 ? "+" + shipBonus + " from ships " : "",
                                            ccMalus > 0 ? "" + ccMalus + " from destroyed CC " : "");
                db.Events.InsertOnSubmit(ev);
                text.AppendLine(ev.PlainText);
            }

            // distribute metal
            List<Account> winners =
                sb.SpringBattlePlayers.Where(x => !x.IsSpectator && x.IsInVictoryTeam && x.Account.Faction != null).Select(x => x.Account).ToList();
            double metalPerWinner = GlobalConst.BaseMetalPerBattle/winners.Count;
            foreach (Account w in winners) {
                w.ProduceMetal(metalPerWinner);

                var ev = Global.CreateEvent("{0} ({4}) gained {1} metal from battle {2} at {3}",
                                            w,
                                            Math.Floor(metalPerWinner),
                                            sb,
                                            planet,
                                            w.Clan != null ? (object)w.Clan : "no clan");
                db.Events.InsertOnSubmit(ev);
                text.AppendLine(ev.PlainText);
            }

            // remove dropships
            foreach (var pf in planet.PlanetFactions.Where(x => x.Faction == attacker)) pf.Dropships = 0;


            // produce dropships
            foreach (
                Account acc in
                    sb.SpringBattlePlayers.Where(x => !x.IsSpectator).Select(x => x.Account).Where(x => x.Faction != null && x.Faction != attacker)) {
                acc.ProduceDropships(GlobalConst.DropshipsPerBattlePlayer);

                var ev = Global.CreateEvent("{0} ({4}) gained {1} dropships from battle {2} at {3}",
                                            acc,
                                            GlobalConst.DropshipsPerBattlePlayer,
                                            sb,
                                            planet,
                                            acc.Clan != null ? (object)acc.Clan : "no clan");
                db.Events.InsertOnSubmit(ev);
                text.AppendLine(ev.PlainText);
            }

            // add attack points
            foreach (
                Account acc in
                    sb.SpringBattlePlayers.Where(x => !x.IsSpectator).Select(x => x.Account).Where(
                        x => x.Faction != null && (x.Faction == attacker || x.Faction == defender))) {
                AccountPlanet entry = planet.AccountPlanets.SingleOrDefault(x => x.AccountID == acc.AccountID);
                if (entry == null) {
                    entry = new AccountPlanet { AccountID = acc.AccountID, PlanetID = planet.PlanetID };
                    db.AccountPlanets.InsertOnSubmit(entry);
                }
                entry.AttackPoints += acc.Faction == winner ? GlobalConst.AttackPointsForVictory : GlobalConst.AttackPointsForDefeat;
            }

            // destroy pw structures killed ingame
            var handled = new List<string>();
            foreach (string line in extraData.Where(x => x.StartsWith("structurekilled"))) {
                string[] data = line.Substring(16).Split(',');
                string unitName = data[0];
                if (handled.Contains(unitName)) continue;
                handled.Add(unitName);
                foreach (PlanetStructure s in
                    db.PlanetStructures.Where(x => x.PlanetID == planet.PlanetID && x.StructureType.IngameUnitName == unitName && x.IsActive)) {
                    if (s.StructureType.IsIngameDestructible) {
                        db.PlanetStructures.DeleteOnSubmit(s);
                        var ev = Global.CreateEvent("{0} has been destroyed on {1} planet {2}. {3}", s.StructureType.Name, defender, planet, sb);
                        db.Events.InsertOnSubmit(ev);
                        text.AppendLine(ev.PlainText);
                    }
                }
            }
            db.SubmitAndMergeChanges();


            // destroy structures by battle (usually defenses)
            foreach (PlanetStructure s in planet.PlanetStructures.Where(x => x.StructureType.BattleDeletesThis).ToList()) planet.PlanetStructures.Remove(s);



            // TODO correct IP after battle

            //  TODO: IP squeeze if overflow

   
            int? oldOwner = planet.OwnerAccountID;
            gal.Turn++;
            db.SubmitChanges();

            db = new ZkDataContext(); // is this needed - attempt to fix setplanetownersbeing buggy
            PlanetwarsController.SetPlanetOwners(db, sb);
            gal = db.Galaxies.Single(x => x.IsDefault);

            planet = gal.Planets.Single(x => x.Resource.InternalName == result.Map);
            if (planet.OwnerAccountID != oldOwner && planet.OwnerAccountID != null) {
                text.AppendFormat("Congratulations!! Planet {0} was conquered by {1} !!  http://zero-k.info/PlanetWars/Planet/{2}\n",
                                  planet.Name,
                                  planet.Account.Name,
                                  planet.PlanetID);
            }

            try {

                // store history
                foreach (Planet p in gal.Planets) {
                    db.PlanetOwnerHistories.InsertOnSubmit(new PlanetOwnerHistory
                                                           {
                                                               PlanetID = p.PlanetID,
                                                               OwnerAccountID = p.OwnerAccountID,
                                                               OwnerClanID = p.OwnerAccountID != null ? p.Account.ClanID : null,
                                                               OwnerFactionID = p.OwnerFactionID,
                                                               Turn = gal.Turn
                                                           });
                }

                db.SubmitChanges();
            } catch (Exception ex) {
                text.AppendLine("error saving history: " + ex);
            }
        }
    }
}