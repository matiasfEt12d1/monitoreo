DELIMITER $$

CREATE TRIGGER tr_prevenir_modelo_duplicado
BEFORE INSERT ON ModelosPC
FOR EACH ROW
BEGIN
    DECLARE existe_modelo INT;
    
    SELECT COUNT(*) INTO existe_modelo 
    FROM ModelosPC 
    WHERE LOWER(marca) = LOWER(NEW.marca) AND LOWER(modelo) = LOWER(NEW.modelo);
    
    IF existe_modelo > 0 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Error: Ya existe un registro con esta misma marca y modelo.';
    ELSE
        SET NEW.marca = UPPER(NEW.marca);
    END IF;
END$$

DELIMITER ;