/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Contact VALUES ('Chuck', 'Norris', 'chuck@god.com', '0123654789'),
                           ('Termin', 'Ator', 'terminator@skynet.com', '+32495/123654'),
                           ('Bilbo', 'Le Hobbit', 'bilbo@middle-earth.com', 'N/A')

INSERT INTO Utilisateur VALUES ('MonUser', 'MonUserLogin')