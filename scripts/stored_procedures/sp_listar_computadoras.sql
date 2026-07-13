DELIMITER //

CREATE PROCEDURE sp_listar_computadoras ()
BEGIN
    SELECT 
        c.idPC, c.codigoInventario, c.numero_serie, c.sistemaOperativo, c.tipoPC, c.max_temperatura_tolerada,
        l.id_laboratorio, l.nombre AS lab_nombre, l.ubicacion AS lab_ubicacion,
        m.idModelo, m.marca, m.modelo, m.especs, m.ram
    FROM Computadoras c
    INNER JOIN Laboratorio l ON c.id_laboratorio = l.id_laboratorio
    INNER JOIN ModelosPC m ON c.idModelo = m.idModelo;
END //

DELIMITER ;
