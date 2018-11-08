CREATE TABLE IF NOT EXISTS role (
   role_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(30) NOT NULL,
  PRIMARY KEY (role_id))
  ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO role (name) VALUES ('Administrador');
INSERT INTO role (name) VALUES ('Vendedor');
INSERT INTO role (name) VALUES ('Almacenero');
