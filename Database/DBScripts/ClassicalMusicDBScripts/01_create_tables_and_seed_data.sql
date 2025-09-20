-- =========================
-- Classical Music Database
USE ClassicalMusic
GO
-- =========================

-- Table: AppResource
DROP TABLE IF EXISTS AppResource; 
CREATE TABLE AppResource (
    ID INT PRIMARY KEY IDENTITY(1,1),
    AppResource_name NVARCHAR(100) NOT NULL,
    AppResource_code VARCHAR(2) NOT NULL
);

INSERT INTO AppResource(AppResource_code,AppResource_name) VALUES ('en','English'),('hi',N'??????'),('or',N'?????');


-- Table: Languages
DROP TABLE IF EXISTS Languages;
CREATE TABLE Languages (
    ID INT PRIMARY KEY IDENTITY(1,1),
    LanguageName	NVARCHAR(100) NOT NULL,
    LanguageName_en VARCHAR(100) NOT NULL
);
INSERT INTO Languages (LanguageName, LanguageName_en) VALUES  (N'English', 'English'), (N'?????', 'Odia'), (N'??????', 'Hindi');

-- Table: UserRole
DROP TABLE IF EXISTS UserRole;
CREATE TABLE UserRole (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL
);
INSERT INTO UserRole (RoleName) VALUES  (N'Composer'),(N'Singer'),(N'Music Director'),(N'Lyricist'); 
INSERT INTO UserRole (RoleName) VALUES  (N'Flautist'); 

-- Table: MusicType
DROP TABLE IF EXISTS MusicType; 
CREATE TABLE MusicType (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MusicTypeName NVARCHAR(100) NOT NULL,         -- e.g., Hindustani Classical Music, Carnatic, Odissi
    MusicTypeDesc NVARCHAR(200),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);

INSERT INTO MusicType (MusicTypeName, MusicTypeDesc) VALUES 
('Hindustani', 'North Indian classical music tradition'),
('Carnatic', 'South Indian classical music tradition'),
('Odissi', 'Odisha’s classical music tradition'),
('Bollywood', 'Hindi film song'),
('Ollywood', 'Odia film song'),
('Sargam Geet', 'Sargam Geet'),
('Bandish', 'Bandish');

-- Table: MusicalInstrument
CREATE TABLE MusicalInstrument (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MusicalInstrumentName NVARCHAR(100) NOT NULL,         -- e.g., Vocal, Flute, Sitar, Guitar, etc.
    MusicalInstrumentDesc NVARCHAR(200),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);
INSERT INTO MusicalInstrument (MusicalInstrumentName) VALUES ('Vocal'),('Flute'),('Sitar');

-- Table: Thaat
CREATE TABLE Thaat (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ThaatName NVARCHAR(100) NOT NULL,       
    ThaatDesc NVARCHAR(1000) NOT NULL,
    MusicTypeID INT NULL,
    FOREIGN KEY (MusicTypeID) REFERENCES MusicType(ID),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);
INSERT INTO Thaat (ThaatName, ThaatDesc, MusicTypeID) 
VALUES
('Bilawal', N'Considered the basic thaat, all shuddha (natural) notes.',1),
('Kalyan', N'Lydian mode; Tivra Ma.',1),
('Khamaj', N'Like Mixolydian mode; Komal Ni.',1),
('Kafi', N'Similar to Dorian mode; Komal Ga and Ni.',1),
('Marwa', N'Komal Re and Tivra Ma – creates tension.',1),
('Bhairav', N'Komal Re and Komal Dha with strong Bhakti (devotional) mood.',1),
('Asavari', N'Komal Ga, Dha, and Ni.',1),
('Bhairavi', N'Komal Re, Ga, Dha, Ni – very expressive and used widely.',1),
('Poorvi', N'Komal Re, Dha and Tivra Ma – serious and intense.',1),
('Todi', N'Komal Re, Ga, Dha and Tivra Ma – very emotional and deep.',1);

-- Table: Tala
CREATE TABLE Tala (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TalaName		NVARCHAR(100) NOT NULL,       
    TotalBits		INT,
    TalisAtBits		VARCHAR(10),
    KhalisAtBits	VARCHAR(10),
    Bol				NVARCHAR(200),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);
-- Tala
INSERT INTO Tala (TalaName, TotalBits, TalisAtBits, KhalisAtBits, Bol)
VALUES 
(N'Teen Taal', 16, N'1,5,13', N'9', N'DHA DHIN DHIN NA DHA DHIN DHIN NA TA TIN TIN NA TITA DHIN DHI NA'),
(N'Rupak', 7, N'4,6', N'1', N'DHI DHI NA DHI NA DHI NA');

