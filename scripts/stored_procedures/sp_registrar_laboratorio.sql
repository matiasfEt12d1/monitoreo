DELIMITER //

CREATE PROCEDURE sp_registrar_laboratorio (
    IN p_nombre VARCHAR(100),
    IN p_ubicacion VARCHAR(250)
)
BEGIN
    INSERT INTO Laboratorio (nombre, ubicacion)
    VALUES (p_nombre, p_ubicacion);
    
    -- Retorna el ID generado para mapearlo al objeto en C#
    SELECT LAST_INSERT_ID() AS id_laboratorio;
END //

DELIMITER ;
