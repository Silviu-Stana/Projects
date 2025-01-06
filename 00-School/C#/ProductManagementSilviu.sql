SELECT * FROM [User];
SELECT * FROM Product;
SELECT * FROM Picture;
SELECT * FROM Category;
SELECT * FROM ProductEvaluation;
SELECT * FROM ProductCategory;

CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
	IsAdmin BIT NOT NULL DEFAULT 0
);

CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(255) NOT NULL,
);


CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    FabricationDate DATE NOT NULL,
);


CREATE TABLE Picture (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Filename VARCHAR(255) NOT NULL,
    AdId INT NOT NULL,
    CONSTRAINT FK_Ad_Picture FOREIGN KEY (AdId) REFERENCES Product(Id) ON DELETE CASCADE
);



--MANY TO MANY TABLES
CREATE TABLE ProductEvaluation (
    ProductId INT NOT NULL,
    UserId INT NOT NULL,
    Value INT NOT NULL CHECK (Value BETWEEN 1 AND 5),
    PRIMARY KEY (ProductId, UserId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (UserId) REFERENCES [User](Id)
);

CREATE TABLE ProductCategory (
    ProductId INT,
    CategoryId INT,
    PRIMARY KEY (ProductId, CategoryId),
    FOREIGN KEY (ProductId) REFERENCES Product(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
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

INSERT INTO Product (Title, Description, Price, FabricationDate)
VALUES 
('Apples', 'Fresh and crispy red apples.', 2.99, '2024-12-20'),
('Bananas', 'Organic ripe bananas.', 1.99, '2024-12-18'),
('Carrots', 'Crunchy orange carrots.', 1.49, '2024-12-15'),
('Broccoli', 'Fresh green broccoli.', 2.39, '2024-12-16'),
('Chicken Breast', 'Boneless and skinless.', 6.99, '2024-12-17'),
('Ground Beef', 'Lean ground beef, 85% lean.', 5.49, '2024-12-18'),
('Milk', '2% reduced-fat milk.', 3.29, '2024-12-19'),
('Cheddar Cheese', 'Sharp cheddar cheese.', 4.79, '2024-12-20'),
('Rice', 'Long-grain white rice, 2 lbs.', 2.89, '2024-12-14'),
('Whole Wheat Bread', 'Freshly baked whole wheat bread.', 2.49, '2024-12-20'),
('Eggs', 'A dozen large eggs.', 3.99, '2024-12-18'),
('Orange Juice', '100% pure orange juice, 1 liter.', 3.29, '2024-12-19'),
('Peanut Butter', 'Creamy peanut butter, 16 oz.', 3.79, '2024-12-10'),
('Spaghetti', 'Classic spaghetti pasta, 16 oz.', 1.99, '2024-12-12'),
('Tomato Sauce', 'Rich tomato sauce for pasta.', 2.49, '2024-12-14'),
('Potatoes', '5 lb bag of russet potatoes.', 4.99, '2024-12-16'),
('Cucumber', 'Fresh green cucumber.', 1.29, '2024-12-13'),
('Lettuce', 'Crisp romaine lettuce.', 1.79, '2024-12-14'),
('Tomatoes', 'Vine-ripened tomatoes.', 2.59, '2024-12-15'),
('Grapes', 'Sweet red grapes, 1 lb.', 3.99, '2024-12-16'),
('Yogurt', 'Plain Greek yogurt, 500g.', 2.89, '2024-12-17'),
('Olive Oil', 'Extra virgin olive oil, 500ml.', 5.49, '2024-12-18'),
('Cereal', 'Whole grain breakfast cereal.', 3.59, '2024-12-19'),
('Frozen Peas', 'Frozen peas, 1 lb.', 2.19, '2024-12-20'),
('Ice Cream', 'Vanilla ice cream, 1.5 qt.', 4.99, '2024-12-15'),
('Butter', 'Unsalted butter, 1 lb.', 3.29, '2024-12-16'),
('Bacon', 'Crispy bacon strips, 12 oz.', 4.39, '2024-12-17'),
('Sausage', 'Pork sausage links, 16 oz.', 3.79, '2024-12-18'),
('Honey', 'Pure honey, 16 oz.', 5.29, '2024-12-19');

INSERT INTO Category (CategoryName)
VALUES 
('Fruits'),
('Vegetables'),
('Meat'),
('Dairy'),
('Grains'),
('Bakery'),
('Beverages'),
('Pantry'),
('Grains'),
('Bio');



INSERT INTO ProductCategory(ProductId, CategoryId)
VALUES
(1, 1),  -- Apples -> Fruits
(2, 1),  -- Bananas -> Fruits
(3, 2),  -- Carrots -> Vegetables
(4, 2),  -- Broccoli -> Vegetables
(5, 3),  -- Chicken Breast -> Meat
(6, 3),  -- Ground Beef -> Meat
(7, 4),  -- Milk -> Dairy
(8, 4),  -- Cheddar Cheese -> Dairy
(9, 5),  -- Rice -> Grains
(10, 6), -- Whole Wheat Bread -> Bakery
(11, 4), -- Eggs -> Dairy
(12, 7), -- Orange Juice -> Beverages
(13, 8), -- Peanut Butter -> Pantry
(14, 5), -- Spaghetti -> Grains
(15, 8), -- Tomato Sauce -> Pantry
(16, 2), -- Potatoes -> Vegetables
(17, 2), -- Cucumber -> Vegetables
(18, 2), -- Lettuce -> Vegetables
(19, 2), -- Tomatoes -> Vegetables
(20, 1), -- Grapes -> Fruits
(21, 4), -- Yogurt -> Dairy
(22, 8), -- Olive Oil -> Pantry
(23, 5), -- Cereal -> Grains
(24, 2), -- Frozen Peas -> Vegetables
(25, 7), -- Ice Cream -> Beverages
(26, 4), -- Butter -> Dairy
(27, 3), -- Bacon -> Meat
(28, 3), -- Sausage -> Meat
(29, 8); -- Honey -> Pantry


--CATEGORIE SECUNDARA (un produs poate avea mai multe categorii)
INSERT INTO ProductCategory(ProductId, CategoryId)
VALUES
(1, 10),  -- Apples -> Bio
(2, 10),  -- Bananas -> Bio
(7, 10),  -- Milk -> Bio
(11, 10), -- Eggs -> Bio
(16, 10), -- Potatoes -> Bio
(19, 10); -- Tomatoes -> Bio

--INSERT BRANDS
UPDATE Product
SET Brand = CASE 
    WHEN Title = 'Apples' THEN 'GreenLeaf'
    WHEN Title = 'Bananas' THEN 'SunnyGro'
    WHEN Title = 'Carrots' THEN 'RootBurst'
    WHEN Title = 'Broccoli' THEN 'GreenHarvest'
    WHEN Title = 'Chicken Breast' THEN 'FarmFresh'
    WHEN Title = 'Ground Beef' THEN 'PrimeCuts'
    WHEN Title = 'Milk' THEN 'DairyDelight'
    WHEN Title = 'Cheddar Cheese' THEN 'SharpEdge'
    WHEN Title = 'Rice' THEN 'GrainMasters'
    WHEN Title = 'Whole Wheat Bread' THEN 'GoldenGrain'
    WHEN Title = 'Eggs' THEN 'Eggcellence'
    WHEN Title = 'Orange Juice' THEN 'FarmFresh'
    WHEN Title = 'Peanut Butter' THEN 'PastaPro'
    WHEN Title = 'Spaghetti' THEN 'TomatoRich'
    WHEN Title = 'Tomato Sauce' THEN 'SpudFarm'
    WHEN Title = 'Potatoes' THEN 'CoolCuc'
    WHEN Title = 'Cucumber' THEN 'LeafyGreens'
    WHEN Title = 'Lettuce' THEN 'VineHarvest'
    WHEN Title = 'Tomatoes' THEN 'GrapeGrove'
    WHEN Title = 'Grapes' THEN 'YogurtKing'
    WHEN Title = 'Yogurt' THEN 'OlivaPure'
    WHEN Title = 'Olive Oil' THEN 'CerealCraft'
    WHEN Title = 'Cereal' THEN 'FrozenPeak'
    WHEN Title = 'Frozen Peas' THEN 'ButterMeister'
    WHEN Title = 'Ice Cream' THEN 'CrispBacon'
    WHEN Title = 'Butter' THEN 'SausageMasters'
    WHEN Title = 'Bacon' THEN 'HoneyPure'
    WHEN Title = 'Sausage' THEN 'RootBurst'
    WHEN Title = 'Honey' THEN 'FarmFresh'
END;