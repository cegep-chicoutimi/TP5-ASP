DROP TABLE IF EXISTS tp5_MenuChoices;
CREATE TABLE tp5_MenuChoices
(
  Id integer AUTO_INCREMENT PRIMARY KEY,
  Description nvarchar(30)
);

/*INSERT INTO tp5_MenuChoices(Description)
VALUES 
 ("Fajitas au poulet"),
 ("Filet mignon 8 oz"),
 ("Lasagne");
*/

DROP TABLE IF EXISTS tp5_Reservations;
CREATE TABLE tp5_Reservations
(
  Id integer AUTO_INCREMENT PRIMARY KEY,
  Nom nvarchar(20),
  Courriel nvarchar(50),
  NbPersonne integer,
  DateReservation datetime,
  MenuChoiceId integer
);
