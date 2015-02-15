namespace ZkData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PluralizeTablesAccident : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AbuseReport", newName: "AbuseReports");
            RenameTable(name: "dbo.Account", newName: "Accounts");
            RenameTable(name: "dbo.AccountBattleAward", newName: "AccountBattleAwards");
            RenameTable(name: "dbo.SpringBattle", newName: "SpringBattles");
            RenameTable(name: "dbo.Event", newName: "Events");
            RenameTable(name: "dbo.Clan", newName: "Clans");
            RenameTable(name: "dbo.AccountRole", newName: "AccountRoles");
            RenameTable(name: "dbo.Faction", newName: "Factions");
            RenameTable(name: "dbo.FactionTreaty", newName: "FactionTreaties");
            RenameTable(name: "dbo.TreatyEffect", newName: "TreatyEffects");
            RenameTable(name: "dbo.Planet", newName: "Planets");
            RenameTable(name: "dbo.AccountPlanet", newName: "AccountPlanets");
            RenameTable(name: "dbo.ForumThread", newName: "ForumThreads");
            RenameTable(name: "dbo.ForumCategory", newName: "ForumCategories");
            RenameTable(name: "dbo.ForumLastRead", newName: "ForumLastReads");
            RenameTable(name: "dbo.ForumPost", newName: "ForumPosts");
            RenameTable(name: "dbo.AccountForumVote", newName: "AccountForumVotes");
            RenameTable(name: "dbo.ForumPostEdit", newName: "ForumPostEdits");
            RenameTable(name: "dbo.ForumThreadLastRead", newName: "ForumThreadLastReads");
            RenameTable(name: "dbo.Mission", newName: "Missions");
            RenameTable(name: "dbo.CampaignPlanet", newName: "CampaignPlanets");
            RenameTable(name: "dbo.AccountCampaignProgress", newName: "AccountCampaignProgresses");
            RenameTable(name: "dbo.Campaign", newName: "Campaigns");
            RenameTable(name: "dbo.AccountCampaignJournalProgress", newName: "AccountCampaignJournalProgresses");
            RenameTable(name: "dbo.CampaignJournal", newName: "CampaignJournals");
            RenameTable(name: "dbo.CampaignJournalVar", newName: "CampaignJournalVars");
            RenameTable(name: "dbo.CampaignVar", newName: "CampaignVars");
            RenameTable(name: "dbo.AccountCampaignVar", newName: "AccountCampaignVars");
            RenameTable(name: "dbo.CampaignPlanetVar", newName: "CampaignPlanetVars");
            RenameTable(name: "dbo.CampaignEvent", newName: "CampaignEvents");
            RenameTable(name: "dbo.CampaignLink", newName: "CampaignLinks");
            RenameTable(name: "dbo.MissionScore", newName: "MissionScores");
            RenameTable(name: "dbo.Rating", newName: "Ratings");
            RenameTable(name: "dbo.Resource", newName: "Resources");
            RenameTable(name: "dbo.MapRating", newName: "MapRatings");
            RenameTable(name: "dbo.ResourceContentFile", newName: "ResourceContentFiles");
            RenameTable(name: "dbo.ResourceDependency", newName: "ResourceDependencies");
            RenameTable(name: "dbo.ResourceSpringHash", newName: "ResourceSpringHashes");
            RenameTable(name: "dbo.Galaxy", newName: "Galaxies");
            RenameTable(name: "dbo.Link", newName: "Links");
            RenameTable(name: "dbo.PlanetFaction", newName: "PlanetFactions");
            RenameTable(name: "dbo.PlanetOwnerHistory", newName: "PlanetOwnerHistories");
            RenameTable(name: "dbo.PlanetStructure", newName: "PlanetStructures");
            RenameTable(name: "dbo.StructureType", newName: "StructureTypes");
            RenameTable(name: "dbo.Unlock", newName: "Unlocks");
            RenameTable(name: "dbo.AccountUnlock", newName: "AccountUnlocks");
            RenameTable(name: "dbo.CommanderDecorationIcon", newName: "CommanderDecorationIcons");
            RenameTable(name: "dbo.CommanderDecoration", newName: "CommanderDecorations");
            RenameTable(name: "dbo.Commander", newName: "Commanders");
            RenameTable(name: "dbo.CommanderModule", newName: "CommanderModules");
            RenameTable(name: "dbo.CommanderSlot", newName: "CommanderSlots");
            RenameTable(name: "dbo.CommanderDecorationSlot", newName: "CommanderDecorationSlots");
            RenameTable(name: "dbo.KudosPurchase", newName: "KudosPurchases");
            RenameTable(name: "dbo.TreatyEffectType", newName: "TreatyEffectTypes");
            RenameTable(name: "dbo.Poll", newName: "Polls");
            RenameTable(name: "dbo.PollOption", newName: "PollOptions");
            RenameTable(name: "dbo.PollVote", newName: "PollVotes");
            RenameTable(name: "dbo.RoleType", newName: "RoleTypes");
            RenameTable(name: "dbo.RoleTypeHierarchy", newName: "RoleTypeHierarchies");
            RenameTable(name: "dbo.SpringBattlePlayer", newName: "SpringBattlePlayers");
            RenameTable(name: "dbo.AccountIP", newName: "AccountIPs");
            RenameTable(name: "dbo.AccountUserID", newName: "AccountUserIDs");
            RenameTable(name: "dbo.ContributionJar", newName: "ContributionJars");
            RenameTable(name: "dbo.Contribution", newName: "Contributions");
            RenameTable(name: "dbo.LobbyChannelSubscription", newName: "LobbyChannelSubscriptions");
            RenameTable(name: "dbo.Punishment", newName: "Punishments");
            RenameTable(name: "dbo.AutohostConfig", newName: "AutohostConfigs");
            RenameTable(name: "dbo.Avatar", newName: "Avatars");
            RenameTable(name: "dbo.BlockedCompany", newName: "BlockedCompanies");
            RenameTable(name: "dbo.BlockedHost", newName: "BlockedHosts");
            RenameTable(name: "dbo.LobbyMessage", newName: "LobbyMessages");
            RenameTable(name: "dbo.MiscVar", newName: "MiscVars");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MiscVars", newName: "MiscVar");
            RenameTable(name: "dbo.LobbyMessages", newName: "LobbyMessage");
            RenameTable(name: "dbo.BlockedHosts", newName: "BlockedHost");
            RenameTable(name: "dbo.BlockedCompanies", newName: "BlockedCompany");
            RenameTable(name: "dbo.Avatars", newName: "Avatar");
            RenameTable(name: "dbo.AutohostConfigs", newName: "AutohostConfig");
            RenameTable(name: "dbo.Punishments", newName: "Punishment");
            RenameTable(name: "dbo.LobbyChannelSubscriptions", newName: "LobbyChannelSubscription");
            RenameTable(name: "dbo.Contributions", newName: "Contribution");
            RenameTable(name: "dbo.ContributionJars", newName: "ContributionJar");
            RenameTable(name: "dbo.AccountUserIDs", newName: "AccountUserID");
            RenameTable(name: "dbo.AccountIPs", newName: "AccountIP");
            RenameTable(name: "dbo.SpringBattlePlayers", newName: "SpringBattlePlayer");
            RenameTable(name: "dbo.RoleTypeHierarchies", newName: "RoleTypeHierarchy");
            RenameTable(name: "dbo.RoleTypes", newName: "RoleType");
            RenameTable(name: "dbo.PollVotes", newName: "PollVote");
            RenameTable(name: "dbo.PollOptions", newName: "PollOption");
            RenameTable(name: "dbo.Polls", newName: "Poll");
            RenameTable(name: "dbo.TreatyEffectTypes", newName: "TreatyEffectType");
            RenameTable(name: "dbo.KudosPurchases", newName: "KudosPurchase");
            RenameTable(name: "dbo.CommanderDecorationSlots", newName: "CommanderDecorationSlot");
            RenameTable(name: "dbo.CommanderSlots", newName: "CommanderSlot");
            RenameTable(name: "dbo.CommanderModules", newName: "CommanderModule");
            RenameTable(name: "dbo.Commanders", newName: "Commander");
            RenameTable(name: "dbo.CommanderDecorations", newName: "CommanderDecoration");
            RenameTable(name: "dbo.CommanderDecorationIcons", newName: "CommanderDecorationIcon");
            RenameTable(name: "dbo.AccountUnlocks", newName: "AccountUnlock");
            RenameTable(name: "dbo.Unlocks", newName: "Unlock");
            RenameTable(name: "dbo.StructureTypes", newName: "StructureType");
            RenameTable(name: "dbo.PlanetStructures", newName: "PlanetStructure");
            RenameTable(name: "dbo.PlanetOwnerHistories", newName: "PlanetOwnerHistory");
            RenameTable(name: "dbo.PlanetFactions", newName: "PlanetFaction");
            RenameTable(name: "dbo.Links", newName: "Link");
            RenameTable(name: "dbo.Galaxies", newName: "Galaxy");
            RenameTable(name: "dbo.ResourceSpringHashes", newName: "ResourceSpringHash");
            RenameTable(name: "dbo.ResourceDependencies", newName: "ResourceDependency");
            RenameTable(name: "dbo.ResourceContentFiles", newName: "ResourceContentFile");
            RenameTable(name: "dbo.MapRatings", newName: "MapRating");
            RenameTable(name: "dbo.Resources", newName: "Resource");
            RenameTable(name: "dbo.Ratings", newName: "Rating");
            RenameTable(name: "dbo.MissionScores", newName: "MissionScore");
            RenameTable(name: "dbo.CampaignLinks", newName: "CampaignLink");
            RenameTable(name: "dbo.CampaignEvents", newName: "CampaignEvent");
            RenameTable(name: "dbo.CampaignPlanetVars", newName: "CampaignPlanetVar");
            RenameTable(name: "dbo.AccountCampaignVars", newName: "AccountCampaignVar");
            RenameTable(name: "dbo.CampaignVars", newName: "CampaignVar");
            RenameTable(name: "dbo.CampaignJournalVars", newName: "CampaignJournalVar");
            RenameTable(name: "dbo.CampaignJournals", newName: "CampaignJournal");
            RenameTable(name: "dbo.AccountCampaignJournalProgresses", newName: "AccountCampaignJournalProgress");
            RenameTable(name: "dbo.Campaigns", newName: "Campaign");
            RenameTable(name: "dbo.AccountCampaignProgresses", newName: "AccountCampaignProgress");
            RenameTable(name: "dbo.CampaignPlanets", newName: "CampaignPlanet");
            RenameTable(name: "dbo.Missions", newName: "Mission");
            RenameTable(name: "dbo.ForumThreadLastReads", newName: "ForumThreadLastRead");
            RenameTable(name: "dbo.ForumPostEdits", newName: "ForumPostEdit");
            RenameTable(name: "dbo.AccountForumVotes", newName: "AccountForumVote");
            RenameTable(name: "dbo.ForumPosts", newName: "ForumPost");
            RenameTable(name: "dbo.ForumLastReads", newName: "ForumLastRead");
            RenameTable(name: "dbo.ForumCategories", newName: "ForumCategory");
            RenameTable(name: "dbo.ForumThreads", newName: "ForumThread");
            RenameTable(name: "dbo.AccountPlanets", newName: "AccountPlanet");
            RenameTable(name: "dbo.Planets", newName: "Planet");
            RenameTable(name: "dbo.TreatyEffects", newName: "TreatyEffect");
            RenameTable(name: "dbo.FactionTreaties", newName: "FactionTreaty");
            RenameTable(name: "dbo.Factions", newName: "Faction");
            RenameTable(name: "dbo.AccountRoles", newName: "AccountRole");
            RenameTable(name: "dbo.Clans", newName: "Clan");
            RenameTable(name: "dbo.Events", newName: "Event");
            RenameTable(name: "dbo.SpringBattles", newName: "SpringBattle");
            RenameTable(name: "dbo.AccountBattleAwards", newName: "AccountBattleAward");
            RenameTable(name: "dbo.Accounts", newName: "Account");
            RenameTable(name: "dbo.AbuseReports", newName: "AbuseReport");
        }
    }
}
