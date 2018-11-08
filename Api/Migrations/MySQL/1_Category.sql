CREATE TABLE IF NOT EXISTS category (
category_id  BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
 name VARCHAR(30) NULL,
PRIMARY KEY (category_id))
ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO category (name) VALUES ('Analgesicos');
INSERT INTO category (name) VALUES ('Antibioticos');
INSERT INTO category (name) VALUES ('Antimicoticos');
INSERT INTO category (name) VALUES ('Antihistaminicos');
INSERT INTO category (name) VALUES ('Vitaminas');
INSERT INTO category (name) VALUES ('Hormonas');
INSERT INTO category (name) VALUES ('Diureticos');
INSERT INTO category (name) VALUES ('Anti inflamatorios');
INSERT INTO category (name) VALUES ('Oncologico');
INSERT INTO category (name) VALUES ('Ginecologico');
INSERT INTO category (name) VALUES ('Neumologico');
INSERT INTO category (name) VALUES ('Gastrointestinal');
  
