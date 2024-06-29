-- Table Utilisateur
CREATE TABLE Utilisateurs (
    id BIGINT NOT NULL AUTO_INCREMENT,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

-- Table Folder
CREATE TABLE Folders (
    id BIGINT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    utilisateur_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (utilisateur_id) REFERENCES Utilisateurs(id)
);

-- Table Report
CREATE TABLE Reports (
    id BIGINT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    folder_id BIGINT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (folder_id) REFERENCES Folders(id)
);

-- Insertion d'un utilisateur
INSERT INTO Utilisateurs (email, password)
VALUES ('comete@esgi.fr', 'comete');

-- Insertion d'un folder
INSERT INTO Folders (name, utilisateur_id)
VALUES ('dossier_1', 1);
