
Ce dossier (ESB_BDD / MPD) contient les fichiers SQL permettant de générer la BDD ESBookshop. 

----------------------------------------
EXECTION DES FICHIERS
MICROSOFT SQL SERVER MANAGEMENT STUDIO
----------------------------------------
Une variante pexécuter les fichiers sous Microsoft SQL Server Management Studio est de faire un glisser-coller du fichier. 


----------------------------------------
GENERATION DE LA BASE DE DONNEES 
----------------------------------------

Les scripts pour la génération de la BDD sont les fichiers 
1) Le fichier "ESB_MPD_Create_IfDBDoesnotExist.sql"
Il est à exécuter lors de la 1ière exécution (génération). 

2) Le fichier "ESB_MPD_Create_IfDBAlreadyExist.sql"
Il est à exécuter si la base de données est déjà générée mais contient des erreurs, des données erronées, par exemple. 

----------------------------------------
INSERTION DES DONNEES 
----------------------------------------
Les scripts d'Insertions sont les fichiers suivants. 

a) Fichers à exécuter impérativement en premier. 
Les fichiers permettant d'insérer les données des tables ne contenant pas de clés étrangères. 
- ESB_MPD_Insert_1Authors.sql 
- ESB_MPD_Insert_1Customers.sql 
- ESB_MPD_Insert_1Editors.sql 
- ESB_MPD_Insert_1GenresLanguagesFormatsCategories.sql 

b) Fichers à exécuter impérativement en SECONDE POSITION. 
Les fichiers contenant des tables contenant des clés étrangères mais n'étant pas référencées dans d'autres tables 
- ESB_MPD_Insert_2Accounts.sql
- ESB_MPD_Insert_2Books.sql

c) Les fichiers à exécuter après les deux niveaux précédemment sont les fichiers
- ESB_MPD_Insert_3Cowriters.sql
- ESB_MPD_Insert_3Orders.sql
- ESB_MPD_Insert_3Payments.sql
- ESB_MPD_Insert_3Ranks.sql
- ESB_MPD_Insert_3Shoppingcarts.sql
- ESB_MPD_Insert_3Stocks.sql

d) Le quatrième niveau comprend le fichiers "ESB_MPD_Insert_4Lineitems.sql". 
Il doit être exécuté après les trois étapes d'insertin précédentes. 

e) La dernière étape concerne le fichier qui contient la table contenant les références sur la table LineItems (LignesDeCommandes). 
Le fichier porte le nom "ESB_MPD_Insert_5Appreciations.sql". Il doit être exécuté en dernier. 
