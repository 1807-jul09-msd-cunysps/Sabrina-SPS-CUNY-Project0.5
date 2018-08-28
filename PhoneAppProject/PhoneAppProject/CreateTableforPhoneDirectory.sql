DROP TABLE IF EXISTS AddressBook;
DROP TABLE IF EXISTS Phone;
DROP TABLE IF EXISTS Directory;
DROP TABLE IF EXISTS ContactMe;


CREATE TABLE Directory
	([PersonID] BIGINT PRIMARY KEY,
	 [firstName] varchar(20),
	 [lastName] varchar(20),
	 );

CREATE TABLE Phone
	([CountryCode] varchar(5),
	 [AreaCode] varchar(5),
	 [Number] varchar(16),
	 Person_ID BIGINT FOREIGN KEY REFERENCES Directory(PersonID)
	 )

CREATE TABLE AddressBook
	([houseNo] varchar(10),
	 [street] varchar(60),
	 [city] varchar(20),
	 [state] varchar(25),
	 [country] varchar(80),
	 [zipcode] varchar(10),
	 Person_ID BIGINT FOREIGN KEY REFERENCES Directory(PersonID)
	 );

CREATE TABLE ContactMe
	 ([firstName] varchar(20),
	  [lastName] varchar(20),
	  [email] varchar(30),
	  [message] varchar(30)
	  )


	 SELECT * FROM Directory;
	 SELECT * FROM AddressBook;
	 SELECT * FROM Phone;
	 SELECT * FROM ContactMe;

	 SELECT * FROM Directory
	 WHERE firstName = 'Tashny' AND lastName = 'Hopkins'

	 INSERT INTO ContactMe Values('Kid', 'Fury', 'kid.fury@gmail.com', 'The Read Podcast is hilarious')