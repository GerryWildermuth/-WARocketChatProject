CREATE DATABASE  IF NOT EXISTS `projectrocketchat` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `projectrocketchat`;
-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: localhost    Database: projectrocketchat
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES ('00000000000000_CreateIdentitySchema','2.0.3-rtm-10026'),('20180531110531_applicationUserModified','2.0.3-rtm-10026'),('20180531160852_additionalModels','2.0.3-rtm-10026'),('20180601215535_chatroommemberchanges','2.0.3-rtm-10026'),('20180601220855_chatroommemberchanges2','2.0.3-rtm-10026'),('20180601222615_small','2.0.3-rtm-10026'),('20180602091203_ModelChanges','2.0.3-rtm-10026'),('20180602095419_ModelChanges2','2.0.3-rtm-10026'),('20180602174242_userwithChatRoomMembers','2.0.3-rtm-10026'),('20180605131455_newMigration','2.0.3-rtm-10026'),('20180605180428_Rename','2.0.3-rtm-10026'),('20180611080746_UserRoomList','2.0.3-rtm-10026'),('20180611110429_ManyToManyMappingOfChatroomMembersWithUsers','2.0.3-rtm-10026'),('20180612065712_RemoveFriendlist','2.0.3-rtm-10026');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetroles` (
  `Id` varchar(127) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusers` (
  `Id` varchar(127) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `PasswordHash` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `UserImage` longtext,
  `Status` tinyint(3) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `TwoFactorEnabled`, `UserName`, `UserImage`, `Status`) VALUES ('07c7837a-2b78-4266-ba4c-83ca50ce4d46',0,'ec6398a1-cfe5-46ab-97eb-a4632349d94c','gerry1313@web.de','\0','',NULL,'GERRY1313@WEB.DE','GERRY','AQAAAAEAACcQAAAAENR6rHm1DXvXhOaGznOPB+aDQy9LJwL5Ai04Y4ZcZWeiRtgAebOaPCGCdz3cZA0aXg==',NULL,'\0','41db3997-4aa9-425d-b44e-d718aa69a791','\0','Gerry',' data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAYFBMVEUxr5H///8SqYnq9fEgq4yw3NAprY4MqYg7s5ceq4v6/f3C5Nvh8u3L6OD1+/lTuqFHtpt2xbGOzr2i1shpwaqMzbxxw67Q6uOn2Mtiv6fZ7ulEtpq+4deX0sPm9PCDyrd2KhBYAAALFklEQVR4nNWd15arMAxFTbNxGiEz6WHy/385lBRIKLI5Cs55u3etAXbcZFmWhMeuVbC/HLJtekzW51gIEZ/XyTHdZtFlH6z4Xy84Hx7so20Sh77WWuYSTxX/zP/XD+NkG+0Dzo/gIgzm2TFUOmxwtUnKUKvwmM25MDkIg0sa6xxugK3BGWodpxcOSjThbLlZK20CV8PUar1ZzsBfBCWczVNtSfek1OkcCgkknO/G4t0hw90c91kowsVGQvDukHKzAH0ZhjBK/BCGVyn0kwjybQDCVRYCm++pvLdmAItgNOEin1wY8Crl087ozjqScLFTHM33lFS7kYyjCBe/zHwIxhGEAXf71RhHGDvWhLPNh/gqxo21FWBLGEm++aVNWtquHXaEp/Nn+UrG8+lzhNsPdtCnpNp+iHApPt+AlbRYfoLwqibiK6Su7ISneKoGrKSF6Wg0JMz8SfkK+Rkj4SqZtgEr6cTIHjch3A+6lT4jKfc8hD9TTjFNqR8Owl8Xeuhd+pdsxVEJV2s3euhd4Zo6GImEJ0eG4FNSEpcNGuFy+kXiXT7NwCERRu7MMXUp0naDQnhwEzBHPGAIHVolXkVZNYYJHTDUukUw4QYJHW7BQsOtOEToOCABcYDQ0Vm0rqEZtZ/w4j5gjnixJ9x/A2CO2LvV6CNcuGRr90n/2RGupv5wA/WY4T2Eju0m+iTXNoS/4DPPIn5G+YWUbxaoQVD4a074Ax2EWok0mu8XQaHFfhldYwWl1J3LYhfhEjiNSrU+vM8FQZQgXeeqay/VQbgCvttPumbzE/L8UXbMNh2EuFkmPPdtVE84/2TXbNNOmMHeO3iagjN8dfs+o5UQZ8vo4dCfPWzG8VtHQxvhDPTGvOdQTuADARsSVMIU9cawz5qqIcLel9II56hNvaIeE8EMYNUyKFoIUb/owK6m8aOiBr6kEF5B1lpocpiJeql+f+kb4QnVR1t+zh7BOs7byHgjPIPe5ZuFiKIGvzwPEUagQS8TI0CcFaVf3TYvhDNYbzGNmpij5lP5cu72QrhBvSc2BMSNxFfjrUkYoGbt7u1apzYw460Z5tck3MHeQrNm6trDJvFdN+ECZnGbd1LcFCBUwxpuEP6iXiLNQ5c8L4G9veG0qRPimjC0CZWEDcRmI9YJYU0ofJtAyQjm3Gs0Yo0Q14Sv0xlNsBWx2Yg1Qti2MH+DTczyHkcoaxvFJ+EK6CD1LQCRhEI/HW9PQpz3yQXCp2HzJET6uJXNbR4koQjfCVGbilIWJo3nLZFf8NxiPAhh620hu9UCSfjcvd0JF9CYEm0SAHrXAXoW5N8XjDvhFnrcRXAEvyuDHufJu7P9Tog9z7Oy2rA/8sNPdCME2hOFLLaHUIuj/IZ5gxC2MawUGsbTlzqC2zCtE87QJ9o293egs3mucFYjBHfS1202TTH2G+7dtCIEDwGpTH2JhRT4vtitm5aE4E6qN4HN7mkVwDx9lapuWhJC7SW7aabSBvpT6+WDEOc/KB9sn9ZiBbWs5OZBuIY+92gNiJ5P13dCmB+4lNVKcdcVSqiCGyHUqHeJsNxCFYTYtcLKV3oXzt1Xfkp6I8QutX1xgoMCr/pxRRiADRrflbk076ZBSYg22aw2h5UuDJ8i0Kvh67GBkcDbi3JFFHibnh5H86oTOnK+8NYIrBvx8Vwr4eOudUH4h79y0BElOCRUUE1N6i8nxJrdtwfbeDG2DFfIcuNbgAO67082N05Z7vrrn5wQvPu9ydyvj++iorRqBH4qLaWM/fosN5ByA0t4HA+28OvPmO5YeWLF0jvM/frYLdxD4UoAz7brMjbdmL5DLQTHYiEs/PrQ08On9FJceHqpsTsKuw1/fsdFYM+0HpJtQeV9wp48PaQPImO6g/cWyTognkVLyEyAz7Qe0mZLPi6qrSm5FTwmjfFkypVbRKYCvel8PtqIEOtkq33GUSQ8T85XIiNCttQUiYD6u+t6CynvE9NakWvNR2gURYs+O3xqLfiebdCIfE3IyCfe7wV0Cn3IXhcvIXU6BcdJvIiT0afdXrtw5viJeVuR5DmF3SVrVSzOnI+XlPk0Zu2jnKtFIRIh6xes+WyaUtMTJmx2aaXJCXO7lGtvUWl6wpRtf1hpesIt2x6/0vSEGZef5qbJCfWBy9d20+SE4YXLX3rT5IR6yeXzvmlyQrXgOreoRDrvZvIjVgpXXGdPlUgRYFxOqEps54eVaHsLxnGSdyKuM+BSLXk42pTyTXblGTDLOX4pRQ0dOrLtEMtzfJ7lQoYqpnuiDgKbn+6hMhbjD/4DFnUMr5HZMfc+ulrXTexRGU+DDRGQWltXaSyqQ2IKDD6kwXFtOd71Mq4Y3OqS+jjIW1wbKDZR+uJqUeimRcsrqpbiLTYREl8a+r8YvFKz+VEhbK1bfGkweqqRWmToMrBBJsY35C1GeKzpK1UCLBta02V0+s9bnPc4q0aqnW3A7LD249J/PmL1R5z85Hw2F9PpGlVi8XHfwj7gSh1RFV+7dUqs54nHnRnbe086Bk6fPZrbFnp73HuyWxGlVSCwnTKrrlq7u2ZjfPtH1prvL/qziSCu3T+0OIOl1XgByiIbb+0OqfF6IWP+GeZVxgWZ6veATQ03naBLvFNkWlSrcZfbrJv2pHhn1cxsF9S4j28UKzAVoGe20WvmVDDpptZ3fgCaGZyIv+TFMMltAqh3bq0/g5a4/YlxfhrjxKRYkW3ot/w01BxDVhkvkKIOxbccQ9S/9D+/EDZFnDHe80QRm3/UNWaMSIBtub5oN6sqY3ZS0S60t+Rro+Xcs0oAhdUPpSlac+6R8iY6QEhKAtqaN5Fkfn8JYT2vg2H+0i8h7MhfShnD30HYlYOW0ojfQdiZR5jQiF9B2J0LmtCIX0HYk897eJv4DYR9OdmHfcPfQNibV3/QsPkCwv7aCIPXAL+AcKC+xdAWw33CoRolQ3VmnCccrjMzEIPlPCGhVpB37eunrhNS6j31u91cJyTV7OotEeY4IbHumpd2P8NtQmrtvD5nj9uE5PqHPTUsnSak17DsMd5cJjSpQ9qdOc1hQrNasp31gF0mNKsH3FXT2V1C05rOXXW5w59garV7hH3jutxdtdVDf2q1f5ZFbXWOPI1s6jsw6iFEVh9nVtcsM0CIK9PLLdV3qNlH2DWhuqb+g/deQi/6BsSBALR+wm9AHIqwGyD0fliTVgDUvRASCb3M7VZUg7n9Bgltwh4/J0IU7zChd3AXUR2GP59A6O50QwrjpRB6FzcRFSmFEYmQK7noOBHT3NIIvYVpCDK7pCTGnxEJjUOQuRWuqUGgVELPO7rUUzU9TplO6NLCaHKZxYDQW+JvIltJapMoXhPCfDC60FM1eQiaEzphpfqGWaYNCb2TYM3YM6hQmN7nNCX0vOuUzajMi0mZE3pL2+uAo6WFxUUBC0LP24BrMdIklVUIthWht5hgUtVru2sCdoT5jkp+llFL2xMTW0JvtvE/11Wlv7G+D2hN6HnB7kPDUardiBu5IwhHXpan8/2OuqczivADjGP5RhPmjKnmm3O0TkffsxpNWGQhAScGuklqjciYAiDMFY3OQvLO5yeYE3UMYd5ZN6i8QCWelhvUNUAUYa75DtNb8965Aya8ARIWyY9GQ0odpnPobX8ooVdlJLPNu1bkebPNhNYtNGGhIEpjrY2S6MlQ6ziNOJKJcBAWCuZZolXeZ4c4ZT7slE6yOVeqFC7CUsHycF0L7euCtMFa/DP/X1+L5HrYs+aBYSWstPrbX6Jsmx6T9blIKxaf18kx3WbRZf/3gewF/5/+oEgjx9eeAAAAAElFTkSuQmCC',0),('1988d98f-a8cb-497a-9493-7b9b07632247',0,'03fe5e41-d088-484c-aca0-01a83d9c8fd7','test@teeest.de','\0','',NULL,'TEST@TEEEST.DE','TESTER','AQAAAAEAACcQAAAAELIevjifxuwlU1GMPx550lfu/Fi1eyNxcpA8gn7QsH259y393EWHwImvuLwzSDKZGQ==',NULL,'\0','f95a217e-bec4-49d5-b496-01d377013662','\0','tester',' data:image/png;base64,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',0),('40bbd5d7-4565-4ffd-9884-0a333f149750',0,'039ef649-e96d-4c1c-a53a-54beb03eb86d','test@test.de','\0','',NULL,'TEST@TEST.DE','TEST','AQAAAAEAACcQAAAAECo9Hm/ncRhaReIjmmR4bHJ/6HcovHXUArO6HTOZkVJih4pem91KS1x/jAjTdBrx/w==',NULL,'\0','99d3e642-e323-4624-84c9-2dc46b3c2118','\0','test',' data:image/png;base64,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',0),('e6b85948-333b-4f37-968e-aeb53cdf11ee',0,'333b18df-0af8-4b13-b8d6-53555475c471','gerry1313@123web.de','\0','',NULL,'GERRY1313@123WEB.DE','GERRYS','AQAAAAEAACcQAAAAEBHBEIK28CNjYBzTRvwmPZx48KVKZfMZnOe/KsgnmLzlXxG93uCKwCeZvoYAtm+sVQ==',NULL,'\0','5aceda25-4fbe-471c-a532-4a4a42b20341','\0','Gerrys',' data:image/png;base64,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',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chatroommembers`
--

DROP TABLE IF EXISTS `chatroommembers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chatroommembers` (
  `Id` char(36) NOT NULL,
  `WritingPrivilege` bit(1) NOT NULL,
  `ChatroomId` char(36) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_ChatroomMembers_ChatroomId` (`ChatroomId`),
  CONSTRAINT `FK_ChatroomMembers_Chatrooms_ChatroomId` FOREIGN KEY (`ChatroomId`) REFERENCES `chatrooms` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chatroommembers`
--

LOCK TABLES `chatroommembers` WRITE;
/*!40000 ALTER TABLE `chatroommembers` DISABLE KEYS */;
INSERT INTO `chatroommembers` (`Id`, `WritingPrivilege`, `ChatroomId`) VALUES ('0e34b6fa-5e01-44d6-b961-7c063f6cd7ab','\0','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10'),('9ede2094-f6b4-4fd9-b7bf-e126d119e6b6','\0','af200f6e-5d60-47bf-8229-8218f9d40097'),('f19648cd-24d7-4a72-9021-178268f76d46','\0','233ec3b8-6721-4f81-b656-a179fc7bb265');
/*!40000 ALTER TABLE `chatroommembers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `chatrooms`
--

DROP TABLE IF EXISTS `chatrooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `chatrooms` (
  `Id` char(36) NOT NULL,
  `ChatroomDesription` longtext,
  `ChatroomName` varchar(127) NOT NULL,
  `ChatroomTopic` longtext,
  `CreationDate` datetime(6) NOT NULL,
  `Password` longtext,
  `Private` bit(1) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Chatrooms_ChatroomName` (`ChatroomName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chatrooms`
--

LOCK TABLES `chatrooms` WRITE;
/*!40000 ALTER TABLE `chatrooms` DISABLE KEYS */;
INSERT INTO `chatrooms` (`Id`, `ChatroomDesription`, `ChatroomName`, `ChatroomTopic`, `CreationDate`, `Password`, `Private`) VALUES ('1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10',NULL,'Raum',NULL,'2018-06-15 00:00:00.000000',NULL,'\0'),('233ec3b8-6721-4f81-b656-a179fc7bb265',NULL,'tester',NULL,'2018-06-15 00:00:00.000000',NULL,'\0'),('af200f6e-5d60-47bf-8229-8218f9d40097',NULL,'neuerRaum',NULL,'2018-06-15 00:00:00.000000',NULL,'\0');
/*!40000 ALTER TABLE `chatrooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `messages`
--

DROP TABLE IF EXISTS `messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `messages` (
  `Id` char(36) NOT NULL,
  `ChatroomId` char(36) NOT NULL,
  `MessageString` longtext NOT NULL,
  `MessageTime` datetime(6) NOT NULL,
  `UserId` varchar(127) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Messages_ChatroomId` (`ChatroomId`),
  KEY `IX_Messages_UserId` (`UserId`),
  CONSTRAINT `FK_Messages_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Messages_Chatrooms_ChatroomId` FOREIGN KEY (`ChatroomId`) REFERENCES `chatrooms` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messages`
--

LOCK TABLES `messages` WRITE;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
INSERT INTO `messages` (`Id`, `ChatroomId`, `MessageString`, `MessageTime`, `UserId`) VALUES ('041f3404-b961-4aea-9171-384f603a160b','af200f6e-5d60-47bf-8229-8218f9d40097','hallo','2018-06-15 10:53:34.412204','40bbd5d7-4565-4ffd-9884-0a333f149750'),('06fa6ead-16cd-4b4a-9a4a-e5ae8f31cf55','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','6','2018-06-15 10:58:32.714358','40bbd5d7-4565-4ffd-9884-0a333f149750'),('172a2566-5e57-4f6b-879a-4922e2b5823a','af200f6e-5d60-47bf-8229-8218f9d40097','geryy hallo','2018-06-15 10:54:41.942755','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('196b574b-6e79-4324-b3d5-0cfbe773d385','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','8','2018-06-15 10:58:33.791041','40bbd5d7-4565-4ffd-9884-0a333f149750'),('2621372b-36dd-44c6-be66-9faa44b64751','af200f6e-5d60-47bf-8229-8218f9d40097','hey','2018-06-15 10:52:54.442005','40bbd5d7-4565-4ffd-9884-0a333f149750'),('290a25e2-9f2b-4d24-91c9-d36abea0b2fa','af200f6e-5d60-47bf-8229-8218f9d40097','test','2018-06-15 10:52:01.458069','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('2d15ec6b-f246-44bd-beb9-9af63af37dea','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','5','2018-06-15 10:58:32.053961','40bbd5d7-4565-4ffd-9884-0a333f149750'),('54b50ae2-bbdc-42ca-b2f4-1fd648e0a59d','af200f6e-5d60-47bf-8229-8218f9d40097','test','2018-06-15 10:55:13.743144','40bbd5d7-4565-4ffd-9884-0a333f149750'),('72d63ebd-3797-4846-9a09-4097fe42e268','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','tester','2018-06-18 08:45:51.386560','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('7481c179-3ece-4dc2-b608-c093247dc9b6','233ec3b8-6721-4f81-b656-a179fc7bb265','test','2018-06-15 08:48:45.152153','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('77f0251c-89ec-4702-8d3b-cdeea59cbea0','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','test','2018-06-15 10:58:17.701602','40bbd5d7-4565-4ffd-9884-0a333f149750'),('93420646-855d-4063-96fc-234d0aebfdda','af200f6e-5d60-47bf-8229-8218f9d40097','neue naricht','2018-06-15 10:53:54.859024','40bbd5d7-4565-4ffd-9884-0a333f149750'),('9869426b-ee62-4156-aebd-5c8cb2b6cf14','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','1','2018-06-15 10:58:29.932146','40bbd5d7-4565-4ffd-9884-0a333f149750'),('a100a647-f7cf-4cbd-8886-b7cfec4242fa','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','7','2018-06-15 10:58:33.335605','40bbd5d7-4565-4ffd-9884-0a333f149750'),('b7fe72bd-d2c3-4053-b64f-ea3748d1f1a7','af200f6e-5d60-47bf-8229-8218f9d40097','hey','2018-06-15 11:05:17.413775','1988d98f-a8cb-497a-9493-7b9b07632247'),('bc54f0f5-1cf8-404c-8624-0ce0b9378188','233ec3b8-6721-4f81-b656-a179fc7bb265','hallo','2018-06-15 10:53:07.171298','40bbd5d7-4565-4ffd-9884-0a333f149750'),('bedc6284-c446-4dea-b69f-85566ea97ec3','af200f6e-5d60-47bf-8229-8218f9d40097','FirstMessage','2018-06-15 10:51:18.284920','40bbd5d7-4565-4ffd-9884-0a333f149750'),('bf2fecfe-e3c7-49de-b902-011c52215680','af200f6e-5d60-47bf-8229-8218f9d40097','hallo','2018-06-15 10:52:37.493856','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('c796755f-3afd-47ef-8dae-b64ebf65cf71','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','3','2018-06-15 10:58:30.701096','40bbd5d7-4565-4ffd-9884-0a333f149750'),('d05d95a0-3f57-48c8-afcd-90b852d87060','233ec3b8-6721-4f81-b656-a179fc7bb265','test','2018-06-15 08:48:46.441883','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('d54f507a-1e1e-4dae-97e7-236b529b66a7','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','4','2018-06-15 10:58:31.090480','40bbd5d7-4565-4ffd-9884-0a333f149750'),('d7d5bfcf-2b30-4ad5-8a6a-8270e0bfa876','233ec3b8-6721-4f81-b656-a179fc7bb265','test','2018-06-15 10:51:04.342927','40bbd5d7-4565-4ffd-9884-0a333f149750'),('e8463dbb-0b60-44f0-912f-d46ea7c8d72f','af200f6e-5d60-47bf-8229-8218f9d40097','hey there','2018-06-15 10:54:23.562159','40bbd5d7-4565-4ffd-9884-0a333f149750'),('ea57e064-ec85-473f-9206-cea3cb73a0ce','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10','2','2018-06-15 10:58:30.302644','40bbd5d7-4565-4ffd-9884-0a333f149750'),('ed294421-3ee3-49ff-88f8-556b24cb6482','233ec3b8-6721-4f81-b656-a179fc7bb265','hallo','2018-06-15 08:48:47.697192','07c7837a-2b78-4266-ba4c-83ca50ce4d46');
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userchatroommember`
--

DROP TABLE IF EXISTS `userchatroommember`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userchatroommember` (
  `ChatroomMembersId` char(36) NOT NULL,
  `ApplicationUserId` varchar(127) NOT NULL,
  PRIMARY KEY (`ChatroomMembersId`,`ApplicationUserId`),
  KEY `IX_UserChatroomMember_ApplicationUserId` (`ApplicationUserId`),
  CONSTRAINT `FK_UserChatroomMember_AspNetUsers_ApplicationUserId` FOREIGN KEY (`ApplicationUserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserChatroomMember_ChatroomMembers_ChatroomMembersId` FOREIGN KEY (`ChatroomMembersId`) REFERENCES `chatroommembers` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userchatroommember`
--

LOCK TABLES `userchatroommember` WRITE;
/*!40000 ALTER TABLE `userchatroommember` DISABLE KEYS */;
INSERT INTO `userchatroommember` (`ChatroomMembersId`, `ApplicationUserId`) VALUES ('0e34b6fa-5e01-44d6-b961-7c063f6cd7ab','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('9ede2094-f6b4-4fd9-b7bf-e126d119e6b6','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('f19648cd-24d7-4a72-9021-178268f76d46','07c7837a-2b78-4266-ba4c-83ca50ce4d46'),('9ede2094-f6b4-4fd9-b7bf-e126d119e6b6','1988d98f-a8cb-497a-9493-7b9b07632247'),('0e34b6fa-5e01-44d6-b961-7c063f6cd7ab','40bbd5d7-4565-4ffd-9884-0a333f149750'),('9ede2094-f6b4-4fd9-b7bf-e126d119e6b6','40bbd5d7-4565-4ffd-9884-0a333f149750'),('f19648cd-24d7-4a72-9021-178268f76d46','40bbd5d7-4565-4ffd-9884-0a333f149750');
/*!40000 ALTER TABLE `userchatroommember` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroomlists`
--

DROP TABLE IF EXISTS `userroomlists`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userroomlists` (
  `Id` char(36) NOT NULL,
  `ApplicationUserId` varchar(127) NOT NULL,
  `ChatroomId` char(36) NOT NULL,
  `ChatroomStatus` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_UserRoomLists_ChatroomId_ApplicationUserId` (`ChatroomId`,`ApplicationUserId`),
  KEY `IX_UserRoomLists_ApplicationUserId` (`ApplicationUserId`),
  CONSTRAINT `FK_UserRoomLists_AspNetUsers_ApplicationUserId` FOREIGN KEY (`ApplicationUserId`) REFERENCES `aspnetusers` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRoomLists_Chatrooms_ChatroomId` FOREIGN KEY (`ChatroomId`) REFERENCES `chatrooms` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroomlists`
--

LOCK TABLES `userroomlists` WRITE;
/*!40000 ALTER TABLE `userroomlists` DISABLE KEYS */;
INSERT INTO `userroomlists` (`Id`, `ApplicationUserId`, `ChatroomId`, `ChatroomStatus`) VALUES ('01573113-7ab7-4587-a478-7f358b7cb1ab','07c7837a-2b78-4266-ba4c-83ca50ce4d46','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10',0),('4483b8f3-8416-4246-a5e3-521561b0a90d','07c7837a-2b78-4266-ba4c-83ca50ce4d46','af200f6e-5d60-47bf-8229-8218f9d40097',0),('6988cf9d-91d2-4242-8f70-ed4e03360794','40bbd5d7-4565-4ffd-9884-0a333f149750','233ec3b8-6721-4f81-b656-a179fc7bb265',0),('70289ad6-503d-4a9e-961b-865e758d1b53','1988d98f-a8cb-497a-9493-7b9b07632247','af200f6e-5d60-47bf-8229-8218f9d40097',0),('82cde087-ee28-45e2-a36d-5316ced50f60','07c7837a-2b78-4266-ba4c-83ca50ce4d46','233ec3b8-6721-4f81-b656-a179fc7bb265',0),('91c6d472-39b4-4a18-9c2f-4532686af456','40bbd5d7-4565-4ffd-9884-0a333f149750','1b9dab8b-d2b9-46c9-9302-27b6ff9c5e10',0),('c958dab1-a3a7-40b8-a8b1-d07394b6f705','40bbd5d7-4565-4ffd-9884-0a333f149750','af200f6e-5d60-47bf-8229-8218f9d40097',0);
/*!40000 ALTER TABLE `userroomlists` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-19  8:32:44
