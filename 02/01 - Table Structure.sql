CREATE TABLE db.person (
	ID INT auto_increment NOT NULL,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	ReportsTo VARCHAR(200) DEFAULT NULL,
	`Position` VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	CONSTRAINT person_PK PRIMARY KEY (ID)
);

INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Daniel'   , 'Smith'   , 'Bob Boss'      , 'Engineer'  ,  25);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Mike'     , 'White'   , 'Bob Boss'      , 'Contractor',  22);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Jenny'    , 'Richards',  null           , 'CEO'       ,  45);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Robert'   , 'Black'   , 'Daniel Smith'  , 'Sales'     ,  22);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Noah'     , 'Fritz'   , 'Jenny Richards', 'Assistant' ,  30);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('David'    , 'S'       , 'Jenny Richards', 'Director'  ,  32);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Ashley'   , 'Wells'   , 'Davidi S'      , 'Assistant' ,  25);
INSERT INTO db.person (FirstName,	LastName,	ReportsTo,	`Position`,	Age) VALUES('Ashley'   , 'Johnson' , null            , 'Intern'    ,  25);