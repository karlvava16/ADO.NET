CREATE DATABASE MyFruitsAndVegetables
go




use MyFruitsAndVegetables
CREATE TABLE FruitsAndVegetables (
    NameOfObject NVARCHAR(50),
    TypeOfObject NVARCHAR(10),
    Color NVARCHAR(20),
    CalorieСontent INT
);
go
INSERT INTO FruitsAndVegetables (NameOfObject, TypeOfObject, Color, CalorieСontent) VALUES 
    ('Apple', 'fruit', 'red', 52),
    ('Banana', 'fruit', 'yellow', 89),
    ('Orange', 'fruit', 'orange', 47),
    ('Tangerine', 'fruit', 'orange', 38),
    ('Watermelon', 'fruit', 'green', 30),
    ('Pineapple', 'fruit', 'yellow', 50),
    ('Lemon', 'fruit', 'yellow', 29),
    ('Peach', 'fruit', 'orange', 39),
    ('Pear', 'fruit', 'green', 57),
    ('Cherry', 'fruit', 'red', 50),
    ('Plum', 'fruit', 'purple', 46),
    ('Kiwi', 'fruit', 'green', 61),
    ('Carrot', 'vegetable', 'orange', 41),
    ('Potato', 'vegetable', 'brown', 77),
    ('Cucumber', 'vegetable', 'green', 16),
    ('Tomato', 'vegetable', 'red', 18),
    ('Beetroot', 'vegetable', 'red', 43),
    ('Cabbage', 'vegetable', 'green', 25),
    ('Onion', 'vegetable', 'white', 40),
    ('Garlic', 'vegetable', 'white', 149),
    ('Pepper', 'vegetable', 'red', 31),
    ('Eggplant', 'vegetable', 'purple', 24),
    ('Spinach', 'vegetable', 'green', 23),
    ('Zucchini', 'vegetable', 'green', 17),
    ('Artichoke', 'vegetable', 'green', 47),
    ('Persimmon', 'fruit', 'orange', 81),
    ('Avocado', 'fruit', 'green', 160),
    ('Pomegranate', 'fruit', 'red', 83),
    ('Passionfruit', 'fruit', 'yellow', 68),
    ('Mango', 'fruit', 'orange', 60),
    ('Grapefruit', 'fruit', 'pink', 42),
    ('Lime', 'fruit', 'green', 30),
    ('Feijoa', 'fruit', 'green', 55),
    ('Papaya', 'fruit', 'orange', 43),
    ('Lychee', 'fruit', 'red', 66),
    ('Date', 'fruit', 'brown', 282),
    ('Clementine', 'fruit', 'orange', 47),
    ('Corn', 'vegetable', 'yellow', 86),
    ('Radish', 'vegetable', 'red', 16),
    ('Turnip', 'vegetable', 'red', 20),
    ('Lettuce', 'vegetable', 'green', 15),
    ('Beans', 'vegetable', 'green', 345),
    ('Peas', 'vegetable', 'green', 81),
    ('Pumpkin', 'vegetable', 'orange', 26),
    ('Zucchini squash', 'vegetable', 'green', 17),
    ('Red currant', 'fruit', 'red', 44),
    ('Cherry', 'fruit', 'red', 50),
    ('Black currant', 'fruit', 'black', 63);
