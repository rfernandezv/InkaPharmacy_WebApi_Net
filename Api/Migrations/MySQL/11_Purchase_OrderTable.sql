CREATE TABLE  IF NOT EXISTS purchase_order (
  purchase_order_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  purchase_date DATETIME NOT NULL,
  provider_id BIGINT UNSIGNED NOT NULL,
  employee_id BIGINT UNSIGNED NOT NULL,
  PRIMARY KEY (purchase_order_id),
  CONSTRAINT FK__compra__cod_emp__300424B4
    FOREIGN KEY (employee_id)
    REFERENCES employee (employee_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__compra__cod_prov__2F10007B
    FOREIGN KEY (provider_id)
    REFERENCES provider (provider_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
	ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;