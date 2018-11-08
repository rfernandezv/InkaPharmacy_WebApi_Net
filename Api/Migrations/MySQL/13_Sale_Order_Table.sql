CREATE TABLE IF NOT EXISTS sale_order (
  sale_order_id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  sale_date DATETIME(6) NOT NULL,
  customer_id BIGINT UNSIGNED NOT NULL,
  employee_id BIGINT UNSIGNED NOT NULL,
  status INT NULL,
  PRIMARY KEY (sale_order_id),
  CONSTRAINT FK__sale__employee_id__15502E78
    FOREIGN KEY (employee_id)
    REFERENCES employee (employee_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT FK__sale__customer_id__145C0A3F
    FOREIGN KEY (customer_id)
    REFERENCES customer (customer_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
	ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;