INSERT INTO Tala (TalaName, TotalBits, TalisAtBits, KhalisAtBits, Bol)
VALUES 
(N'Keherwa', 8, N'1', N'5', N'DHA GE NA TI NA KA DHI NA'),
(N'Dadra', 6, N'1', N'4', N'DHA DHIN NA DHA TIN NA');


-- Table: Artist
CREATE TABLE Artist (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ArtistName NVARCHAR(200) NOT NULL,
    Biography NVARCHAR(200),
    Country VARCHAR(10) DEFAULT ('IN'),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);
-- Artist
INSERT Artist (ArtistName) VALUES (N'Roshan Lal Nagrath'), (N'Kishor Kumar'), (N'Mohd. Rafi');
INSERT Artist (ArtistName) VALUES (N'Hari Prasad Chaurasia');
INSERT Artist (ArtistName) VALUES (N'Ravindra Jain'),(N'Shankar-Jaikishan'),(N'Kalyanji-Anandji'),(N'SD Burman'),(N'Madan Mohan');
INSERT Artist (ArtistName) VALUES (N'KJ Yesudas'),(N'Hemlata'),(N'Asha Bhosle'),(N'Lata Mangeshkar'),(N'Hemant Kumar'),(N'Mukesh'),(N'Salmaga');

CREATE TABLE ArtistRoles (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ArtistID INT,
	RoleID INT,
	FOREIGN KEY (ArtistID) REFERENCES Artist(ID),
	FOREIGN KEY (RoleID) REFERENCES UserRole(ID)
);
-- ArtistRoles
INSERT ArtistRoles (ArtistID,RoleID) VALUES (1,1);
INSERT ArtistRoles (ArtistID,RoleID) VALUES (4,1); -- Hari Prasad Chaurasia composer
INSERT ArtistRoles (ArtistID,RoleID) VALUES (4,5); -- Hari Prasad Chaurasia flautist
INSERT ArtistRoles (ArtistID,RoleID) VALUES (5,3),(6,3),(7,3),(8,3),(9,3),(10,3); -- Music directors --<new
INSERT ArtistRoles (ArtistID,RoleID) VALUES (5,2); -- singer

