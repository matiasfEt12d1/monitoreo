DELIMITER //

CREATE PROCEDURE sp_registrar_medicion (
    IN p_idPC INT,
    IN p_macAddress VARCHAR(45),
    IN p_temperaturaCPU DECIMAL(5,2),
    IN p_usoRAM DECIMAL(5,2)
)
BEGIN
    INSERT INTO Mediciones (idPC, macAddress, fechaIngreso, temperaturaCPU, usoRAM, estado)
    VALUES (p_idPC, p_macAddress, NOW(), p_temperaturaCPU, p_usoRAM, 'Operativo');

    SELECT LAST_INSERT_ID() AS idMedicion;
END //

DELIMITER ;
