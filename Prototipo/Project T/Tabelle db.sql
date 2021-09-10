CREATE TABLE utenti_registrati(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
  nome varchar(20) NOT NULL,
  cognome varchar(20) NOT NULL,
  email varchar(30) NOT NULL,
  nascita DATE NOT NULL -- RICORDA CHE LA DATA È YYYY-MM-DD
 );

CREATE TABLE tata(
  id int AUTO_INCREMENT NOT NULL PRIMARY KEY,
  nome varchar(20) NOT NULL,
  cognome varchar(20) NOT NULL,
  email varchar(50) NOT NULL,
  psw varchar(50) NOT NULL ,
  zona_operativa varchar(40) not null,
  occupata bool not null,
  image_path mediumblob(255) NOT NULL
  );