CREATE TABLE IF NOT EXISTS store (
   store_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  name VARCHAR(50) NULL,
  status INT NULL,
  PRIMARY KEY (store_id))
  ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

 INSERT INTO store (name,status) VALUES ('Los Postes SJL',1);
INSERT INTO store (name,status) VALUES ('Venezuela UNMSM',1);
INSERT INTO store (name,status) VALUES ('Plaza San Martin',1);