SELECT * FROM [User]
SELECT * FROM Ad
SELECT * FROM Picture

ALTER TABLE Ad
ADD Phone VARCHAR(15);

CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE Ad (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    Category VARCHAR(100),
    UserId INT NOT NULL,
    CONSTRAINT FK_User_Ad FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE
);

--Random phone numbers
UPDATE Ad
SET Phone = CONCAT('07', RIGHT(CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR(10)), 8))
WHERE Phone IS NULL;

CREATE TABLE Picture (
    Id INT PRIMARY KEY IDENTITY(1,1),
--  Filepath VARCHAR(500) NOT NULL,
    Filename VARCHAR(255) NOT NULL,
    AdId INT NOT NULL,
    CONSTRAINT FK_Ad_Picture FOREIGN KEY (AdId) REFERENCES Ad(Id) ON DELETE CASCADE
);



INSERT INTO [User] (Username, Password)
VALUES 
    ('alice', 'password1'),
    ('bob', 'password2'),
    ('carol', 'password3'),
    ('dave', 'password4'),
    ('eve', 'password5'),
    ('frank', 'password6'),
    ('grace', 'password7'),
    ('hank', 'password8'),
    ('iris', 'password9'),
    ('jack', 'password10');


	INSERT INTO Ad (Title, Description, Price, Category, UserId)
VALUES 
    ('Laptop for Sale', 'A used laptop in good condition.', 300.00, 'Electronics', 1),
    ('Smartphone for Sale', 'Latest model smartphone at a great price.', 150.00, 'Electronics', 1),
    ('Old Sofa', 'Comfy old sofa, needs some cleaning.', 50.00, 'Furniture', 1),
    ('Mountain Bike', 'A well-maintained mountain bike.', 200.00, 'Sports', 2),
    ('Electric Guitar', 'Electric guitar with amp.', 250.00, 'Musical Instruments', 2),
    ('Dining Table', 'Wooden dining table, 6-seater.', 120.00, 'Furniture', 2),
    ('Used TV', 'Flat-screen TV, works perfectly.', 180.00, 'Electronics', 3),
    ('Washing Machine', 'Semi-automatic washing machine, works well.', 100.00, 'Home Appliances', 3),
    ('Gaming Console', 'Latest gaming console with accessories.', 400.00, 'Electronics', 4),
    ('Desk Lamp', 'Adjustable desk lamp, very bright.', 25.00, 'Furniture', 4),
    ('Coffee Maker', 'Brew your coffee in minutes with this maker.', 40.00, 'Home Appliances', 4),
    ('Bluetooth Speaker', 'Portable bluetooth speaker with great sound.', 60.00, 'Electronics', 5),
    ('Microwave Oven', 'Used microwave oven, good condition.', 80.00, 'Home Appliances', 5),
    ('Leather Jacket', 'Stylish leather jacket, size M.', 150.00, 'Clothing', 6),
    ('Winter Boots', 'Warm and comfortable boots, size 8.', 45.00, 'Clothing', 6),
    ('Second-hand Bicycle', 'A second-hand bicycle, in decent shape.', 100.00, 'Sports', 7),
    ('Used Books Collection', 'A lot of used books in great condition.', 30.00, 'Books', 7),
    ('Refrigerator', 'Large refrigerator, works perfectly.', 350.00, 'Home Appliances', 8),
    ('Table Fan', 'Portable table fan, great for summer.', 20.00, 'Home Appliances', 9),
    ('Air Conditioner', 'Split AC, used but in good condition.', 500.00, 'Home Appliances', 10);


INSERT INTO Picture (Filename, AdId)
VALUES
    ('laptop1.jpg', 1),
    ('laptop2.jpg', 1),
    ('smartphone1.jpg', 2),
    ('sofa1.jpg', 3),
    ('bike1.jpg', 4),
    ('guitar1.jpg', 5),
    ('table1.jpg', 6),
    ('tv1.jpg', 7),
    ('washing_machine1.jpg', 8),
    ('gaming_console1.jpg', 9),
    ('desk_lamp1.jpg', 10);


	INSERT INTO Ad (Title, Description, Price, Category, UserId)
VALUES 
    ('Cute Baby Seal Plush Toy', 'Snuggle up with this ultra-soft baby seal plush, perfect for animal lovers and collectors!', 25.00, 'Seal', 13),
    ('Cute Seal: Make a Difference Today', 'Support wildlife conservation by adopting a seal! Your donation helps protect these magnificent creatures in the wild.', 50.00, 'Seal', 13),
    ('A Seal', 'he is silly but cute: he looks kinda tired!', 150.00, 'Seal', 13);

INSERT INTO Picture (Filename, AdId)
VALUES
    ('laptop1.jpg', 1),
    ('laptop2.jpg', 1),
    ('smartphone1.jpg', 2),
    ('sofa1.jpg', 3),
    ('bike1.jpg', 4),
    ('guitar1.jpg', 5),
    ('table1.jpg', 6),
    ('tv1.jpg', 7),
    ('washing_machine1.jpg', 8),
    ('gaming_console1.jpg', 9),
    ('desk_lamp1.jpg', 10);


	UPDATE Ad
SET Category = REPLACE(Category,' ','');



UPDATE Ad
SET Title = 'Cute Baby Seal'
WHERE Id =21;

UPDATE Ad
SET Title = 'Seal Seal Seal, We have a Seal'
WHERE Id =22;

UPDATE Ad
SET Description = 'AMAZING! WE HAVE A CUTE BABY SEAL!!!! WOW!'
WHERE Id =21;

UPDATE Ad
SET Description = 'Hold up?! We have a very interesting seal over here!'
WHERE Id =22;

UPDATE Ad
SET Description = 'New Title Here'
WHERE Id =23;