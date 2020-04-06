BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "AspNetUserTokens" (
	"UserId"	TEXT NOT NULL,
	"LoginProvider"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Value"	TEXT,
	CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY("UserId","LoginProvider","Name"),
	CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserRoles" (
	"UserId"	TEXT NOT NULL,
	"RoleId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY("UserId","RoleId"),
	CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY("RoleId") REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserLogins" (
	"LoginProvider"	TEXT NOT NULL,
	"ProviderKey"	TEXT NOT NULL,
	"ProviderDisplayName"	TEXT,
	"UserId"	TEXT NOT NULL,
	CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY("LoginProvider","ProviderKey"),
	CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUserClaims" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	"UserId"	TEXT NOT NULL,
	CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY("UserId") REFERENCES "AspNetUsers"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetRoleClaims" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"ClaimType"	TEXT,
	"ClaimValue"	TEXT,
	"RoleId"	TEXT NOT NULL,
	CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY("RoleId") REFERENCES "AspNetRoles"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "AspNetUsers" (
	"Id"	TEXT NOT NULL,
	"AccessFailedCount"	INTEGER NOT NULL,
	"ConcurrencyStamp"	TEXT,
	"Email"	TEXT,
	"EmailConfirmed"	INTEGER NOT NULL,
	"LockoutEnabled"	INTEGER NOT NULL,
	"LockoutEnd"	TEXT,
	"NormalizedEmail"	TEXT,
	"NormalizedUserName"	TEXT,
	"PasswordHash"	TEXT,
	"PhoneNumber"	TEXT,
	"PhoneNumberConfirmed"	INTEGER NOT NULL,
	"SecurityStamp"	TEXT,
	"TwoFactorEnabled"	INTEGER NOT NULL,
	"UserName"	TEXT,
	CONSTRAINT "PK_AspNetUsers" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "AspNetRoles" (
	"Id"	TEXT NOT NULL,
	"ConcurrencyStamp"	TEXT,
	"Name"	TEXT,
	"NormalizedName"	TEXT,
	CONSTRAINT "PK_AspNetRoles" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
INSERT INTO "AspNetUserClaims" VALUES (1,'name','Alice Smith','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (2,'given_name','Alice','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (3,'family_name','Smith','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (4,'email','AliceSmith@email.com','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (5,'email_verified','true','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (6,'website','http://alice.com','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (7,'address','{ ''street_address'': ''One Hacker Way'', ''locality'': ''Heidelberg'', ''postal_code'': 69118, ''country'': ''Germany'' }','020004ae-ed35-460e-a488-789b1e49daa9');
INSERT INTO "AspNetUserClaims" VALUES (8,'address','{ ''street_address'': ''One Hacker Way'', ''locality'': ''Heidelberg'', ''postal_code'': 69118, ''country'': ''Germany'' }','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (9,'website','http://bob.com','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (10,'email_verified','true','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (11,'email','BobSmith@email.com','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (12,'family_name','Smith','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (13,'given_name','Bob','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (14,'name','Bob Smith','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUserClaims" VALUES (15,'location','somewhere','8810ceeb-6077-4209-9ae5-e74890556356');
INSERT INTO "AspNetUsers" VALUES ('020004ae-ed35-460e-a488-789b1e49daa9',0,'475dc443-3899-46b6-82d7-a1fcebff29a0',NULL,0,1,NULL,NULL,'ALICE','AQAAAAEAACcQAAAAEEeAO7nQ3jO4G9O8EI582d/p/AnCrcdI68dfXOlJdAUZ9GyaBLM/DMO4pnj8Cv/GKA==',NULL,0,'SAMT3WL7KB4T5TWLCUHA2IXPA42NC73G',0,'alice');
INSERT INTO "AspNetUsers" VALUES ('8810ceeb-6077-4209-9ae5-e74890556356',0,'09935cb0-0eb5-483f-bc8d-561fb042b95c',NULL,0,1,NULL,NULL,'BOB','AQAAAAEAACcQAAAAEG7GzlCCCQBzRumH2k6x1237nX4f8RIWBMjSZYc3O9J1cJ+NUIWcA1N+NacXcyTV/w==',NULL,0,'FYTN2JUN6WTU4VCZ2X6LK56WHAPATZKW',0,'bob');
INSERT INTO "__EFMigrationsHistory" VALUES ('20180109192453_CreateIdentitySchema','3.1.0');
CREATE UNIQUE INDEX IF NOT EXISTS "UserNameIndex" ON "AspNetUsers" (
	"NormalizedUserName"
);
CREATE INDEX IF NOT EXISTS "EmailIndex" ON "AspNetUsers" (
	"NormalizedEmail"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" (
	"RoleId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" (
	"UserId"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" (
	"UserId"
);
CREATE UNIQUE INDEX IF NOT EXISTS "RoleNameIndex" ON "AspNetRoles" (
	"NormalizedName"
);
CREATE INDEX IF NOT EXISTS "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" (
	"RoleId"
);
COMMIT;
