USE comete;

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

CREATE TABLE Tags (
    id BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE Folder_tags (
    folder_id BIGINT NOT NULL,
    tag_id BIGINT NOT NULL,
    PRIMARY KEY (folder_id, tag_id),
    FOREIGN KEY (folder_id) REFERENCES Folders(id) ON DELETE CASCADE,
    FOREIGN KEY (tag_id) REFERENCES Tags(id) ON DELETE CASCADE
);

-- Insertion d'un utilisateur
INSERT INTO Utilisateurs (email, password)
VALUES ('comete@esgi.fr', 'comete');

-- Insertion d'un folder
INSERT INTO Folders (name, utilisateur_id)
VALUES ('dossier_1', 1);