-- Movie
 CREATE TABLE Movie(
	ID [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MovieName [nvarchar](100) NOT NULL,
	ReleaseDate [date] NULL,
	Casting [nvarchar](1000) NULL,
	DirectorID [int] NULL,
	MusicDirectorID [int] NULL,
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);
INSERT Movie (MovieName) VALUES (N'Raag Rang (1952)'), (N'Chitralekha (1964)');
INSERT Movie (MovieName) VALUES (N'Barsaat Ki Raat (1960)'), (N'Bahu Begum (1967)'), (N'Mamta (1966)'), (N'Saraswatichandra (1968)'), (N'Junglee (1961)'), (N'Mere Huzoor (1968)'), (N'Meri Surat Teri Ankhen (1963)'), (N'Mausam (1975)'), (N'Chitchor (1976)');

-- Table: Raaga
CREATE TABLE Raaga (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RaagaName VARCHAR(200) NOT NULL,
    RaagaTime VARCHAR(100),
    Mood VARCHAR(200),
    Aroh NVARCHAR(200),
    Avroh NVARCHAR(200),
    Pakad NVARCHAR(150), 
    Vadi NVARCHAR(2),
    Samvadi NVARCHAR(2), 
    Swara NVARCHAR(1500), 
    ThaatID INT,
	MusicTypeID INT,
    FOREIGN KEY (ThaatID) REFERENCES Thaat(ID),
	FOREIGN KEY (MusicTypeID) REFERENCES MusicType(ID),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);

INSERT INTO Raaga (RaagaName, ThaatID, RaagaTime, Mood, Aroh, Avroh, Vadi, Samvadi) VALUES 
('Yaman', 1, 'Evening', 'Romantic', 'N R G ? D N ?', '? N D P ? G R S', 'G', 'N'); -- Hindustani 

ALTER TABLE Raaga ADD RaagaDesc NVARCHAR(MAX) NULL;

ALTER TABLE Raaga ADD Jati NVARCHAR(100); --new
ALTER TABLE Raaga ADD NyasaSwara NVARCHAR(20); --new

ALTER TABLE Raaga ADD IsActive BIT DEFAULT(1);
ALTER TABLE Raaga ADD AddedBy INT DEFAULT(1);
ALTER TABLE Raaga ADD AddedDate DATETIME DEFAULT(GETDATE());
ALTER TABLE Raaga ADD ModifiedBy INT;
ALTER TABLE Raaga ADD ModifiedDate DATETIME;

-- Table: Composition 
CREATE TABLE Composition (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    Title VARCHAR(200) NOT NULL,
    Lyrics NVARCHAR(200),
    LanguageID INT,
    RagaID INT,
    TalaID INT,
    ComposerID INT,
	MovieID INT,
	MusicTypeID INT,
    FOREIGN KEY (LanguageID) REFERENCES Languages(ID),
    FOREIGN KEY (RagaID) REFERENCES Raaga(ID),
    FOREIGN KEY (TalaID) REFERENCES Tala(ID),
    FOREIGN KEY (ComposerID) REFERENCES Artist(ID),
	FOREIGN KEY (MovieID) REFERENCES Movie(ID),
	FOREIGN KEY (MusicTypeID) REFERENCES MusicType(ID),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);

ALTER TABLE Composition ADD IsActive BIT DEFAULT(1);
ALTER TABLE Composition ADD AddedBy INT DEFAULT(1);
ALTER TABLE Composition ADD AddedDate DATETIME DEFAULT(GETDATE());
ALTER TABLE Composition ADD ModifiedBy INT;
ALTER TABLE Composition ADD ModifiedDate DATETIME;

INSERT Composition (Title, RagaID, TalaID, ComposerID, MovieID, MusicTypeID, LanguageID) 
VALUES (N'Eri aali piya bina', 1, 1, 1, 1, 7, 2);

--CompositionAlap
CREATE TABLE CompositionAlap (
    ID INT PRIMARY KEY IDENTITY(1,1),
    LineNumber INT,
    Notations NVARCHAR(500),
    CompositionID INT,
    FOREIGN KEY (CompositionID) REFERENCES Composition(ID),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);

--CompositionNotations
CREATE TABLE CompositionNotations (
    ID INT PRIMARY KEY IDENTITY(1,1),
    LineType VARCHAR(2), -- ST-> STHAYI, AN-> ANTARA - > AL -> ALAP, GA-> GAMAK, TA-> TAAN
    LineNumber INT,
    BitNumber INT,
    Notations NVARCHAR(10),
    CompositionID INT,
    FOREIGN KEY (CompositionID) REFERENCES Composition(ID),
	AppResourceID INT DEFAULT(1),
	FOREIGN KEY (AppResourceID) REFERENCES AppResource(ID)
);

-- Table: Performance
CREATE TABLE Performance (
    ID INT PRIMARY KEY IDENTITY(1,1),
    PerformanceDate DATE,
    Venue VARCHAR(200),
    ArtistID INT,
    CompositionID INT,
	MusicalInstrumentID INT,
    Notes NVARCHAR(2000),
    FOREIGN KEY (CompositionID) REFERENCES Composition(ID),
    FOREIGN KEY (ArtistID) REFERENCES Artist(ID),
    FOREIGN KEY (MusicalInstrumentID) REFERENCES MusicalInstrument(ID),
);

-- Table: Recording
CREATE TABLE Recording (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FilePath VARCHAR(500),
    RecordingFormat VARCHAR(50),
    Duration INT, -- in seconds
    PerformanceID INT,
    FOREIGN KEY (PerformanceID) REFERENCES Performance(ID)
);

-- Table: User
CREATE TABLE AppUser (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(200) NOT NULL,
    Email VARCHAR(200) UNIQUE NOT NULL,
    SubscriptionType VARCHAR(50),
    JoinDate DATE,
    RoleID INT,
    FOREIGN KEY (RoleID) REFERENCES UserRole(ID)
);


-- Table: User
CREATE TABLE AppImages (
    ID INT PRIMARY KEY IDENTITY(1,1),
	Image_For VARCHAR(100) NULL, --TABLE
	Image_For_Id INT,
    ImageUrl VARCHAR(500) NULL,
    ImageUrl_mid VARCHAR(500) NULL,
	ImageUrl_small VARCHAR(500) NULL
);

INSERT INTO AppImages (Image_For,Image_For_Id, ImageUrl) VALUES
('Artist',1,'Music_Director_Roshan.jpg'),
('Artist',4,'Hariprasad_Chaurasia_1.jpg');


CREATE TABLE AppDocuments (
    ID INT PRIMARY KEY IDENTITY(1,1),
	Document_For VARCHAR(100) NULL, --TABLE
	Document_For_Id INT,
    DocumentUrl VARCHAR(1500) NULL 
);