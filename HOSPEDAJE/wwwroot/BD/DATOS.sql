-- *******************************************
-- 4. Tabla de Habitaciones
-- *******************************************
INSERT INTO tbl_estado(nombre, descripcion) VALUES 
    ('Disponible', 'La habitaci�n est� disponible para ser reservada.'),
    ('Ocupada', 'La habitaci�n est� ocupada por un cliente.'),
    ('Mantenimiento', 'La habitaci�n est� en mantenimiento.'),
    ('Limpieza', 'La habitaci�n est� siendo limpiada.');

INSERT INTO tbl_categoria (nombre_categoria, descripcion) VALUES 
    ('Econ�mica', 'Habitaci�n econ�mica con lo b�sico para una estancia c�moda.'),
    ('Est�ndar', 'Habitaci�n est�ndar con servicios adicionales para mayor confort.'),
    ('Suite', 'Suite de lujo con m�ltiples servicios y una experiencia premium.'),
    ('Presidencial', 'Habiraci�n de alta gama para hu�spedes VIP con todos los lujos.');

INSERT INTO tbl_habitacion (id_categoria, id_estado, numero, precio, descripcion) VALUES 
    (1, 1, '101', 50.00, 'Habitaci�n econ�mica con una cama individual y ba�o privado.'),
    (2, 1, '102', 75.00, 'Habitaci�n est�ndar con cama matrimonial y ba�o privado.'),
    (3, 2, '201', 150.00, 'Suite de lujo con cama king size y vista al mar.'),
    (4, 3, '301', 300.00, 'Habitaci�n presidencial con jacuzzi, cama king size y todos los servicios.');

    INSERT INTO tbl_detalle_habitacion (id_habitacion, tamanio_habitacion, tipo_cama, numero_camas, capacidad_personas, vistas, accesibilidad, tipo_bano, wifi, television, ducha, ventilador, calefaccion, aire_acondicionado, frigo_bar, piso, extras, servicios_adicionales) VALUES
    (1, 20.00, 'Individual', 1, 1, 'Ninguna', 'Accesible', 'Ducha', 'S�', 'S�', 'S�', 'S�', 'S�', 'No', 'No', 'Planta baja', 'Desayuno incluido', 'Servicio de limpieza diario'),
    (2, 25.00, 'Matrimonial', 1, 2, 'Ciudad', 'Accesible', 'Ducha', 'S�', 'S�', 'S�', 'No', 'S�', 'S�', 'Mini-bar', 'Planta baja', 'Desayuno incluido', 'Servicio de limpieza diario'),
    (3, 45.00, 'King Size', 1, 2, 'Mar', 'Accesible', 'Ba�o con tina', 'S�', 'S�', 'S�', 'S�', 'S�', 'S�', 'Mini-bar', 'Segundo piso', 'Jacuzzi privado', 'Servicio de mayordomo 24 horas'),
    (4, 60.00, 'King Size', 1, 2, 'Panor�mica', 'Accesible', 'Ba�o con tina', 'S�', 'S�', 'S�', 'S�', 'S�', 'S�', 'Frigo-bar', 'Tercer piso', 'Vista panor�mica', 'Servicio de mayordomo 24 horas');

INSERT INTO tbl_imagen_habitacion (id_habitacion, url_imagen, descripcion) VALUES
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Vista de la habitaci�n econ�mica'),
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Cama individual de la habitaci�n econ�mica'),
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Ba�o privado de la habitaci�n econ�mica'),
    
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Vista de la habitaci�n est�ndar'),
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Cama matrimonial de la habitaci�n est�ndar'),
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Ba�o privado de la habitaci�n est�ndar'),
    
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Vista de la suite de lujo'),
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Cama king size de la suite de lujo'),
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Vista al mar desde la suite de lujo'),
    
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Vista panor�mica de la habitaci�n presidencial'),
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Cama king size de la habitaci�n presidencial'),
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Ba�o de lujo de la habitaci�n presidencial');