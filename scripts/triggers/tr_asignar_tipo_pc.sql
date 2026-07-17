DELIMITER $$

CREATE TRIGGER tr_asignar_tipo_pc
BEFORE INSERT ON Computadoras
FOR EACH ROW
BEGIN
    IF NEW.sistemaOperativo LIKE '%Server%' THEN
        SET NEW.tipoPC = 'Servidor';
    ELSE
        SET NEW.tipoPC = 'Escritorio';
    END IF;
END$$

DELIMITER ;