CREATE TABLE accounts (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE recipes (
  id INT NOT NULL,
  creatorId VARCHAR (255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  spicy BOOLEAN NOT NULL DEFAULT 0,
  picture VARCHAR(255) ,
  PRIMARY KEY (id),
    FOREIGN KEY (creatorId)
    REFERENCES accounts (id)
    ON DELETE CASCADE
);

CREATE TABLE ingredients (
  id INT NOT NULL,
  recipeId INT NOT NULL,
  name VARCHAR(255) NOT NULL,
  foodGroup VARCHAR(255) NOT NULL,
  picture VARCHAR(255) ,
  PRIMARY KEY (id),
    FOREIGN KEY (recipeId)
    REFERENCES recipes (id)
    ON DELETE CASCADE
)