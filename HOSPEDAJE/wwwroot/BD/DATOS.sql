-- *******************************************
-- 4. Tabla de Habitaciones
-- *******************************************
INSERT INTO tbl_estado(nombre, descripcion) VALUES 
    ('Disponible', 'La habitación está disponible para ser reservada.'),
    ('Ocupada', 'La habitación está ocupada por un cliente.'),
    ('Mantenimiento', 'La habitación está en mantenimiento.'),
    ('Limpieza', 'La habitación está siendo limpiada.');

INSERT INTO tbl_categoria (nombre_categoria, descripcion) VALUES 
    ('Económica', 'Habitación económica con lo básico para una estancia cómoda.'),
    ('Estándar', 'Habitación estándar con servicios adicionales para mayor confort.'),
    ('Suite', 'Suite de lujo con múltiples servicios y una experiencia premium.'),
    ('Presidencial', 'Habiración de alta gama para huéspedes VIP con todos los lujos.');

INSERT INTO tbl_habitacion (id_categoria, id_estado, numero, precio, descripcion) VALUES 
    (1, 1, '101', 50.00, 'Habitación económica con una cama individual y baño privado.'),
    (2, 1, '102', 75.00, 'Habitación estándar con cama matrimonial y baño privado.'),
    (3, 2, '201', 150.00, 'Suite de lujo con cama king size y vista al mar.'),
    (4, 3, '301', 300.00, 'Habitación presidencial con jacuzzi, cama king size y todos los servicios.');

    INSERT INTO tbl_detalle_habitacion (id_habitacion, tamanio_habitacion, tipo_cama, numero_camas, capacidad_personas, vistas, accesibilidad, tipo_bano, wifi, television, ducha, ventilador, calefaccion, aire_acondicionado, frigo_bar, piso, extras, servicios_adicionales) VALUES
    (1, 20.00, 'Individual', 1, 1, 'Ninguna', 'Accesible', 'Ducha', 'Sí', 'Sí', 'Sí', 'Sí', 'Sí', 'No', 'No', 'Planta baja', 'Desayuno incluido', 'Servicio de limpieza diario'),
    (2, 25.00, 'Matrimonial', 1, 2, 'Ciudad', 'Accesible', 'Ducha', 'Sí', 'Sí', 'Sí', 'No', 'Sí', 'Sí', 'Mini-bar', 'Planta baja', 'Desayuno incluido', 'Servicio de limpieza diario'),
    (3, 45.00, 'King Size', 1, 2, 'Mar', 'Accesible', 'Baño con tina', 'Sí', 'Sí', 'Sí', 'Sí', 'Sí', 'Sí', 'Mini-bar', 'Segundo piso', 'Jacuzzi privado', 'Servicio de mayordomo 24 horas'),
    (4, 60.00, 'King Size', 1, 2, 'Panorámica', 'Accesible', 'Baño con tina', 'Sí', 'Sí', 'Sí', 'Sí', 'Sí', 'Sí', 'Frigo-bar', 'Tercer piso', 'Vista panorámica', 'Servicio de mayordomo 24 horas');

INSERT INTO tbl_imagen_habitacion (id_habitacion, url_imagen, descripcion) VALUES
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Vista de la habitación económica'),
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Cama individual de la habitación económica'),
    (1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTD-uZbAICjNy10pTQaHGjGOVUrwmmIRRmCg&s', 'Baño privado de la habitación económica'),
    
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Vista de la habitación estándar'),
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Cama matrimonial de la habitación estándar'),
    (2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRstkxbU3KTvBi8q00uBxZoD7MiHOintBWBQw&s', 'Baño privado de la habitación estándar'),
    
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Vista de la suite de lujo'),
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Cama king size de la suite de lujo'),
    (3, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQRfv8B2orq3HEPzBtzonrmv5ExJ1avOVpHA&s', 'Vista al mar desde la suite de lujo'),
    
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Vista panorámica de la habitación presidencial'),
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Cama king size de la habitación presidencial'),
    (4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdM8J8rj1IOvPGc7UdTbpB3Oa2AockwYpbpg&s', 'Baño de lujo de la habitación presidencial');